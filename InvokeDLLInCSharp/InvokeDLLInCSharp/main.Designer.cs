namespace InvokeDLLInCSharp
{
    partial class main
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
            this.btnDoTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDoTest
            // 
            this.btnDoTest.Location = new System.Drawing.Point(69, 73);
            this.btnDoTest.Name = "btnDoTest";
            this.btnDoTest.Size = new System.Drawing.Size(146, 43);
            this.btnDoTest.TabIndex = 0;
            this.btnDoTest.Text = "DoTest";
            this.btnDoTest.UseVisualStyleBackColor = true;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 352);
            this.Controls.Add(this.btnDoTest);
            this.Name = "main";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDoTest;
    }
}

