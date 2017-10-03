namespace RestHelperUI
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msgTxt = new System.Windows.Forms.TextBox();
            this.btOK = new System.Windows.Forms.Button();
            this.btNo = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnGetTask = new System.Windows.Forms.Button();
            this.btnCompleteTask = new System.Windows.Forms.Button();
            this.btnExp = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnGetAllTask = new System.Windows.Forms.Button();
            this.panelHead = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.panelfoot = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_Task = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.dtDotask = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1.SuspendLayout();
            this.panelHead.SuspendLayout();
            this.panelfoot.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panel_Task.SuspendLayout();
            this.panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDotask)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "办公室健康助手";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem,
            this.查看ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 查看ToolStripMenuItem
            // 
            this.查看ToolStripMenuItem.Name = "查看ToolStripMenuItem";
            this.查看ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.查看ToolStripMenuItem.Text = "查看";
            this.查看ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // msgTxt
            // 
            this.msgTxt.BackColor = System.Drawing.Color.White;
            this.msgTxt.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msgTxt.ForeColor = System.Drawing.Color.Red;
            this.msgTxt.Location = new System.Drawing.Point(4, 11);
            this.msgTxt.Multiline = true;
            this.msgTxt.Name = "msgTxt";
            this.msgTxt.ReadOnly = true;
            this.msgTxt.Size = new System.Drawing.Size(544, 54);
            this.msgTxt.TabIndex = 1;
            this.msgTxt.Text = "警告：已工作2小时，喝水，休息一会，预防颈椎病，慢性筋骨病";
            // 
            // btOK
            // 
            this.btOK.Enabled = false;
            this.btOK.Location = new System.Drawing.Point(428, 39);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(189, 33);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "已休息(2小时后再提醒)";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btNo
            // 
            this.btNo.Enabled = false;
            this.btNo.Location = new System.Drawing.Point(206, 39);
            this.btNo.Name = "btNo";
            this.btNo.Size = new System.Drawing.Size(190, 33);
            this.btNo.TabIndex = 2;
            this.btNo.Text = "忙碌(10分钟后再提醒我)";
            this.btNo.UseVisualStyleBackColor = true;
            this.btNo.Click += new System.EventHandler(this.btNo_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 16);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "设为开机自启动";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(423, 71);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(90, 33);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "新建待办任务";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnGetTask
            // 
            this.btnGetTask.Location = new System.Drawing.Point(3, 71);
            this.btnGetTask.Name = "btnGetTask";
            this.btnGetTask.Size = new System.Drawing.Size(93, 31);
            this.btnGetTask.TabIndex = 2;
            this.btnGetTask.Text = "待办任务";
            this.btnGetTask.UseVisualStyleBackColor = true;
            this.btnGetTask.Click += new System.EventHandler(this.btnGetTask_Click);
            // 
            // btnCompleteTask
            // 
            this.btnCompleteTask.Location = new System.Drawing.Point(102, 71);
            this.btnCompleteTask.Name = "btnCompleteTask";
            this.btnCompleteTask.Size = new System.Drawing.Size(98, 31);
            this.btnCompleteTask.TabIndex = 2;
            this.btnCompleteTask.Text = "已办任务";
            this.btnCompleteTask.UseVisualStyleBackColor = true;
            this.btnCompleteTask.Click += new System.EventHandler(this.btnCompleteTask_Click);
            // 
            // btnExp
            // 
            this.btnExp.Location = new System.Drawing.Point(310, 71);
            this.btnExp.Name = "btnExp";
            this.btnExp.Size = new System.Drawing.Size(98, 31);
            this.btnExp.TabIndex = 2;
            this.btnExp.Text = "导出";
            this.btnExp.UseVisualStyleBackColor = true;
            this.btnExp.Click += new System.EventHandler(this.btnExp_Click);
            // 
            // btnGetAllTask
            // 
            this.btnGetAllTask.Location = new System.Drawing.Point(206, 71);
            this.btnGetAllTask.Name = "btnGetAllTask";
            this.btnGetAllTask.Size = new System.Drawing.Size(98, 31);
            this.btnGetAllTask.TabIndex = 2;
            this.btnGetAllTask.Text = "全部任务";
            this.btnGetAllTask.UseVisualStyleBackColor = true;
            this.btnGetAllTask.Click += new System.EventHandler(this.btnGetAllTask_Click);
            // 
            // panelHead
            // 
            this.panelHead.Controls.Add(this.button9);
            this.panelHead.Controls.Add(this.btnNew);
            this.panelHead.Controls.Add(this.msgTxt);
            this.panelHead.Controls.Add(this.btnGetTask);
            this.panelHead.Controls.Add(this.btnCompleteTask);
            this.panelHead.Controls.Add(this.btnGetAllTask);
            this.panelHead.Controls.Add(this.btnExp);
            this.panelHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHead.Location = new System.Drawing.Point(0, 0);
            this.panelHead.Name = "panelHead";
            this.panelHead.Size = new System.Drawing.Size(653, 117);
            this.panelHead.TabIndex = 7;
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button9.ForeColor = System.Drawing.Color.Red;
            this.button9.Location = new System.Drawing.Point(554, 11);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(78, 54);
            this.button9.TabIndex = 3;
            this.button9.Text = "点我预防筋骨病";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 563);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 26);
            this.button7.TabIndex = 0;
            this.button7.Text = "登录";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // panelfoot
            // 
            this.panelfoot.Controls.Add(this.btOK);
            this.panelfoot.Controls.Add(this.btNo);
            this.panelfoot.Controls.Add(this.checkBox1);
            this.panelfoot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelfoot.Location = new System.Drawing.Point(0, 501);
            this.panelfoot.Name = "panelfoot";
            this.panelfoot.Size = new System.Drawing.Size(653, 100);
            this.panelfoot.TabIndex = 8;
            // 
            // panelLeft
            // 
            this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeft.Controls.Add(this.button8);
            this.panelLeft.Controls.Add(this.button6);
            this.panelLeft.Controls.Add(this.button5);
            this.panelLeft.Controls.Add(this.button4);
            this.panelLeft.Controls.Add(this.button7);
            this.panelLeft.Controls.Add(this.button3);
            this.panelLeft.Controls.Add(this.button2);
            this.panelLeft.Controls.Add(this.button1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(129, 601);
            this.panelLeft.TabIndex = 7;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(12, 348);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 26);
            this.button8.TabIndex = 0;
            this.button8.Text = "每日一歌";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 297);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 26);
            this.button6.TabIndex = 0;
            this.button6.Text = "热点新闻";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 242);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 26);
            this.button5.TabIndex = 0;
            this.button5.Text = "好茶推荐";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 186);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 26);
            this.button4.TabIndex = 0;
            this.button4.Text = "月老红线";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 129);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 26);
            this.button3.TabIndex = 0;
            this.button3.Text = "工作机会";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 26);
            this.button2.TabIndex = 0;
            this.button2.Text = "人脉圈子";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "待办任务";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel_Task
            // 
            this.panel_Task.Controls.Add(this.panelBody);
            this.panel_Task.Controls.Add(this.panelHead);
            this.panel_Task.Controls.Add(this.panelfoot);
            this.panel_Task.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Task.Location = new System.Drawing.Point(129, 0);
            this.panel_Task.Name = "panel_Task";
            this.panel_Task.Size = new System.Drawing.Size(653, 601);
            this.panel_Task.TabIndex = 7;
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.dtDotask);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 117);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(653, 384);
            this.panelBody.TabIndex = 9;
            // 
            // dtDotask
            // 
            this.dtDotask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDotask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDotask.Location = new System.Drawing.Point(0, 0);
            this.dtDotask.Name = "dtDotask";
            this.dtDotask.ReadOnly = true;
            this.dtDotask.Size = new System.Drawing.Size(653, 384);
            this.dtDotask.TabIndex = 7;
            this.dtDotask.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDotask_CellClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 601);
            this.Controls.Add(this.panel_Task);
            this.Controls.Add(this.panelLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "今日待办事项";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelHead.ResumeLayout(false);
            this.panelHead.PerformLayout();
            this.panelfoot.ResumeLayout(false);
            this.panelfoot.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panel_Task.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtDotask)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.TextBox msgTxt;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btNo;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripMenuItem 查看ToolStripMenuItem;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnGetTask;
        private System.Windows.Forms.Button btnCompleteTask;
        private System.Windows.Forms.Button btnExp;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnGetAllTask;
        private System.Windows.Forms.Panel panelHead;
        private System.Windows.Forms.Panel panelfoot;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panel_Task;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.DataGridView dtDotask;
    }
}

