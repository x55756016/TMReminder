using Microsoft.Win32;
using RestHelperUI.DBUtility.SQLite.SQLiteSamples;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace RestHelperUI
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            dtpreTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0);
            InitializeComponent();
            timer1.Start();
            loadData();
        }




        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            //this.WindowState = FormWindowState.Minimized;
            //this.Visible = false;
            this.Hide();
            this.notifyIcon1.Visible = true;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            FormShow();
        }



        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsAdministrator())
                {
                    MessageBox.Show("非管理员账户，无法设置自动启动", "提示");
                    return;
                }
                
                if (checkBox1.Checked)
                //设置开机自启动            
                {
                    //MessageBox.Show("设置开机自启动，需要修改注册表", "提示");
                    string path = Application.ExecutablePath;
                    RegistryKey rk = Registry.LocalMachine;
                    RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                    rk2.SetValue("SKR", path);
                    rk2.Close();
                    rk.Close();
                }
                else //取消开机自启动              
                {
                   
                    string path = Application.ExecutablePath;
                    RegistryKey rk = Registry.LocalMachine;
                    RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                    rk2.DeleteValue("SKR", false);
                    rk2.Close();
                    rk.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            AddTaskForm FormTask = new AddTaskForm();
            FormTask.TopMost = true;
            FormTask.StartPosition = FormStartPosition.CenterScreen;
            FormTask.Show();
            FormTask.addComplete += FormTask_addComplete;
        }

        void FormTask_addComplete(string status)
        {
            loadData();
            this.Show();
        }

        private void dtDotask_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = this.dtDotask.DataSource as DataTable;
            if (dt.Rows.Count == 0) return;

            string buttonText = this.dtDotask.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (buttonText == "更新进度")
            {
                string orderNumber = this.dtDotask.Rows[e.RowIndex].Cells["任务序号"].Value.ToString();

                string taskName = this.dtDotask.Rows[e.RowIndex].Cells["任务名称"].Value.ToString();
                string dtStart = this.dtDotask.Rows[e.RowIndex].Cells["开始时间"].Value.ToString();
                string dtEnd = this.dtDotask.Rows[e.RowIndex].Cells["结束时间"].Value.ToString();
                string progresss = this.dtDotask.Rows[e.RowIndex].Cells["进度"].Value.ToString();


                TaskClass task = new TaskClass();
                task.orderNumber = int.Parse(orderNumber);
                task.taskName = taskName;
                task.dtStart = DateTime.Parse(dtStart);
                task.dtEnd = DateTime.Parse(dtEnd);
                task.progresss = double.Parse(progresss);

                AddTaskForm FormTask = new AddTaskForm();
                FormTask.NewTask = task;
                FormTask.TopMost = true;
                FormTask.StartPosition = FormStartPosition.CenterScreen;
                FormTask.Show();
                FormTask.addComplete += FormTask_addComplete;
            }
            if (buttonText == "删除")
            {
                string orderNumber = this.dtDotask.Rows[e.RowIndex].Cells["任务序号"].Value.ToString();
                string taskName = this.dtDotask.Rows[e.RowIndex].Cells["任务名称"].Value.ToString();

                TaskClass task = new TaskClass();
                task.orderNumber = int.Parse(orderNumber);
                task.taskName = taskName;
                if (MessageBox.Show("确定删除任务： " + taskName+" ?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    TaskDBHelper.DeleteTask(task);
                    loadData();
                }
            }
        }

        private void btNo_Click(object sender, EventArgs e)
        {
            dtpreTime = dtpreTime.AddMinutes(10);
            this.Visible = false;
            this.notifyIcon1.Visible = true;
            TempSecond = 60 * 10;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            reSetpreTime();
            this.Visible = false;
            this.notifyIcon1.Visible = true;
            this.Hide();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShow();
        }


    }
}
