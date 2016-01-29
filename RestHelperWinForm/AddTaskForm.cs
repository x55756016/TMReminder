using RestHelperUI.DBUtility.SQLite.SQLiteSamples;
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
        public delegate void BoilerLogHandler(string status);
        public event BoilerLogHandler addComplete;

        private int ordernumber = 0;
        public AddTaskForm()
        {
            InitializeComponent();

            ordernumber = TaskDBHelper.GetMaxNumber();
            txtorderNumber.Text = ordernumber.ToString();
            dtStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0);
            dtEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 30, 0);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TaskClass NewTask = new TaskClass();
                NewTask.taskid = Guid.NewGuid().ToString();
                NewTask.orderNumber = ordernumber;

                NewTask.taskName = txttaskName.Text;
                NewTask.dtStart = dtStart.Value;
                NewTask.dtEnd = dtEnd.Value;

                double progresss = 0;
                double.TryParse(txtprogresss.Text, out progresss);
                NewTask.progresss = progresss;

                NewTask.taskContent = txtTaskContent.Text;

                if (TaskDBHelper.AddTask(NewTask) > 0)
                {
                    //MessageBox.Show("添加任务成功！");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("添加任务失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }finally
            {
                if(addComplete!=null)
                {
                    addComplete("");
                }
            }
        }
    }
}
