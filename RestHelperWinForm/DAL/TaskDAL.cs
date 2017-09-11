using System;
using System.Collections.Generic;
using System.Text;

namespace RestHelperUI
{
    using System;
    using System.Data;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.IO;
    using System.Collections;
    using System.Data.SQLite;

    namespace DBUtility.SQLite
    {
        using System;
        using System.Data.SQLite;
        using System.Data.Common;
        using System.Windows.Forms;
        using RestHelperUI.Model;

        namespace SQLiteSamples
        {
           public class TaskDAL
            {
                //数据库连接
               //static string dbfilePath = System.AppDomain.CurrentDomain.BaseDirectory+@"SqlLite\taskDB.s3db";
               //static SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=taskDB.s3db;Version=3;");
//               SQLiteConnectionStringBuilder sqlitestring = new SQLiteConnectionStringBuilder();
//sqlitestring.DataSource = "C:\\data.db";
               static string sqlPath = "Data Source=" + Application.StartupPath + @"\taskDB.s3db";

                public TaskDAL()
                {
                    //createNewDatabase();
                    //connectToDatabase();
                    //createTable();
                    //fillTable();
                    //printHighscores();
                }

                //创建一个空的数据库
               public static void createNewDatabase()
                {
                    SQLiteConnection.CreateFile("MyDatabase.sqlite");
                }

                //创建一个连接到指定数据库
               //public static void connectToDatabase()
               // {
               //     m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
               //     m_dbConnection.Open();
               // }

               //在指定数据库中创建一个table
               //void createTable()
               //{
               //    string sql = "create table highscores (name varchar(20), score int)";
               //    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
               //    command.ExecuteNonQuery();
               //}
               public static int GetMaxNumber()
               {
                   string sql = @"select max(orderNumber) from Task";

                   int i = 0;

                   DbProviderFactory fact = DbProviderFactories.GetFactory("System.Data.SQLite");
                   using (DbConnection cnn = fact.CreateConnection())
                   {
                       cnn.ConnectionString = sqlPath;
                       cnn.Open();
                       SQLiteCommand command = new SQLiteCommand(sql, (SQLiteConnection)cnn);
                       SQLiteDataReader reader = command.ExecuteReader();
                       while (reader.Read())
                       {
                           string iresult =reader[0].ToString();
                           if(!string.IsNullOrEmpty(iresult))
                           {
                               i = int.Parse(iresult)+1;
                           }
                       }
                   }
                   return i;
               }

                //插入一些数据
                public static int AddTask(TaskClass NewTask)
                {
                    string sql = @"insert into Task (taskid, orderNumber,taskName,dtStart,dtEnd,progresss,taskContent) values (
                    '" + NewTask.taskid + @"',"
                       + NewTask.orderNumber + @", '"
                       + NewTask.taskName + @"', '"
                       + NewTask.dtStart.ToString("yyyy-MM-dd HH:mm:ss") + @"', '"
                       + NewTask.dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + @"', '"
                       + NewTask.progresss + @"', '"
                       + NewTask.taskContent + @"')";

                    int i = 0;

                    DbProviderFactory fact = DbProviderFactories.GetFactory("System.Data.SQLite");
                    using (DbConnection cnn = fact.CreateConnection())
                    {
                        cnn.ConnectionString = sqlPath;
                        cnn.Open();
                        SQLiteCommand command = new SQLiteCommand(sql, (SQLiteConnection)cnn);

                        i = command.ExecuteNonQuery();
                    }
                   return i;
                }

                public static int UpdateTask(TaskClass NewTask)
                {

                    string sql = @"update Task set taskName= '" + NewTask.taskName
                        + @"',dtStart='" + NewTask.dtStart.ToString("yyyy-MM-dd HH:mm:ss")
                        + @"',dtEnd='" + NewTask.dtEnd.ToString("yyyy-MM-dd HH:mm:ss") 
                        + @"',progresss='"+ NewTask.progresss 
                        +  @"',taskContent='"+ NewTask.taskContent
                        + @"' where orderNumber='" + NewTask.orderNumber + @"'";
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
                    }catch(Exception ex)
                    {

                    }
                    return i;
                }

