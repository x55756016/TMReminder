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
            Next();
             
        }

         private void Next()
         {
             txtEword.Text = string.Empty;
             txtCword.Text = string.Empty;
             txtsentence.Text = string.Empty;
             txtOrdernumber.ReadOnly = true;
             DbHelperSQLite.connectionString = "Data Source=" + Application.StartupPath + @"\taskDB.s3db";
             txtOrdernumber.Text = DbHelperSQLite.GetMaxID("ordernumber", "tm_qa_paperitem").ToString();
         }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                tm_qa_paperitem item = new tm_qa_paperitem();
                item.itemid = Guid.NewGuid().ToString();
                item.ordernumber =decimal.Parse(txtOrdernumber.Text);
                item.eword = txtEword.Text;
                item.cword = txtCword.Text;
                item.sentence = txtsentence.Text;

                if(string.IsNullOrEmpty(item.eword)|| string.IsNullOrEmpty(item.cword))
                {
                    MessageBox.Show("请填写完整信息！");
                    return;
                }

                tm_qa_paperitemBLL bll = new tm_qa_paperitemBLL();
                bll.Add(item);
                MessageBox.Show("保存成功！");
                Next();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form_paperitemADD_FormClosed(object sender, FormClosedEventArgs e)
        {
            fatherForm.Show();
        }
    }
}
