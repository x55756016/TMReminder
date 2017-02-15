using RestHelperUI.DBUtility.SQLite.SQLiteSamples;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RestHelperUI
{    
    public partial class Form1
    {
        private void loadData()
        {
            dtDotask.Columns.Clear();
            DataTable dt = TaskDAL.ReadTaskData(0);
            dtDotask.DataSource = dt;


            DataGridViewButtonColumn col_btn_insert = new DataGridViewButtonColumn();
            col_btn_insert.HeaderText = "操作";
            col_btn_insert.Text = "更新进度";//加上这两个就能显示
            col_btn_insert.UseColumnTextForButtonValue = true;//
            dtDotask.Columns.Add(col_btn_insert);

            DataGridViewButtonColumn col_btn_delete = new DataGridViewButtonColumn();
            col_btn_delete.HeaderText = "操作";
            col_btn_delete.Text = "删除";//加上这两个就能显示
            col_btn_delete.UseColumnTextForButtonValue = true;//
            dtDotask.Columns.Add(col_btn_delete);
        }

        /// <summary>
        /// 查询待办任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetTask_Click(object sender, EventArgs e)
        {
            //DataTable dt = TaskDBHelper.ReadTaskData(0);
            //dtDotask.DataSource = dt;
            loadData();
        }
        /// <summary>
        /// 查询已办任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompleteTask_Click(object sender, EventArgs e)
        {
            DataTable dt = TaskDAL.ReadTaskData(1);
            dtDotask.DataSource = dt;
        }
        /// <summary>
        /// 查询所有任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetAllTask_Click(object sender, EventArgs e)
        {
            DataTable dt = TaskDAL.ReadTaskData(2);
            dtDotask.DataSource = dt;
        }
        /// <summary>
        /// 导出任务清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExp_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "任务报告" + DateTime.Now.ToString("yyyy-MM-dd");
            saveFileDialog1.Filter = "CSV文件|*.csv";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = dtDotask.DataSource as DataTable;
                CsvHelper.savecsv(dt, saveFileDialog1.FileName);
            }
        }
    }
}