                public static int DeleteTask(TaskClass NewTask)
                {

                    string sql = @"delete from Task where orderNumber='" + NewTask.orderNumber + @"'";
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

                //查询未完成任务
                public static List<TaskClass> GetTastList()
                {

                    DbProviderFactory fact = DbProviderFactories.GetFactory("System.Data.SQLite");

                    List<TaskClass> taskList = new List<TaskClass>();
                    using (DbConnection cnn = fact.CreateConnection())
                    {
                        cnn.ConnectionString = sqlPath;// "Data Source=taskDB.s3db";
                        LogHelper.WriteErrLog(sqlPath);
                        cnn.Open();

                        string sql = "select * from Task  where progresss<>100  order by orderNumber desc";
                        SQLiteCommand command = new SQLiteCommand(sql, (SQLiteConnection)cnn);
                        SQLiteDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            TaskClass task = new TaskClass();
                            task.taskid = reader["taskid"].ToString();
                            task.orderNumber = int.Parse(reader["orderNumber"].ToString());
                            task.taskName = reader["taskName"].ToString();
                            task.dtStart = DateTime.Parse(reader["dtStart"].ToString());
                            task.dtEnd = DateTime.Parse(reader["dtEnd"].ToString());
                            task.progresss = double.Parse(reader["progresss"].ToString());
                            taskList.Add(task);
                        }
                    }
                    return taskList;
                }

                //查询已完成任务
                public static List<TaskClass> GetCompleteTastList()
                {

                    DbProviderFactory fact = DbProviderFactories.GetFactory("System.Data.SQLite");

                    List<TaskClass> taskList = new List<TaskClass>();
                    using (DbConnection cnn = fact.CreateConnection())
                    {
                        cnn.ConnectionString = sqlPath;
                        cnn.Open();

                        string sql = "select * from Task where progresss==100 order by orderNumber desc";
                        SQLiteCommand command = new SQLiteCommand(sql, (SQLiteConnection)cnn);
                        SQLiteDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            TaskClass task = new TaskClass();
                            task.taskid = reader["taskid"].ToString();
                            task.orderNumber = int.Parse(reader["orderNumber"].ToString());
                            task.taskName = reader["taskName"].ToString();
                            task.dtStart = DateTime.Parse(reader["dtStart"].ToString());
                            task.dtEnd = DateTime.Parse(reader["dtEnd"].ToString());
                            task.progresss = double.Parse(reader["progresss"].ToString());
                            taskList.Add(task);
                        }
                    }
                    return taskList;
                }

                //使用sql查询语句，并显示结果
                public static List<TaskClass> GetAllTastList()
                {

                    DbProviderFactory fact = DbProviderFactories.GetFactory("System.Data.SQLite");

                    List<TaskClass> taskList = new List<TaskClass>();
                    using (DbConnection cnn = fact.CreateConnection())
                    {
                        cnn.ConnectionString = sqlPath;
                        cnn.Open();

                        string sql = "select * from Task order by orderNumber desc";
                        SQLiteCommand command = new SQLiteCommand(sql, (SQLiteConnection)cnn);
                        SQLiteDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            TaskClass task = new TaskClass();
                            task.taskid = reader["taskid"].ToString();
                            task.orderNumber = int.Parse(reader["orderNumber"].ToString());
                            task.taskName = reader["taskName"].ToString();
                            task.dtStart = DateTime.Parse(reader["dtStart"].ToString());
                            task.dtEnd = DateTime.Parse(reader["dtEnd"].ToString());
                            task.progresss = double.Parse(reader["progresss"].ToString());
                            taskList.Add(task);
                        }
                    }
                    return taskList;
                }
               /// <summary>
               /// 查询待办任务
               /// </summary>
               /// <param name="isCompleteTask">0待办，1已办,2所有</param>
               /// <returns></returns>
                public static DataTable ReadTaskData(int TaskType)
                {
                    List<TaskClass> taskList = new List<TaskClass>();
                    if (TaskType==1)
                    {
                        taskList = GetCompleteTastList();
                    }
                    else if (TaskType == 0)
                    {
                        taskList = GetTastList();
                    }
                    else if (TaskType == 2)
                    {
                        taskList = GetAllTastList();
                    }
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

                    foreach (var task in taskList)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = task.orderNumber;
                        dr[1] = task.taskName;
                        dr[2] = task.dtStart;
                        dr[3] = task.dtEnd;
                        dr[4] = task.progresss;
                        dt.Rows.Add(dr);
                    }
                    return dt;
                }
            }
        }
    }
}
