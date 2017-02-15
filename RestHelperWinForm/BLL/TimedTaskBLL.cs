using RestHelperUI.DAL;
using RestHelperUI.DBUtility.SQLite.SQLiteSamples;
using RestHelperUI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestHelperUI.BLL
{
    class TimedTaskBLL
    {

        /// <summary>
        /// 轮询定时任务表
        /// </summary>
        public static void PollingTimeTask()
        {

            //DbContext _context = DbSessionFactory.GetCurrentDbContext();
            //1.取出需要执行的任务
            //DateTime minTime = Convert.ToDateTime(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " 00:00:00");
            DateTime maxTime = DateTime.Now;
            var list = TimedTaskDAL.GetTimeTastList();
            //2.执行
            foreach (var item in list)
            {
                try
                {
                    if (AddTaskFromTimeTask(item.MODELCODE, item.MESSAGEBODY))
                    {
                        //更新定时任务表
                        TimedTaskDAL.UpdateTimeTask(item.TIMEDTASKID);
                    }
                }
                catch (Exception ex)
                {
                    item.TASKSTATUS = "0";
                    LogHelper.WriteErrLog("执行定时任务出错:" + ex.Message + "," + ex.InnerException);
                }
            }
        }

        private static bool AddTaskFromTimeTask(string taskName, string taskContent)
        {
            TaskClass NewTask = new TaskClass();
            NewTask.orderNumber = TaskDAL.GetMaxNumber();
            NewTask.dtStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0);
            NewTask.dtEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 30, 0);
            NewTask.taskContent = taskContent;
            NewTask.progresss = 0;
            return (TaskDAL.AddTask(NewTask) > 0);
        }
    }
}
