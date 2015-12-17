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

        namespace SQLiteSamples
        {
           public class TaskDBHelper
            {
                //数据库连接
               static string dbfilePath = System.AppDomain.CurrentDomain.BaseDirectory+@"SqlLite\taskDB.s3db"; 
               static SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source="+dbfilePath+";Version=3;");
//               SQLiteConnectionStringBuilder sqlitestring = new SQLiteConnectionStringBuilder();
//sqlitestring.DataSource = "C:\\data.db";

                public TaskDBHelper()
                {
                    //createNewDatabase();
                    //connectToDatabase();
                    //createTable();
                    //fillTable();
                    //printHighscores();
                }

                //创建一个空的数据库
                //void createNewDatabase()
                //{
                //    SQLiteConnection.CreateFile("MyDatabase.sqlite");
                //}

                //创建一个连接到指定数据库
                //void connectToDatabase()
                //{
                //    m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                //    m_dbConnection.Open();
                //}

                ////在指定数据库中创建一个table
                //void createTable()
                //{
                //    string sql = "create table highscores (name varchar(20), score int)";
                //    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                //    command.ExecuteNonQuery();
                //}

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
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                   int i= command.ExecuteNonQuery();
                   return i;
                }

                //使用sql查询语句，并显示结果
                public static List<TaskClass> GetTastList()
                {

                    string sql = "select * from Task order by dtStart desc";
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    List<TaskClass> taskList = new List<TaskClass>();
                    while (reader.Read())
                    {
                        Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
                        TaskClass task = new TaskClass();
                        task.taskid = reader["taskid"].ToString();
                        task.orderNumber = int.Parse(reader["orderNumber"].ToString());
                        task.taskName = reader["taskName"].ToString();
                        task.dtStart =DateTime.Parse(reader["dtStart"].ToString());
                        task.dtEnd =DateTime.Parse(reader["dtEnd"].ToString());
                        task.progresss =double.Parse(reader["progresss"].ToString());
                        taskList.Add(task);
                    }
                    return taskList;
                }

                public static DataTable ReadTaskData()
                {
                    List<TaskClass> taskList=GetTastList();

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
