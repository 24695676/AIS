namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.browse_button = new System.Windows.Forms.Button();
            this.paths_comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(94, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 74);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // browse_button
            // 
            this.browse_button.Location = new System.Drawing.Point(133, 72);
            this.browse_button.Name = "browse_button";
            this.browse_button.Size = new System.Drawing.Size(75, 23);
            this.browse_button.TabIndex = 6;
            this.browse_button.Text = "瀏覽檔案";
            this.browse_button.UseVisualStyleBackColor = true;
            this.browse_button.Click += new System.EventHandler(this.browse_button_Click);
            // 
            // paths_comboBox
            // 
            this.paths_comboBox.FormattingEnabled = true;
            this.paths_comboBox.Location = new System.Drawing.Point(26, 25);
            this.paths_comboBox.Name = "paths_comboBox";
            this.paths_comboBox.Size = new System.Drawing.Size(294, 20);
            this.paths_comboBox.TabIndex = 7;
            this.paths_comboBox.SelectedIndexChanged += new System.EventHandler(this.paths_comboBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 244);
            this.Controls.Add(this.paths_comboBox);
            this.Controls.Add(this.browse_button);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button browse_button;
        private System.Windows.Forms.ComboBox paths_comboBox;
    }
}

