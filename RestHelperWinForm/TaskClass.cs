using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace RestHelperUI
{
   public class TaskClass
    {
       public TaskClass()
       {
           taskid = Guid.NewGuid().ToString();
           orderNumber = 0;
           taskName = string.Empty;
           dtStart = DateTime.Now;
           dtEnd = DateTime.Now; 
           progresss = 0;
       }
       public string taskid;
       public int orderNumber;
       public string taskName;
       public DateTime dtStart;
       public DateTime dtEnd;
       public double progresss;
       public string taskContent;



    }
}
