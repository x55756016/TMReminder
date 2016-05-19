using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace UPdate
{
    public partial class Form1 : Form
    {
        private string downloadUrl = "http://www.oa12.com/RestHelper/RestHelperUI.exe";
        private string exeFileName = "RestHelperUI.exe";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            this.ControlBox = false;   // 设置不出现关闭按钮
            System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process p in ps)
            {
                //MessageBox.Show(p.ProcessName);
                if (p.ProcessName.ToUpper() == "RESTHELPERUI")
                {
                    p.Kill();
                    break;
                }
            }

            string oldpath = Application.StartupPath + @"\" + exeFileName;
            string newpath = Application.StartupPath + @"\" + exeFileName +DateTime.Now.ToString("yyyy-MM-dd HHmmss")+ ".old";
            //开始更新
            try
            {
                File.Move(oldpath, newpath);
                label1.Text = "检测到系统已更新，正在为您自动升级，请稍后......";
                string filename = "RestHelperUI.exe";
                DownloadFile(downloadUrl, filename, ProgressBar_Value);
            }
            catch (Exception ex)
            {
                //File.Move(newpath, oldpath);
            }
        }

        /// <summary>
        /// 显示进度
        /// </summary>
        /// <param name="val"></param>
        private void ProgressBar_Value(int val)
        {
            progressBar1.Value = val;
            labelProgress.Text = val.ToString() + "%";
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="savefile"></param>
        /// <param name="downloadProgressChanged"></param>
        /// <param name="downloadFileCompleted"></param>
        private void DownloadFile(string url, string savefile, Action<int> downloadProgressChanged)
        {
            WebClient client = new WebClient();
            if (downloadProgressChanged != null)
            {
                client.DownloadProgressChanged += delegate(object sender, DownloadProgressChangedEventArgs e)
                {
                    this.Invoke(downloadProgressChanged, e.ProgressPercentage);
                };
            }
            client.DownloadFileCompleted += delegate(object sender, AsyncCompletedEventArgs e)
            {
                label1.Text = "更新完成，正在重启动应用程序...";
                System.Diagnostics.Process.Start(exeFileName);
                Close();
                Application.Exit();
            };
            client.DownloadFileAsync(new Uri(url), savefile);
        }
        delegate void Action(); //.NET Framework 2.0得自定义委托Action
    }
}
