namespace Speech_Demo
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent ()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.ofdASRFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTTSStart = new System.Windows.Forms.Button();
            this.tboxTTSText = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdASRFile
            // 
            this.ofdASRFile.Filter = "音频文件(*.pcm;*.wav;*.amr)|*.pcm;*.wav;*.amr";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnTTSStart);
            this.groupBox2.Controls.Add(this.tboxTTSText);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 270);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "鲍鱼年龄预测";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "训练数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTTSStart
            // 
            this.btnTTSStart.Location = new System.Drawing.Point(208, 241);
            this.btnTTSStart.Name = "btnTTSStart";
            this.btnTTSStart.Size = new System.Drawing.Size(75, 23);
            this.btnTTSStart.TabIndex = 1;
            this.btnTTSStart.Text = "播报结果";
            this.btnTTSStart.UseVisualStyleBackColor = true;
            this.btnTTSStart.Click += new System.EventHandler(this.btnTTSStart_Click);
            // 
            // tboxTTSText
            // 
            this.tboxTTSText.Location = new System.Drawing.Point(6, 64);
            this.tboxTTSText.Multiline = true;
            this.tboxTTSText.Name = "tboxTTSText";
            this.tboxTTSText.Size = new System.Drawing.Size(277, 171);
            this.tboxTTSText.TabIndex = 0;
            this.tboxTTSText.Text = " ";
            this.tboxTTSText.TextChanged += new System.EventHandler(this.tboxTTSText_TextChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 294);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "语音演示程序";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog ofdASRFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTTSStart;
        private System.Windows.Forms.TextBox tboxTTSText;
        private System.Windows.Forms.Button button1;
    }
}

