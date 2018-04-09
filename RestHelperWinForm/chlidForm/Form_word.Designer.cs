namespace RestHelperUI.chlidForm
{
    partial class Form_word
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnWrongWord = new System.Windows.Forms.Button();
            this.btnPractise = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 33);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加单词";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(144, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "开始记单词";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnWrongWord
            // 
            this.btnWrongWord.Location = new System.Drawing.Point(354, 12);
            this.btnWrongWord.Name = "btnWrongWord";
            this.btnWrongWord.Size = new System.Drawing.Size(75, 23);
            this.btnWrongWord.TabIndex = 1;
            this.btnWrongWord.Text = "我的错词库";
            this.btnWrongWord.UseVisualStyleBackColor = true;
            this.btnWrongWord.Click += new System.EventHandler(this.btnWrongWord_Click);
            // 
            // btnPractise
            // 
            this.btnPractise.Location = new System.Drawing.Point(258, 12);
            this.btnPractise.Name = "btnPractise";
            this.btnPractise.Size = new System.Drawing.Size(75, 23);
            this.btnPractise.TabIndex = 1;
            this.btnPractise.Text = "顺序练习";
            this.btnPractise.UseVisualStyleBackColor = true;
            this.btnPractise.Click += new System.EventHandler(this.btnPractise_Click);
            // 
            // Form_word
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 57);
            this.Controls.Add(this.btnPractise);
            this.Controls.Add(this.btnWrongWord);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnAdd);
            this.Name = "Form_word";
            this.Text = "Form_word";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_word_FormClosing);
            this.Load += new System.EventHandler(this.Form_word_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnWrongWord;
        private System.Windows.Forms.Button btnPractise;
    }
}