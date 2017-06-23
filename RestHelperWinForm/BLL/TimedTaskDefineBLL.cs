using KMHC.CTMS.DAL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestHelperUI.BLL
{
    class TimedTaskDefineBLL
    {   /// <summary>
        /// 判断是否满足时间条件发送任务
        /// </summary>
        /// <returns></returns>
        private static bool IsSend(CTMS_TK_TIMEDTASKDEFINE model)
        {
            bool flag = false;

            var nowDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan ts = Convert.ToDateTime(model.ENDDATE) - Convert.ToDateTime(model.STARTDATE);

            int yearDiff = Convert.ToDateTime(model.ENDDATE).Year - Convert.ToDateTime(model.STARTDATE).Year;
            int monthDiff = Convert.ToDateTime(model.ENDDATE).Month - Convert.ToDateTime(model.STARTDATE).Month;
            int monthSumDiff = yearDiff * 12 + monthDiff;//相差总月份

            DateTime doTime = DateTime.Now;
            switch ((int)model.TIMEDTYPE)
            {
                #region  按天
                case 1:
                    if (model.DAYORWORKDAY == 1) //判断工作日
                    {
                        var week = DateTime.Now.DayOfWeek.ToString().ToLower();
                        flag = (week != "saturday" && week != "sunday");
                    }
                    else //按照每隔几天
                    {
                        //相隔时间不能超过开始时间跟结束时间差
                        for (int i = (int)model.HOWLONGDAY; i <= ts.Days; i += (int)model.HOWLONGDAY)
                        {
                            doTime = Convert.ToDateTime(model.STARTDATE.AddDays(i).ToShortDateString());

                            if (nowDate == doTime)
                            //当天时间 == 隔了几天
                            {
                                flag = true;
                                break;
                            }
                            if (nowDate < doTime)
                            //判断当前日期小于了所隔天数
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                    break; //按天
                #endregion
                #region 按周
                case 2:
                    for (int i = (int)model.HOWLONGWEEKS; i < (ts.Days) / 7; i += (int)model.HOWLONGWEEKS)
                    {
                        DateTime[] dtWeek = DatesIncludeDay(model.STARTDATE.AddDays(7 * i));
                        if (nowDate >= dtWeek[0] && nowDate <= dtWeek[1])
                        {
                            if ((int)nowDate.DayOfWeek == model.DAYOFWEEK) //星期几 相同才执行
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (nowDate < dtWeek[0]) //区间超过了周范围
                        {
                            break;
                        }
                    }
                    break; //按周
                #endregion
                #region 按月
                case 3:
                    for (int i = (int)model.HOWLONGMONTH; i < monthSumDiff; i += (int)model.HOWLONGMONTH)
                    {
                        if (model.HOWLONGMONTHWEEKDAY == 0) // 每多少月多少日   模式
                        {
                            var maxMonthDay = LastDayOfMonth(Convert.ToDateTime(model.STARTDATE.AddMonths(i).Year + "-" + model.STARTDATE.AddMonths(i).Month + "-01")).Day;
                            if (maxMonthDay >= model.HOWLONGMONTHDAY) //判断是否超出每月的最大一天
                            {
                                doTime = Convert.ToDateTime(model.STARTDATE.AddMonths(i).Year + "-" + model.STARTDATE.AddMonths(i).Month + "-" + ((model.HOWLONGMONTHDAY == 0) ? maxMonthDay : model.HOWLONGMONTHDAY));
                            }
                        }
                        else
                        {
                            doTime = Convert.ToDateTime(model.STARTDATE.AddMonths(i).Year + "-" + model.STARTDATE.AddMonths(i).Month + "-" +
                                                   DayOfMonthWeek(Convert.ToDateTime(model.STARTDATE.AddMonths(i).Year + "-" + model.STARTDATE.AddMonths(i).Month + "-01"), (int)model.HOWLONGMONTHWEEK, (int)model.HOWLONGMONTHWEEKDAY).Day);
                        }
                        if (nowDate == doTime)
                        {
                            flag = true;
                            break;
                        }
                        else if (nowDate <= doTime)
                        {
                            break;
                        }
                    }
                    break; //按月
                #endregion
                #region 按年
                case 4:
                    if (model.HOWLONGYEARWEEKDAY == 0) //每年的几月几日模式
                    {
                        doTime = Convert.ToDateTime(nowDate.Year + "-" + model.HOWLONGYEARMONTH + "-" +
                                                    (model.HOWLONGYEARDAY == 0
                                                        ? LastDayOfMonth(
                                                            Convert.ToDateTime(nowDate.Year + "-" +
                                                                               model.HOWLONGYEARMONTH + "-1")).Day
                                                        : model.HOWLONGYEARDAY));
                    }
                    else
                    {
                        var tempDay = DayOfMonthWeek(Convert.ToDateTime(nowDate.Year + "-" + model.HOWLONGYEARMONTH + "-1"), (int)model.HOWLONGYEARWEEK, (int)model.HOWLONGYEARWEEKDAY).Day;
                        doTime = Convert.ToDateTime(nowDate.Year + "-" + model.HOWLONGYEARMONTH + "-" + tempDay);
                    }
                    flag = nowDate == doTime;
                    break;
                #endregion
                default:
                    flag = false;
                    break;
            }
            return flag;
        }



        #region 通用日期转换方法
        /// <summary>
        /// 传入某一天，输出这一周的起始日期
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static DateTime[] DatesIncludeDay(DateTime dt)
        {
            DateTime[] dts = new DateTime[2];
            int dayofweek = DayOfWeek(dt);
            dts[0] = dt.AddDays(1 - dayofweek);
            dts[1] = dt.AddDays(7 - dayofweek);
            return dts;
        }

        /// <summary>
        /// 计算星期几，转换为数字
        /// </summary>
        /// <param name="dt">某天的日期</param>
        /// <returns></returns>
        private static int DayOfWeek(DateTime dt)
        {
            string strDayOfWeek = dt.DayOfWeek.ToString().ToLower();
            int intDayOfWeek = 0;
            switch (strDayOfWeek)
            {
                case "monday":
                    intDayOfWeek = 1;
                    break;
                case "tuesday":
                    intDayOfWeek = 2;
                    break;
                case "wednesday":
                    intDayOfWeek = 3;
                    break;
                case "thursday":
                    intDayOfWeek = 4;
                    break;
                case "friday":
                    intDayOfWeek = 5;
                    break;
                case "saturday":
                    intDayOfWeek = 6;
                    break;
                case "sunday":
                    intDayOfWeek = 7;
                    break;
            }
            return intDayOfWeek;
        }

        /// <summary>
        /// 取得某月的第一天
        /// </summary>
        /// <param name="datetime">要取得月份第一天的时间</param>
        /// <returns></returns>
        private DateTime FirstDayOfMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day);
        }

        /// <summary>
        /// 取得某月的最后一天
        /// </summary>
        /// <param name="datetime">要取得月份最后一天的时间</param>
        /// <returns></returns>
        private static DateTime LastDayOfMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// 取得这个月一共有多少周
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        private int CountWeekOfMonth(DateTime day)
        {
            //WeekStart
            //周一至周日 为一周
            DateTime firstofMonth = Convert.ToDateTime(day.Date.Year + "-" + day.Date.Month + "-" + 1);
            int i = (int)firstofMonth.Date.DayOfWeek == 0 ? 7 : (int)firstofMonth.Date.DayOfWeek;
            int totalDay = LastDayOfMonth(firstofMonth).Day - (8 - i);
            int countWeek = 1;
            if (totalDay % 7 == 0)
            {
                countWeek += totalDay / 7;
            }
            else
            {
                countWeek += totalDay / 7 + 1;
            }
            return countWeek;
        }

        private int WeekOfMonth(DateTime day, int WeekStart)
        {
            //WeekStart
            //1表示 周一至周日 为一周
            //2表示 周日至周六 为一周
            DateTime firstofMonth = Convert.ToDateTime(day.Date.Year + "-" + day.Date.Month + "-" + 1);
            int i = (int)firstofMonth.Date.DayOfWeek;
            if (i == 0)
            {
                i = 7;
            }

            if (WeekStart == 1)
            {
                return (day.Date.Day + i - 2) / 7 + 1;
            }
            if (WeekStart == 2)
            {
                return (day.Date.Day + i - 1) / 7;

            }
            return 0;
            //错误返回值0
        }

        /// <summary>
        ///  取出这个年月下的第几个周几
        /// </summary>
        /// <param name="dtTime"></param>
        /// <param name="j">第几个（1-4，5为最后一个）</param>
        /// <param name="weekNum">星期一到七</param>
        /// <returns></returns>
        private static DateTime DayOfMonthWeek(DateTime dtTime, int j, int weekNum)
        {
            DateTime firstofMonth = Convert.ToDateTime(dtTime.Date.Year + "-" + dtTime.Date.Month + "-" + 1);
            int dayOfWeek = (int)firstofMonth.Date.DayOfWeek;  //这个月第一天是周几
            dayOfWeek = dayOfWeek == 0 ? 7 : dayOfWeek;
            int finalDay = 0;

            if (j == 0) //最后一个
            {
                DateTime lastMonthDay = LastDayOfMonth(dtTime);
                int dayOfLastWeek = (int)lastMonthDay.Date.DayOfWeek == 0 ? 7 : (int)lastMonthDay.Date.DayOfWeek;

                if (dayOfLastWeek - weekNum > 0)
                {
                    finalDay = lastMonthDay.AddDays(weekNum - dayOfLastWeek).Day;
                }
                else if (dayOfLastWeek - weekNum < 0)
                {
                    finalDay = lastMonthDay.AddDays(-7).AddDays(weekNum - dayOfLastWeek).Day;
                }
                else
                {
                    finalDay = lastMonthDay.Day;
                }
            }
            else if (j <= 4)
            {
                //此处可能有bug。。。。    ----林德力
                if (dayOfWeek - weekNum > 0)
                {
                    finalDay = j * 7 - (dayOfWeek - weekNum) + 1;
                }
                else
                {
                    finalDay = (j - 1) * 7 + weekNum - dayOfWeek + 1;
                }
                //finalDay = (j - 1) * 7 - (dayOfWeek - weekNum - 1);
            }
            return Convert.ToDateTime(dtTime.Date.Year + "-" + dtTime.Date.Month + "-" + finalDay);
        }

        #endregion
    }
}
