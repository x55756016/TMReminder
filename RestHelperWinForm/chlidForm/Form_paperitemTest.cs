using Maticsoft.BLL;
using Maticsoft.DBUtility;
using Maticsoft.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RestHelperUI.chlidForm
{
    public partial class Form_paperitemTest : Form_Base
    {
        public Form_paperitemTest()
        {
            InitializeComponent();

        }
        private Form fatherForm;
        private int Currentordernumber=1;
        tm_qa_userpaperrecordBLL ubll;
        tm_qa_paperitemBLL itembll;
        public Form_paperitemTest(Form form)
        {
            fatherForm = form;
            InitializeComponent();
            txtEword.Visible = false;
            ubll = new tm_qa_userpaperrecordBLL();
            itembll = new tm_qa_paperitemBLL();
            tm_qa_userpaperrecord ur=  ubll.GetModel("xiang");
            string lastitemid = string.Empty;
            if(ur!=null)
            {
                lastitemid = ur.lastitemid;
                
               
            }else
            {
                lastitemid = itembll.GetModelByOrderNumber(Currentordernumber.ToString()).itemid;
            }
            BindItembyId(lastitemid);
            txtResult.Focus();
        }

        private void BindItembyId(string itemid)
        {
            tm_qa_paperitemBLL bll = new tm_qa_paperitemBLL();
            tm_qa_paperitem item = bll.GetModel(itemid);
            if(item!=null)
            {
                labordernumber.Text = item.ordernumber.ToString();
                txtCword.Text = item.cword;
                txtEword.Text = item.eword;
                txtsentence.Text = item.sentence;
            }
            Currentordernumber = int.Parse(item.ordernumber.ToString());
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            clearText();
            Currentordernumber = Currentordernumber + 1;
            DbHelperSQLite.connectionString = "Data Source=" + Application.StartupPath + @"\taskDB.s3db";
            if (Currentordernumber == DbHelperSQLite.GetMaxID("ordernumber", "tm_qa_paperitem"))
            {
                Currentordernumber = Currentordernumber - 1;
                MessageBox.Show("最后一条记录！");
                return;
            }
            tm_qa_paperitem item = itembll.GetModelByOrderNumber(Currentordernumber.ToString());
            if (item == null)
            {
                Currentordernumber = Currentordernumber - 1;
                MessageBox.Show("最后一条记录！");
                return;
            }
            string lastitemid = item.itemid;
            BindItembyId(lastitemid);

            UPdateUserData();
        }

        private void UPdateUserData()
        {
            tm_qa_paperitem item = itembll.GetModelByOrderNumber(Currentordernumber.ToString());
            //更新用户最后一题id
            tm_qa_userpaperrecord ur = ubll.GetModel("xiang");
            if (ur != null)
            {
                ur.lastitemid = item.itemid;
                ubll.Update(ur);
            }
            else
            {
                ur = new tm_qa_userpaperrecord();
                ur.recordid = Guid.NewGuid().ToString();
                ur.lastitemid = item.itemid;
                ubll.Add(ur);

            }
        }

        private void btnprov_Click(object sender, EventArgs e)
        {
            clearText();
            Currentordernumber = Currentordernumber- 1;
            if(Currentordernumber==0)
            {
                Currentordernumber = 1;
                MessageBox.Show("第一条记录！");
                return;
            }
            string lastitemid = itembll.GetModelByOrderNumber(Currentordernumber.ToString()).itemid;
            BindItembyId(lastitemid);
        }

        private void btnSumbit_Click(object sender, EventArgs e)
        {
            txtEword.Visible = true;
            if (txtResult.Text.ToLower().TrimEnd().TrimStart() == txtEword.Text.ToLower().TrimEnd().TrimStart())
            {
                labResult.Text = "回答正确！";
            }
            else
            {
                labResult.Text = "回答错误！";
                addToWrongDb();
            }
            UPdateUserData();

            txtResult.Focus();
        }

        private void addToWrongDb()
        {
            try
            {
                tm_qa_paperitem item = itembll.GetModelByOrderNumber(Currentordernumber.ToString());
                tm_qa_wrongitemBLL wrongBll = new tm_qa_wrongitemBLL();
                tm_qa_wrongitem itemlast=wrongBll.GetModelByItemid(item.itemid);
                if(itemlast!=null)
                {
                    itemlast.wrongnumber = itemlast.wrongnumber + 1;
                    wrongBll.Update(itemlast);
                }else
                {
                    tm_qa_wrongitem wrongItem = new tm_qa_wrongitem();
                    wrongItem.wrongid = Guid.NewGuid().ToString();
                    wrongItem.itemid = item.itemid;
                    DbHelperSQLite.connectionString = "Data Source=" + Application.StartupPath + @"\taskDB.s3db";
                    wrongItem.ordernumber = DbHelperSQLite.GetMaxID("ordernumber", "tm_qa_wrongitem");
                    wrongItem.wrongnumber = 1; 
                    wrongBll.Add(wrongItem);
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void clearText()
        {
            txtEword.Visible = false;
            labResult.Text = string.Empty;
            labordernumber.Text = string.Empty;
            txtCword.Text = string.Empty;
            txtEword.Text = string.Empty;
            txtsentence.Text = string.Empty;
            txtResult.Text = string.Empty; 
        }

        private void Form_paperitemTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            fatherForm.Show();
        }
    }
}
