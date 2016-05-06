using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RestHelperUI
{
    public partial class Form1
    {   
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
            DateTime dtnow = DateTime.Now;     
            if (TempSecond == 0)
            {          
                if ((dtnow - dtpreTime).Hours >= 2)
                {                    
                    this.msgTxt.Text = "警告：已连续坐着工作超过2个小时，喝口水，走动一下，休息一会";
                    this.msgTxt.ForeColor = System.Drawing.Color.Red;
                    FormShow();
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
            this.Text = "距离上次休息已经：" + (dtnow - dtpreTime).Hours + "小时，" + (dtnow - dtpreTime).Minutes + "分钟，延后" + TempSecond + "秒后提醒";
        }

        private void FormShow()
        {
            this.Location = new Point(200, 200);
            this.StartPosition = FormStartPosition.Manual;
            this.Height = 640;
            this.Width = 798;
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }


        private void reSetpreTime()
        {
            dtpreTime = DateTime.Now;
            TempSecond = 0;
            this.msgTxt.Text = string.Empty;
        }
    }
}
