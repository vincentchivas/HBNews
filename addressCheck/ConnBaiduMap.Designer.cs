namespace addressCheck
{
    partial class ConnBaiduMap
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
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.btnGetxml = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtValues = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAddr
            // 
            this.txtAddr.Location = new System.Drawing.Point(99, 14);
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Size = new System.Drawing.Size(316, 21);
            this.txtAddr.TabIndex = 0;
            // 
            // btnGetxml
            // 
            this.btnGetxml.Location = new System.Drawing.Point(431, 12);
            this.btnGetxml.Name = "btnGetxml";
            this.btnGetxml.Size = new System.Drawing.Size(75, 23);
            this.btnGetxml.TabIndex = 1;
            this.btnGetxml.Text = "获取xml";
            this.btnGetxml.UseVisualStyleBackColor = true;
            this.btnGetxml.Click += new System.EventHandler(this.btnGetxml_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(522, 12);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "解析";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSource);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 800);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "获取xml";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(6, 20);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(688, 700);
            this.txtSource.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtValues);
            this.groupBox2.Location = new System.Drawing.Point(718, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(700, 800);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "获取值";
            // 
            // txtValues
            // 
            this.txtValues.Location = new System.Drawing.Point(6, 20);
            this.txtValues.Multiline = true;
            this.txtValues.Name = "txtValues";
            this.txtValues.Size = new System.Drawing.Size(688, 700);
            this.txtValues.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "输入地址：";
            // 
            // ConnBaiduMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(953, 426);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnGetxml);
            this.Controls.Add(this.txtAddr);
            this.Name = "ConnBaiduMap";
            this.Text = "ConnBaiduMap";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddr;
        private System.Windows.Forms.Button btnGetxml;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtValues;
        private System.Windows.Forms.Label label1;
    }
}