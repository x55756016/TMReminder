﻿using RestHelperUI.DBUtility.SQLite.SQLiteSamples;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RestHelperUI
{
    public partial class AddTaskForm : Form
    {
        public delegate void BoilerLogHandler(string status);
        public event BoilerLogHandler addComplete;
        public TaskClass NewTask;
        private int ordernumber = 0;

        private bool isNewTask=false;
        public AddTaskForm()
        {
            InitializeComponent();           
        }

        private void AddTaskForm_Load(object sender, EventArgs e)
        {
            if (NewTask == null)
            {
                isNewTask = true;
                btnComplete.Visible = false;
                NewTask = new TaskClass();
                ordernumber = TaskDBHelper.GetMaxNumber();
                txtorderNumber.Text = ordernumber.ToString();
                dtStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0);
                dtEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 30, 0);
            }else
            {
                ordernumber = NewTask.orderNumber;
                txtorderNumber.Text = ordernumber.ToString();
                txttaskName.Text = NewTask.taskName;
                dtStart.Value = NewTask.dtStart;
                dtEnd.Value = NewTask.dtEnd;
                txtprogresss.Text = NewTask.progresss.ToString();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                NewTask.orderNumber = ordernumber;
                NewTask.taskName = txttaskName.Text;
                NewTask.dtStart = dtStart.Value;
                NewTask.dtEnd = dtEnd.Value;
                NewTask.taskContent = txtTaskContent.Text;
                double progresss = 0;
                double.TryParse(txtprogresss.Text, out progresss);
                NewTask.progresss = progresss;
                //添加
                if (isNewTask)
                {
                    NewTask.taskid = Guid.NewGuid().ToString();

                    if (TaskDBHelper.AddTask(NewTask) > 0)
                    {
                        //MessageBox.Show("添加任务成功！");
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("添加任务失败！");
                    }
                }
                else
                {
                    //更新
                    if (TaskDBHelper.UpdateTask(NewTask) > 0)
                    {
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("更新任务失败！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (addComplete != null)
                {
                    addComplete("");
                }
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                txtprogresss.Text = "100";
                NewTask.orderNumber = ordernumber;
                NewTask.progresss = 100;
                if (TaskDBHelper.UpdateTask(NewTask) > 0)
                {
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("更新任务失败！");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (addComplete != null)
                {
                    addComplete("");
                }
            }
        }

    }
}
