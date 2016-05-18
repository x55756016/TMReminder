using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
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
            System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process p in ps)
            {
                //MessageBox.Show(p.ProcessName);
                if (p.ProcessName.ToLower() == "RestHelperUI")
                {
                    p.Kill();
                    break;
                }
            }

            string oldpath = Application.StartupPath + @"\" + exeFileName;
            string newpath = Application.StartupPath + @"\" + exeFileName + ".old";
            //开始更新
            try
            {
                File.Move(oldpath, newpath);
                WebClient wc = new WebClient();
                string filename = "RestHelperUI.exe";
                wc.DownloadFile(downloadUrl, filename);
                wc.Dispose();
            }
            catch (Exception ex)
            {
                //File.Move(newpath, oldpath);
            }

            label1.Text = "更新完成";
            label1.Text = "正在重新启动应用程序...";
            System.Diagnostics.Process.Start(exeFileName);
            Close();
            Application.Exit();
        }
    }
}
