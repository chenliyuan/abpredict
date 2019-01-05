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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tboxTTSText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPredictRt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tboxFileAddress = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.tboxFileAddress);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 270);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "鲍鱼年龄预测";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tboxTTSText);
            this.groupBox3.Location = new System.Drawing.Point(6, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(277, 91);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "预测数据";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // tboxTTSText
            // 
            this.tboxTTSText.Location = new System.Drawing.Point(6, 16);
            this.tboxTTSText.Multiline = true;
            this.tboxTTSText.Name = "tboxTTSText";
            this.tboxTTSText.ReadOnly = true;
            this.tboxTTSText.Size = new System.Drawing.Size(265, 69);
            this.tboxTTSText.TabIndex = 0;
            this.tboxTTSText.Text = " ";
            this.tboxTTSText.TextChanged += new System.EventHandler(this.tboxTTSText_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbPredictRt);
            this.groupBox1.Location = new System.Drawing.Point(6, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 108);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预测结果";
            // 
            // tbPredictRt
            // 
            this.tbPredictRt.Location = new System.Drawing.Point(6, 20);
            this.tbPredictRt.Multiline = true;
            this.tbPredictRt.Name = "tbPredictRt";
            this.tbPredictRt.ReadOnly = true;
            this.tbPredictRt.Size = new System.Drawing.Size(265, 82);
            this.tbPredictRt.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "训练数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(150, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(52, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "打开照片";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tboxFileAddress
            // 
            this.tboxFileAddress.Location = new System.Drawing.Point(6, 30);
            this.tboxFileAddress.Name = "tboxFileAddress";
            this.tboxFileAddress.Size = new System.Drawing.Size(138, 21);
            this.tboxFileAddress.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(208, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "预测播报";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog ofdASRFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tboxTTSText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tboxFileAddress;
        private System.Windows.Forms.TextBox tbPredictRt;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

