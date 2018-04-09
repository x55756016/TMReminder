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
    public partial class Form_paperitemADD : Form
    {
        public Form_paperitemADD()
        {
            InitializeComponent();

        }
        private Form fatherForm;
         public Form_paperitemADD(Form form)
        {
            fatherForm = form;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                tm_qa_paperitem item = new tm_qa_paperitem();
                item.itemid = Guid.NewGuid().ToString();
                DbHelperSQLite.connectionString = "Data Source=" + Application.StartupPath + @"\taskDB.s3db";
                item.ordernumber = DbHelperSQLite.GetMaxID("ordernumber", "tm_qa_paperitem");
                item.eword = txtEword.Text;
                item.cword = txtCword.Text;
                item.sentence = txtsentence.Text;

                tm_qa_paperitemBLL bll = new tm_qa_paperitemBLL();
                bll.Add(item);
                MessageBox.Show("保存成功！");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            tm_qa_paperitemBLL bll = new tm_qa_paperitemBLL();
            bll.Delete("");
        }

        private void Form_paperitemADD_FormClosed(object sender, FormClosedEventArgs e)
        {
            fatherForm.Show();
        }
    }
}
