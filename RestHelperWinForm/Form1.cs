using Microsoft.Win32;
using RestHelperUI.chlidForm;
using RestHelperUI.DBUtility.SQLite.SQLiteSamples;
using RestHelperUI.Helper;
using RestHelperUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RestHelperUI
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            dtpreTime = DateTime.Now;
            InitializeComponent();
        }




        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            //this.WindowState = FormWindowState.Minimized;
            //this.Visible = false;
            this.Hide();
            this.notifyIcon1.Visible = true;
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
                if (!IsAdministrator())
                {
                    MessageBox.Show("非管理员账户，无法设置自动启动", "提示");
                    return;
                }
                
                if (checkBox1.Checked)
                //设置开机自启动            
                {
                    //MessageBox.Show("设置开机自启动，需要修改注册表", "提示");
                    string path = "\""+Application.ExecutablePath+"\"";
                    RegistryKey rk = Registry.CurrentUser;
                    RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                    rk2.SetValue("RestHelper", path);
                    rk2.Close();
                    rk.Close();
                }
                else //取消开机自启动              
                {
                   
                    string path = Application.ExecutablePath;
                    RegistryKey rk = Registry.CurrentUser;
                    RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                    rk2.DeleteValue("RestHelper", false);
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
            try
            {
                DataTable dt = this.dtDotask.DataSource as DataTable;
                if (dt.Rows.Count == 0) return;

                string buttonText = this.dtDotask.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (buttonText == "更新进度")
                {
                    string orderNumber = this.dtDotask.Rows[e.RowIndex].Cells["序号"].Value.ToString();


                    TaskClass task = new TaskClass();
                    task.orderNumber = int.Parse(orderNumber);

                    AddTaskForm FormTask = new AddTaskForm();
                    FormTask.NewTask = task;
                    FormTask.TopMost = true;
                    FormTask.StartPosition = FormStartPosition.CenterScreen;
                    FormTask.Show();
                    FormTask.addComplete += FormTask_addComplete;
                }
                if (buttonText == "删除")
                {
                    string orderNumber = this.dtDotask.Rows[e.RowIndex].Cells["序号"].Value.ToString();
                    string taskName = this.dtDotask.Rows[e.RowIndex].Cells["任务名称"].Value.ToString();

                    TaskClass task = new TaskClass();
                    task.orderNumber = int.Parse(orderNumber);
                    task.taskName = taskName;
                    if (MessageBox.Show("确定删除任务： " + taskName + " ?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        TaskDAL.DeleteTask(task);
                        loadData();
                    }
                }
                if (buttonText == "开始执行")
                {
                    int orderNumber = int.Parse(this.dtDotask.Rows[e.RowIndex].Cells["序号"].Value.ToString());
                    DoTaskForm doTaskForm = new DoTaskForm(this, orderNumber);
                    doTaskForm.TopMost = true;
                    doTaskForm.StartPosition = FormStartPosition.CenterScreen;
                    this.Hide();
                    doTaskForm.Show();

                }
            }
            catch(Exception ex)
            {
                ServerHelper.sendLog(ex.ToString());
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

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                this.TopMost = true;
                this.StartPosition = FormStartPosition.CenterScreen;
                SoftUpdateHelper app = new SoftUpdateHelper();
                app.StartCheckUpdate();
                timer1.Start();
                loadData();
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrLog("Form1_Load"+ex.ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //this.linkLabel1.Links[0].LinkData = "http://www.oa12.com";
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());    
        }

        private void button9_Click(object sender, EventArgs e)
        {
            zjbForm zform = new zjbForm(this);
            zform.TopMost = true;
            zform.StartPosition = FormStartPosition.CenterScreen;
            zform.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_word doTaskForm = new Form_word(this);
            doTaskForm.TopMost = true;
            doTaskForm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            doTaskForm.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form_Base f = new Form_Base();
            f.Show();
        }
    }
}
