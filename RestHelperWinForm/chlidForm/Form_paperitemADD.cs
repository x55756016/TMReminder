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
         private Form1 fatherForm;
         public Form_paperitemADD(Form1 form)
        {
            fatherForm = form;
            InitializeComponent();
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
    }
}
