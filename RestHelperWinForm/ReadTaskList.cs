using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RestHelperUI
{
    public static class ReadTask
    {
        public static  DataTable ReadTaskData()
        {

            DataTable dt = new DataTable("Task");

            DataColumn dc1 = new DataColumn();
            dc1.ColumnName = "任务序号";
            dc1.DataType = typeof(int);

            DataColumn dc2 = new DataColumn();
            dc2.ColumnName = "任务名称";
            dc2.DataType = typeof(string);

            DataColumn dc3 = new DataColumn();
            dc3.ColumnName = "开始时间";
            dc3.DataType = typeof(DateTime);

            DataColumn dc4 = new DataColumn();
            dc4.ColumnName = "结束时间";
            dc4.DataType = typeof(DateTime);

            DataColumn dc5 = new DataColumn();
            dc5.ColumnName = "进度";
            dc5.DataType = typeof(double);

            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);

            TaskClass task = new TaskClass();

            DataRow dr = dt.NewRow();
            dr[0] = task.orderNumber;
            dr[1] = task.taskName;
            dr[2] = task.dtStart;
            dr[3] = task.dtEnd;
            dr[4] = task.progresss;
            dt.Rows.Add(dr);
            return dt;
        }
    }
}
