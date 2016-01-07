using Microsoft.Win32;
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
    public partial class Form1 : Form
    {
        /// <summary>
        /// 上次休息时间
        /// </summary>
        private DateTime dtpreTime;
        public Form1()
        {
            dtpreTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0);
            InitializeComponent();
            timer1.Start();
            loadData();
        }
        private void loadData()
        {
            DataTable dt = TaskDBHelper.ReadTaskData(0);
            dtDotask.DataSource = dt;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dtnow = DateTime.Now;

            this.Text = "距离上次休息已经：" + (dtnow - dtpreTime).Hours + "小时，" + (dtnow - dtpreTime).Minutes + "分钟，" + (dtnow - dtpreTime).Seconds + "秒";
            if ((dtnow - dtpreTime).Hours >= 2)
            {
                dtpreTime = DateTime.Now;
                this.msgTxt.Text = "警告：已连续坐着工作超过2个小时，喝口水，走动一下，休息一会";
                this.Show();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
            this.notifyIcon1.Visible = true;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)//最小化      
            {
                this.ShowInTaskbar = false;
                this.notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show();
            }
        }

        private void btNo_Click(object sender, EventArgs e)
        {
            dtpreTime = dtpreTime.AddMinutes(10);
            this.msgTxt.Text = string.Empty;
            this.Visible = false;
            this.notifyIcon1.Visible = true;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            reSetpreTime();
            this.Visible = false;
            this.notifyIcon1.Visible = true;
            this.Hide();
        }
        private void reSetpreTime()
        {
            dtpreTime = DateTime.Now;
            this.msgTxt.Text = string.Empty;
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
                    MessageBox.Show("取消开机自启动，需要修改注册表", "提示");
                    string path = Application.ExecutablePath;
                    RegistryKey rk = Registry.LocalMachine;
                    RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                    rk2.DeleteValue("SKR", false);
                    rk2.Close();
                    rk.Close();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddTaskForm FormTask = new AddTaskForm();
            FormTask.Show();
            FormTask.addComplete += FormTask_addComplete;
        }

        void FormTask_addComplete(string status)
        {
            loadData();
            this.Show();
        }

        private void btnGetTask_Click(object sender, EventArgs e)
        {
            DataTable dt = TaskDBHelper.ReadTaskData(0);
            dtDotask.DataSource = dt;
        }

        private void btnCompleteTask_Click(object sender, EventArgs e)
        {
            DataTable dt = TaskDBHelper.ReadTaskData(1);
            dtDotask.DataSource = dt;
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName ="任务报告"+ DateTime.Now.ToString("yyyy-MM-dd");
            saveFileDialog1.Filter = "CSV文件|*.csv";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = dtDotask.DataSource as DataTable;
                CsvHelper.savecsv(dt, saveFileDialog1.FileName);
            }
        }

        private void btnGetAllTask_Click(object sender, EventArgs e)
        {
            DataTable dt = TaskDBHelper.ReadTaskData(2);
            dtDotask.DataSource = dt;
        }
    }
}
