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
            this.btnInitialReader = new System.Windows.Forms.Button();
            this.btnReading = new System.Windows.Forms.Button();
            this.btnCloseReader = new System.Windows.Forms.Button();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDoTest
            // 
            this.btnDoTest.Location = new System.Drawing.Point(12, 12);
            this.btnDoTest.Name = "btnDoTest";
            this.btnDoTest.Size = new System.Drawing.Size(146, 43);
            this.btnDoTest.TabIndex = 0;
            this.btnDoTest.Text = "DoTest";
            this.btnDoTest.UseVisualStyleBackColor = true;
            this.btnDoTest.Click += new System.EventHandler(this.btnDoTest_Click);
            // 
            // btnInitialReader
            // 
            this.btnInitialReader.Location = new System.Drawing.Point(12, 145);
            this.btnInitialReader.Name = "btnInitialReader";
            this.btnInitialReader.Size = new System.Drawing.Size(146, 43);
            this.btnInitialReader.TabIndex = 1;
            this.btnInitialReader.Text = "初始化读卡器";
            this.btnInitialReader.UseVisualStyleBackColor = true;
            this.btnInitialReader.Click += new System.EventHandler(this.btnInitialReader_Click);
            // 
            // btnReading
            // 
            this.btnReading.Location = new System.Drawing.Point(164, 156);
            this.btnReading.Name = "btnReading";
            this.btnReading.Size = new System.Drawing.Size(146, 43);
            this.btnReading.TabIndex = 2;
            this.btnReading.Text = "读卡";
            this.btnReading.UseVisualStyleBackColor = true;
            this.btnReading.Click += new System.EventHandler(this.btnReading_Click);
            // 
            // btnCloseReader
            // 
            this.btnCloseReader.Location = new System.Drawing.Point(316, 145);
            this.btnCloseReader.Name = "btnCloseReader";
            this.btnCloseReader.Size = new System.Drawing.Size(146, 43);
            this.btnCloseReader.TabIndex = 3;
            this.btnCloseReader.Text = "关闭读卡器";
            this.btnCloseReader.UseVisualStyleBackColor = true;
            this.btnCloseReader.Click += new System.EventHandler(this.btnCloseReader_Click);
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(69, 113);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(63, 21);
            this.txtSerialNumber.TabIndex = 4;
            this.txtSerialNumber.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "串口号：";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 352);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSerialNumber);
            this.Controls.Add(this.btnCloseReader);
            this.Controls.Add(this.btnReading);
            this.Controls.Add(this.btnInitialReader);
            this.Controls.Add(this.btnDoTest);
            this.Name = "main";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDoTest;
        private System.Windows.Forms.Button btnInitialReader;
        private System.Windows.Forms.Button btnReading;
        private System.Windows.Forms.Button btnCloseReader;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label label1;
    }
}

