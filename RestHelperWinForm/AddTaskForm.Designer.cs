﻿namespace RestHelperUI
{
    partial class AddTaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtprogresss = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTaskContent = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txttaskName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtorderNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtEnd);
            this.panel1.Controls.Add(this.dtStart);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtprogresss);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTaskContent);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txttaskName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtorderNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 488);
            this.panel1.TabIndex = 16;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(258, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtprogresss
            // 
            this.txtprogresss.Location = new System.Drawing.Point(101, 166);
            this.txtprogresss.Name = "txtprogresss";
            this.txtprogresss.Size = new System.Drawing.Size(100, 21);
            this.txtprogresss.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "进度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "结束时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "开始时间";
            // 
            // txtTaskContent
            // 
            this.txtTaskContent.Location = new System.Drawing.Point(23, 264);
            this.txtTaskContent.Multiline = true;
            this.txtTaskContent.Name = "txtTaskContent";
            this.txtTaskContent.Size = new System.Drawing.Size(407, 201);
            this.txtTaskContent.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "任务详情";
            // 
            // txttaskName
            // 
            this.txttaskName.Location = new System.Drawing.Point(101, 54);
            this.txttaskName.Name = "txttaskName";
            this.txttaskName.Size = new System.Drawing.Size(100, 21);
            this.txttaskName.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "任务名称";
            // 
            // txtorderNumber
            // 
            this.txtorderNumber.Location = new System.Drawing.Point(101, 17);
            this.txtorderNumber.Name = "txtorderNumber";
            this.txtorderNumber.Size = new System.Drawing.Size(100, 21);
            this.txtorderNumber.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "任务序号";
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(101, 86);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 21);
            this.dtStart.TabIndex = 29;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(101, 126);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(200, 21);
            this.dtEnd.TabIndex = 29;
            // 
            // AddTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 488);
            this.Controls.Add(this.panel1);
            this.Name = "AddTaskForm";
            this.Text = "AddTaskForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtprogresss;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTaskContent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txttaskName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtorderNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtStart;

    }
}