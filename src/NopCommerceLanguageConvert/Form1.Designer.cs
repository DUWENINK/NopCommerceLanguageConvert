namespace NopCommerceLanguageConvert
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ConvertToChinese = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ConvertToChinese
            // 
            this.ConvertToChinese.Location = new System.Drawing.Point(139, 144);
            this.ConvertToChinese.Name = "ConvertToChinese";
            this.ConvertToChinese.Size = new System.Drawing.Size(113, 23);
            this.ConvertToChinese.TabIndex = 0;
            this.ConvertToChinese.Text = "转换成简体中文";
            this.ConvertToChinese.UseVisualStyleBackColor = true;
            this.ConvertToChinese.Click += new System.EventHandler(this.ConvertToChinese_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(70, 117);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(291, 21);
            this.txtPath.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 343);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.ConvertToChinese);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConvertToChinese;
        private System.Windows.Forms.TextBox txtPath;
    }
}

