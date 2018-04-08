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
    public partial class Form_paperitemStart : Form
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tm_qa_paperitem item = new tm_qa_paperitem();
            item.itemid = Guid.NewGuid().ToString();
            item.ordernumber = DbHelperSQLite.GetMaxID("ordernumber", "tm_qa_paperitem");
            item.eword = txtEword.Text;
            item.cword = txtCword.Text;
            item.sentence = txtsentence.Text;

            tm_qa_paperitemBLL bll = new tm_qa_paperitemBLL();
            bll.Add(item);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            tm_qa_paperitemBLL bll = new tm_qa_paperitemBLL();
            bll.Delete("");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Currentordernumber = Currentordernumber + 1;
            tm_qa_paperitem item = itembll.GetModelByOrderNumber(Currentordernumber.ToString());
            if(item==null)
            {
                Currentordernumber = Currentordernumber - 1;
                MessageBox.Show("最后一条记录！");
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
    }
}
