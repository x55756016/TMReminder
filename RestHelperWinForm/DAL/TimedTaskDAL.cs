using RestHelperUI.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;

namespace RestHelperUI.DAL
{
    public class TimedTaskDAL
    {
        static string sqlPath = "Data Source=" + Application.StartupPath + @"\taskDB.s3db";
        //查询未完成定时任务
        public static List<TimedTaskDto> GetTimeTastList()
        {

            DbProviderFactory fact = DbProviderFactories.GetFactory("System.Data.SQLite");

            List<TimedTaskDto> taskList = new List<TimedTaskDto>();
            using (DbConnection cnn = fact.CreateConnection())
            {
                cnn.ConnectionString = sqlPath;// "Data Source=taskDB.s3db";
                LogHelper.WriteErrLog(sqlPath);
                cnn.Open();

                string sql = "select * from CTMS_TK_TIMEDTASK  where TASKSTATUS = 0";
                SQLiteCommand command = new SQLiteCommand(sql, (SQLiteConnection)cnn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TimedTaskDto task = new TimedTaskDto();
                    task.TIMEDTASKID = reader["TIMEDTASKID"].ToString();
                    task.MESSAGEBODY = reader["MESSAGEBODY"].ToString();
                    task.MODELCODE = reader["MODELCODE"].ToString();
                    task.MSGLINKURL = reader["MSGLINKURL"].ToString();
                    task.PROCESSFUNCPAMETER = reader["dtEnd"].ToString();
                    task.TASKSTATUS = reader["progresss"].ToString();
                    taskList.Add(task);
                }
            }
            return taskList;
        }

        public static int UpdateTimeTask(string TIMEDTASKID)
        {

            string sql = @"update taskName set TASKSTATUS=1,EXECUTTIME='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                + @"',UPDATEDATE='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                + @"' where TIMEDTASKID='" + TIMEDTASKID + @"'";
            int i = 0;
            try
            {
                DbProviderFactory fact = DbProviderFactories.GetFactory("System.Data.SQLite");
                using (DbConnection cnn = fact.CreateConnection())
                {
                    cnn.ConnectionString = sqlPath;
                    cnn.Open();
                    SQLiteCommand command = new SQLiteCommand(sql, (SQLiteConnection)cnn);
                    i = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            return i;
        }
    }
}
