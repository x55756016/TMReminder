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
            this.dtDotask = new System.Windows.Forms.DataGridView();
            this.btnCompleteTask = new System.Windows.Forms.Button();
            this.btnExp = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnGetAllTask = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
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
            this.notifyIcon1.Text = "notifyIcon1";
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
            this.查看ToolStripMenuItem.Click += new System.EventHandler(this.查看ToolStripMenuItem_Click);
            // 
            // msgTxt
            // 
            this.msgTxt.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msgTxt.ForeColor = System.Drawing.Color.Goldenrod;
            this.msgTxt.Location = new System.Drawing.Point(27, 8);
            this.msgTxt.Multiline = true;
            this.msgTxt.Name = "msgTxt";
            this.msgTxt.ReadOnly = true;
            this.msgTxt.Size = new System.Drawing.Size(748, 37);
            this.msgTxt.TabIndex = 1;
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(363, 517);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(137, 33);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "已休息";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btNo
            // 
            this.btNo.Location = new System.Drawing.Point(549, 517);
            this.btNo.Name = "btNo";
            this.btNo.Size = new System.Drawing.Size(216, 33);
            this.btNo.TabIndex = 2;
            this.btNo.Text = "忙着呢，10分钟后再提醒我";
            this.btNo.UseVisualStyleBackColor = true;
            this.btNo.Click += new System.EventHandler(this.btNo_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(27, 534);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 16);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "设为开机自启动";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(151, 517);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(137, 33);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "新建任务";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnGetTask
            // 
            this.btnGetTask.Location = new System.Drawing.Point(30, 53);
            this.btnGetTask.Name = "btnGetTask";
            this.btnGetTask.Size = new System.Drawing.Size(93, 31);
            this.btnGetTask.TabIndex = 2;
            this.btnGetTask.Text = "待办任务";
            this.btnGetTask.UseVisualStyleBackColor = true;
            this.btnGetTask.Click += new System.EventHandler(this.btnGetTask_Click);
            // 
            // dtDotask
            // 
            this.dtDotask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDotask.Location = new System.Drawing.Point(27, 98);
            this.dtDotask.Name = "dtDotask";
            this.dtDotask.Size = new System.Drawing.Size(738, 413);
            this.dtDotask.TabIndex = 6;
            // 
            // btnCompleteTask
            // 
            this.btnCompleteTask.Location = new System.Drawing.Point(129, 53);
            this.btnCompleteTask.Name = "btnCompleteTask";
            this.btnCompleteTask.Size = new System.Drawing.Size(98, 31);
            this.btnCompleteTask.TabIndex = 2;
            this.btnCompleteTask.Text = "已办任务";
            this.btnCompleteTask.UseVisualStyleBackColor = true;
            this.btnCompleteTask.Click += new System.EventHandler(this.btnCompleteTask_Click);
            // 
            // btnExp
            // 
            this.btnExp.Location = new System.Drawing.Point(337, 53);
            this.btnExp.Name = "btnExp";
            this.btnExp.Size = new System.Drawing.Size(98, 31);
            this.btnExp.TabIndex = 2;
            this.btnExp.Text = "导出";
            this.btnExp.UseVisualStyleBackColor = true;
            this.btnExp.Click += new System.EventHandler(this.btnExp_Click);
            // 
            // btnGetAllTask
            // 
            this.btnGetAllTask.Location = new System.Drawing.Point(233, 53);
            this.btnGetAllTask.Name = "btnGetAllTask";
            this.btnGetAllTask.Size = new System.Drawing.Size(98, 31);
            this.btnGetAllTask.TabIndex = 2;
            this.btnGetAllTask.Text = "全部任务";
            this.btnGetAllTask.UseVisualStyleBackColor = true;
            this.btnGetAllTask.Click += new System.EventHandler(this.btnGetAllTask_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.dtDotask);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btNo);
            this.Controls.Add(this.btnExp);
            this.Controls.Add(this.btnGetAllTask);
            this.Controls.Add(this.btnCompleteTask);
            this.Controls.Add(this.btnGetTask);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.msgTxt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtDotask)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.DataGridView dtDotask;
        private System.Windows.Forms.Button btnCompleteTask;
        private System.Windows.Forms.Button btnExp;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnGetAllTask;
    }
}

