using Microsoft.Win32;
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
        private DateTime dtpre;
        public Form1()
        {
            dtpre = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0);
            InitializeComponent();
            timer1.Start();
            //notifyIcon1.Visible = false;
           DataTable dt= ReadTask.ReadTaskData();
           dtDotask.DataSource = dt;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dtnow = DateTime.Now;

            this.Text = "距离上次休息已经：" + (dtnow - dtpre).Hours + "小时，" + (dtnow - dtpre).Minutes + "分钟，" + (dtnow - dtpre).Seconds + "秒";
            if ((dtnow - dtpre).Hours >= 2)
            {
                dtpre = DateTime.Now;
                this.msgTxt.Text = "已辛苦工作超过2个小时了，赶紧喝口水，到处走走运动一下......";
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
            dtpre = dtpre.AddMinutes(10);
            this.Visible = false;
            this.notifyIcon1.Visible = true;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.notifyIcon1.Visible = true;
            this.Hide();
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
        }
    }
}
