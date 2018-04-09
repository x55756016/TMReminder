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
    public partial class Form_paperitemStart : Form_Base
    {
        public Form_paperitemStart()
        {
            InitializeComponent();

        }
        private Form fatherForm;
        private int Currentordernumber=1;
        tm_qa_userpaperrecordBLL ubll;
        tm_qa_paperitemBLL itembll;
        public Form_paperitemStart(Form form)
        {
            fatherForm = form;
            InitializeComponent();

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

            btnNext.Focus();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Currentordernumber = Currentordernumber + 1;
            DbHelperSQLite.connectionString = "Data Source=" + Application.StartupPath + @"\taskDB.s3db";
            if (Currentordernumber == DbHelperSQLite.GetMaxID("ordernumber", "tm_qa_paperitem"))
            {
                Currentordernumber = Currentordernumber - 1;
                MessageBox.Show("最后一条记录！");
                return;
            }
            tm_qa_paperitem item = itembll.GetModelByOrderNumber(Currentordernumber.ToString());
            if(item==null)
            {
                MessageBox.Show("找不到相关记录！");
                return;
            }
            string lastitemid = item.itemid;
            BindItembyId(lastitemid);

        }

        private void btnprov_Click(object sender, EventArgs e)
        {
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

        private void Form_paperitemStart_FormClosed(object sender, FormClosedEventArgs e)
        {
            fatherForm.Show();
        }
    }
}
