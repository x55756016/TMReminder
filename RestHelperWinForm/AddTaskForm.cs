using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RestHelperUI
{
    public partial class AddTaskForm : Form
    {
        public AddTaskForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TaskClass NewTask = new TaskClass();
                NewTask.taskid = Guid.NewGuid().ToString();
                NewTask.orderNumber = int.Parse(txtorderNumber.Text);
                NewTask.taskName = txttaskName.Text;
                NewTask.dtStart = dtStart.Value;
                NewTask.dtEnd = dtEnd.Value;
                NewTask.taskContent = txtTaskContent.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
