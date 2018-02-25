namespace WCFClt
{
    partial class MainWnd
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbNum1 = new System.Windows.Forms.TextBox();
            this.tbNum2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbOperation = new System.Windows.Forms.ComboBox();
            this.btnCompute = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDownloadFile = new System.Windows.Forms.Button();
            this.btnUploadFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(23, 32);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "WCF连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbNum1
            // 
            this.tbNum1.Location = new System.Drawing.Point(201, 34);
            this.tbNum1.Name = "tbNum1";
            this.tbNum1.Size = new System.Drawing.Size(100, 21);
            this.tbNum1.TabIndex = 1;
            this.tbNum1.Text = "1";
            // 
            // tbNum2
            // 
            this.tbNum2.Location = new System.Drawing.Point(201, 69);
            this.tbNum2.Name = "tbNum2";
            this.tbNum2.Size = new System.Drawing.Size(100, 21);
            this.tbNum2.TabIndex = 2;
            this.tbNum2.Text = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "第一个数";
            // 
            // cbOperation
            // 
            this.cbOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperation.FormattingEnabled = true;
            this.cbOperation.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.cbOperation.Location = new System.Drawing.Point(189, 121);
            this.cbOperation.Name = "cbOperation";
            this.cbOperation.Size = new System.Drawing.Size(121, 20);
            this.cbOperation.TabIndex = 4;
            // 
            // btnCompute
            // 
            this.btnCompute.Location = new System.Drawing.Point(189, 165);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(75, 23);
            this.btnCompute.TabIndex = 5;
            this.btnCompute.Text = "计算";
            this.btnCompute.UseVisualStyleBackColor = true;
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "第二个数";
            // 
            // btnDownloadFile
            // 
            this.btnDownloadFile.Location = new System.Drawing.Point(23, 148);
            this.btnDownloadFile.Name = "btnDownloadFile";
            this.btnDownloadFile.Size = new System.Drawing.Size(75, 23);
            this.btnDownloadFile.TabIndex = 7;
            this.btnDownloadFile.Text = "下载文件";
            this.btnDownloadFile.UseVisualStyleBackColor = true;
            this.btnDownloadFile.Click += new System.EventHandler(this.btnDownloadFile_Click);
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.Location = new System.Drawing.Point(23, 177);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(75, 23);
            this.btnUploadFile.TabIndex = 8;
            this.btnUploadFile.Text = "上传文件";
            this.btnUploadFile.UseVisualStyleBackColor = true;
            this.btnUploadFile.Click += new System.EventHandler(this.btnUploadFile_Click);
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 279);
            this.Controls.Add(this.btnUploadFile);
            this.Controls.Add(this.btnDownloadFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCompute);
            this.Controls.Add(this.cbOperation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNum2);
            this.Controls.Add(this.tbNum1);
            this.Controls.Add(this.btnConnect);
            this.Name = "MainWnd";
            this.Text = "WCFTest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbNum1;
        private System.Windows.Forms.TextBox tbNum2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbOperation;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDownloadFile;
        private System.Windows.Forms.Button btnUploadFile;
    }
}

