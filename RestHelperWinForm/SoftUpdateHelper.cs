using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace RestHelperUI
{
    /// <summary>  
    /// 程序更新  
    /// </summary>  
    public class SoftUpdateHelper
    {
        private string downloadUrl = "http://www.oa12.com/RestHelper/RestHelperUI.exe";
        private string xmlUpdateVersion = "update.xml";
        private string updateXmlUrl = "http://www.oa12.com/RestHelper/Update.xml";//升级配置的XML文件地址  
        private string exeFileName = "RestHelperUI.exe";

        #region 构造函数
        public SoftUpdateHelper() { }

        #endregion

        #region 属性
        private string loadFile;
        private string newVerson;
        private string softName;
        private bool isUpdate;

        /// <summary>  
        /// 或取是否需要更新  
        /// </summary>  
        public bool IsUpdate
        {
            get
            {
                return isUpdate;
            }
            set { isUpdate = value; }
        }

        /// <summary>  
        /// 要检查更新的文件  
        /// </summary>  
        public string LoadFile
        {
            get { return loadFile; }
            set { loadFile = value; }
        }

        /// <summary>  
        /// 程序集新版本  
        /// </summary>  
        public string NewVerson
        {
            get { return newVerson; }
        }

        /// <summary>  
        /// 升级的名称  
        /// </summary>  
        public string SoftName
        {
            get { return softName; }
            set { softName = value; }
        }

        #endregion


        public void StartCheckUpdate()
        {
            WebClient webcDllVersion = new WebClient();
            webcDllVersion.OpenReadCompleted += new OpenReadCompletedEventHandler(webcDllVersion_OpenReadCompleted);
            updateXmlUrl = updateXmlUrl + @"?var=" + DateTime.Now.Millisecond.ToString();
            webcDllVersion.OpenReadAsync(new Uri(updateXmlUrl, UriKind.Absolute));
        }
        /// <summary>
        /// 组件下载完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void webcDllVersion_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                if (e.Error != null)
                {
                    //string SystemMessage="下载版本文件" + this.VertionFileName + "出错，请联系管理员" + e.Error.ToString();
                    //SMT.SAAS.Main.CurrentContext.AppContext.ShowSystemMessageText();
                }
                Stream manifestStream = e.Result;
                xmlDoc.Load(manifestStream);
                XmlNode list = xmlDoc.SelectSingleNode("Update");
                foreach (XmlNode node in list)
                {
                    if (node.Name == "Soft")
                    {
                        foreach (XmlNode xml in node)
                        {
                            if (xml.Name == "Version")
                                newVerson = xml.InnerText;
                            else
                                downloadUrl = xml.InnerText;//获取下载地址
                        }
                    }
                }
                string oldVersion = string.Empty;
                //本地存在dllversion.xml文件
                if (File.Exists(Application.StartupPath + @"\" + xmlUpdateVersion))
                {
                    Stream xmlUPdateStream = File.OpenRead(Application.StartupPath + @"\" + xmlUpdateVersion);
                    XmlDocument xmlLocalDoc = new XmlDocument();
                    xmlLocalDoc.Load(xmlUPdateStream);
                    xmlUPdateStream.Close();

                    XmlNode Locallist = xmlLocalDoc.SelectSingleNode("Update");
                    foreach (XmlNode node in Locallist)
                    {
                        if (node.Name == "Soft")
                        {
                            foreach (XmlNode xml in node)
                            {
                                if (xml.Name == "Version")
                                    oldVersion = xml.InnerText;
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(oldVersion))
                {
                    if (newVerson != oldVersion)
                    {
                        if (MessageBox.Show("检查到新版本，是否更新？", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            StartUpdateForm();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //启动应用
                //StartRestHelper();
            }
            finally
            {
                try
                {
                    //存储versxml到本地
                    string strxml=xmlDoc.InnerXml;
                    //byte[] streambyte = xmlDoc.;
                    //e.Result.Seek(0, SeekOrigin.Begin);
                    //e.Result.Read(streambyte, 0, streambyte.Length);
                    //e.Result.Close();
                    string oldpath = Application.StartupPath + @"\" + xmlUpdateVersion;

                    FileStream fs = new FileStream(oldpath, FileMode.OpenOrCreate);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(strxml);
                    sw.Close();
                }
                catch (Exception ex)
                {
                    //SMT.SAAS.Main.CurrentContext.AppContext.logAndShow(ex.ToString());
                }
            }
        }

        private void StartUpdateForm()
        {  
            System.Diagnostics.Process.Start(Application.StartupPath + @"\UPdate.exe");
            Application.Exit();
        }

    }
}
