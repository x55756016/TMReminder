using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RestHelperUI.chlidForm
{
    public partial class Form_word : Form_Base
    {
        public Form_word()
        {
            InitializeComponent();
        }  private Form fatherForm;
        public Form_word(Form form)
        {
            fatherForm = form;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form_paperitemADD doTaskForm = new Form_paperitemADD(this);
            doTaskForm.TopMost = true;
            doTaskForm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            doTaskForm.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            Form_paperitemStart doTaskForm = new Form_paperitemStart(this);
            doTaskForm.TopMost = true;
            doTaskForm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            doTaskForm.Show();
        }

        private void Form_word_FormClosing(object sender, FormClosingEventArgs e)
        {
            fatherForm.Show();
        }

        private void btnPractise_Click(object sender, EventArgs e)
        {
            Form_paperitemTest doTaskForm = new Form_paperitemTest(this);
            doTaskForm.TopMost = true;
            doTaskForm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            doTaskForm.Show();
        }

        private void btnWrongWord_Click(object sender, EventArgs e)
        {
            Form_paperitemWrong doTaskForm = new Form_paperitemWrong(this);
            doTaskForm.TopMost = true;
            doTaskForm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            doTaskForm.Show();
        }
    }
}
