using RestHelperUI.DBUtility.SQLite.SQLiteSamples;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RestHelperUI
{    
    public partial class Form_Main
    {
        private void loadData()
        {
            dtDotask.Columns.Clear();

            DataGridViewButtonColumn col_btn_Dotask = new DataGridViewButtonColumn();
            col_btn_Dotask.HeaderText = "操作";
            col_btn_Dotask.Text = "开始执行";//加上这两个就能显示
            col_btn_Dotask.UseColumnTextForButtonValue = true;//
            dtDotask.Columns.Add(col_btn_Dotask);

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


            DataTable dt = TaskDAL.ReadTaskData(0);
            dtDotask.DataSource = dt;


            dtDotask.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dtDotask.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;  
            //dtDotask.Columns[1].FillWeight = 40;  

        }


        private void radioBtn_CheckedChange(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }
            switch (((RadioButton)sender).Text.ToString())
            {
                case "待办任务":
                    loadData();
                    break;
                case "已办任务":
                    DataTable dt = TaskDAL.ReadTaskData(1);
                    dtDotask.DataSource = dt;
                    break;
                case "全部任务":
                    DataTable dt2 = TaskDAL.ReadTaskData(2);
                    dtDotask.DataSource = dt2;
                    break;
                default:
                    loadData();
                    break;
            }
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
