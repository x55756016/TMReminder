using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace RestHelperUI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());        
           
        }

    }
}
