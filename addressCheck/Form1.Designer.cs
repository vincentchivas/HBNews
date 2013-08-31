namespace addressCheck
{
    partial class TEXT
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
            this.gbaddr = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvAddr = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeal = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnbaidu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gbaddr.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddr)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbaddr
            // 
            this.gbaddr.Controls.Add(this.panel1);
            this.gbaddr.Location = new System.Drawing.Point(12, 62);
            this.gbaddr.Name = "gbaddr";
            this.gbaddr.Size = new System.Drawing.Size(1600, 800);
            this.gbaddr.TabIndex = 0;
            this.gbaddr.TabStop = false;
            this.gbaddr.Text = "地址栏";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvAddr);
            this.panel1.Location = new System.Drawing.Point(6, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1580, 780);
            this.panel1.TabIndex = 0;
            // 
            // dgvAddr
            // 
            this.dgvAddr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAddr.Location = new System.Drawing.Point(0, 0);
            this.dgvAddr.Name = "dgvAddr";
            this.dgvAddr.RowTemplate.Height = 23;
            this.dgvAddr.Size = new System.Drawing.Size(1580, 780);
            this.dgvAddr.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnDeal);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 53);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // btnDeal
            // 
            this.btnDeal.BackColor = System.Drawing.Color.SkyBlue;
            this.btnDeal.Location = new System.Drawing.Point(192, 12);
            this.btnDeal.Name = "btnDeal";
            this.btnDeal.Size = new System.Drawing.Size(75, 23);
            this.btnDeal.TabIndex = 2;
            this.btnDeal.Text = "处理";
            this.btnDeal.UseVisualStyleBackColor = false;
            this.btnDeal.Click += new System.EventHandler(this.btnDeal_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(53, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(122, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(742, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnbaidu
            // 
            this.btnbaidu.Location = new System.Drawing.Point(742, 33);
            this.btnbaidu.Name = "btnbaidu";
            this.btnbaidu.Size = new System.Drawing.Size(80, 23);
            this.btnbaidu.TabIndex = 3;
            this.btnbaidu.Text = "showBaidu";
            this.btnbaidu.UseVisualStyleBackColor = true;
            this.btnbaidu.Click += new System.EventHandler(this.btnbaidu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // TEXT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(910, 467);
            this.Controls.Add(this.btnbaidu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbaddr);
            this.Name = "TEXT";
            this.Text = "地址测试";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbaddr.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddr)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbaddr;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvAddr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnbaidu;
        private System.Windows.Forms.Label label2;

    }
}

