using RestHelperUI.DBUtility.SQLite.SQLiteSamples;
using RestHelperUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RestHelperUI.chlidForm
{
    public partial class DoTaskForm : Form
    {
        private int maxTime = 600;//s
        private Form1 fatherForm;
        private TaskClass Taskobj;
        public DoTaskForm(Form1 form, int ordernumber)
        {
            fatherForm = form;
            InitializeComponent();
            loadTask(ordernumber);
        }
        private void loadTask(int ordernumber)
        {
            Taskobj = TaskDAL.GetTastByOrderNumber(ordernumber);
            txtorderNumber.Text = Taskobj.orderNumber.ToString();
            txttaskName.Text = Taskobj.taskName;
            dtStart.Value = Taskobj.dtStart;
            dtEnd.Value = Taskobj.dtEnd;
            txtprogresss.Text = Taskobj.progresss.ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            maxTime = maxTime - 1;
            ShowNextStep(maxTime);
            if (maxTime <= 0)
            {
                timer1.Stop();
            }
        }

        private void ShowNextStep(int maxTime)
        {
            labelName.Text = "任务执行倒计时中，" + " 剩余：" + maxTime + " 秒";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.fatherForm.Show();
            Form_congratulate form = new Form_congratulate();
            form.TopMost = true;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.fatherForm.Show();
        }

        private void DoTaskForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                double progresss = 0;
                double.TryParse(txtprogresss.Text, out progresss);
                Taskobj.progresss = progresss;

                    //更新
                if (TaskDAL.UpdateTask(Taskobj) > 0)
                    {
                        MessageBox.Show("更新任务进度成功！");
                    }
                    else
                    {
                        MessageBox.Show("更新任务失败！");
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
