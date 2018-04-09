namespace RestHelperUI.chlidForm
{
    partial class Form_paperitemADD
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrdernumber = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtsentence = new System.Windows.Forms.TextBox();
            this.txtCword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtOrdernumber);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 48);
            this.panel1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "保存";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "序号：";
            // 
            // txtOrdernumber
            // 
            this.txtOrdernumber.Location = new System.Drawing.Point(152, 14);
            this.txtOrdernumber.Name = "txtOrdernumber";
            this.txtOrdernumber.Size = new System.Drawing.Size(32, 21);
            this.txtOrdernumber.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtsentence);
            this.panel3.Controls.Add(this.txtCword);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtEword);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(484, 124);
            this.panel3.TabIndex = 2;
            // 
            // txtsentence
            // 
            this.txtsentence.Location = new System.Drawing.Point(12, 72);
            this.txtsentence.Multiline = true;
            this.txtsentence.Name = "txtsentence";
            this.txtsentence.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtsentence.Size = new System.Drawing.Size(457, 40);
            this.txtsentence.TabIndex = 3;
            // 
            // txtCword
            // 
            this.txtCword.Location = new System.Drawing.Point(81, 30);
            this.txtCword.Multiline = true;
            this.txtCword.Name = "txtCword";
            this.txtCword.Size = new System.Drawing.Size(391, 22);
            this.txtCword.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "例句：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "中文解释：";
            // 
            // txtEword
            // 
            this.txtEword.Location = new System.Drawing.Point(57, 3);
            this.txtEword.Name = "txtEword";
            this.txtEword.Size = new System.Drawing.Size(325, 21);
            this.txtEword.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "单词：";
            // 
            // Form_paperitemADD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 172);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Form_paperitemADD";
            this.Text = "Form_paperitem";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_paperitemADD_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtsentence;
        private System.Windows.Forms.TextBox txtCword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrdernumber;

    }
}