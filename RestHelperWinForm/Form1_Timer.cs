using RestHelperUI.BLL;
using SMT.Foundation.Log;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RestHelperUI
{
    public partial class Form_Main
    {
        private bool flag;
        private bool needRest = false;
        
        /// <summary>
        /// 上次休息时间
        /// </summary>
        private DateTime dtpreTime;
        /// <summary>
        /// 延后10分钟提醒
        /// </summary>
        private int TempSecond = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //return;
            DateTime dtnow = DateTime.Now;

            //login();
            if (TempSecond == 0)
            {          
                if ((dtnow - dtpreTime).Hours >= 2)
                {
                    this.msgTxt.Text = "警告：已连续坐着工作超过2个小时，请休息一会，喝口水，走动一下";
                        //+System.Environment.NewLine+"走动预防颈椎腰椎病，保护视力，喝水保护皮肤";
                    this.msgTxt.ForeColor = Color.Red;
                    //Thread thread = new Thread(new ThreadStart(ColorChange));
                    //thread.Start();                 
                    FormShow();
                    needRest = true;
                    btOK.Enabled = needRest;
                    btNo.Enabled = needRest;
                }else
                {
                    TimeSpan dtTemp = (dtpreTime.AddHours(2) - dtnow);
                    this.msgTxt.ForeColor = System.Drawing.Color.Black;
                    this.msgTxt.Text = "距离下次休息时间：" + dtTemp.Hours + "小时" + dtTemp.Minutes + "分钟" + dtTemp.Seconds+"秒";
                }
                
            }
            else
            {
                TempSecond = TempSecond - 1;
            }

            //每分钟执行一次
            if ((//DateTime.Now.Minute == 30 ||
                DateTime.Now.Minute == 0) && flag)
            {
                LogHelper.WriteErrLog("执行定时任务");
                flag = false;
                try
                {
                    TimedTaskBLL.PollingTimeTask();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrLog(ex.ToString());
                }
                finally
                {
                    flag = true;
                }
            }
            //this.Text = "距离上次休息已经：" + (dtnow - dtpreTime).Hours + "小时，" + (dtnow - dtpreTime).Minutes + "分钟，延后" + TempSecond + "秒后提醒";
        }


        private void FormShow()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, 200);
            this.Height = 640;
            this.Width = 798;
            //this.WindowState = FormWindowState.Normal;
            this.Show();
        }


        private void reSetpreTime()
        {
            dtpreTime = DateTime.Now;
            TempSecond = 0;
            this.msgTxt.Text = string.Empty;
            needRest = false;
            btOK.Enabled = needRest;
            btNo.Enabled = needRest;
        }


        public void login()
        {
            string strLogin = "http://www.oa12.com/User/UserLogin";
            string strPostData = "LoginName=zwd312146008&MD5LoginPwd=36916266&UserSource=0";

            try
            {
                //myRequest.CookieContainer.Add()
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(strLogin);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.AllowAutoRedirect = false;

                byte[] aryBuf = Encoding.UTF8.GetBytes(strPostData);
                myRequest.ContentLength = aryBuf.Length;
                using (Stream writer = myRequest.GetRequestStream())
                {
                    writer.Write(aryBuf, 0, aryBuf.Length);
                    writer.Close();
                    writer.Dispose();
                }
                //HttpWebResponse response = (HttpWebResponse)myRequest.GetResponse();
                //Stream responseStream = response.GetResponseStream();
                //StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                //string content = reader.ReadToEnd();
                //reader.Close();
                //responseStream.Close();

                //string CookieValue = response.Headers.Get("Set-Cookie");
                //if (CookieValue == null)
                //{
                //    MessageBox.Show("登录失败，请重新登录！");
                //    return;
                //}
                //string[] all = CookieValue.Split(';');
                //foreach (string s in all)
                //{
                //    if (s.Contains("sessionUser_"))
                //    {
                //       string cookie_SessionUser = s.Split('=')[1];
                //    }

                //}
            }
            catch (Exception ex)
            {
                Tracer.Debug("异常：" + ex.ToString());
            }

        }
    }
}
