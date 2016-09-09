namespace XLS2XML
{
    partial class Convert2XML
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
            this.OpenExcelButton = new System.Windows.Forms.Button();
            this.openExcelFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.OpenCsvButton = new System.Windows.Forms.Button();
            this.targetFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SheetIndexNum = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OutputFileNameText = new System.Windows.Forms.TextBox();
            this.outputPathLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectPathButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.InputEncodingLabel = new System.Windows.Forms.Label();
            this.EncodingComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openCsvFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.xmlProgressBar = new System.Windows.Forms.ProgressBar();
            this.DelimiterComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SheetIndexNum)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenExcelButton
            // 
            this.OpenExcelButton.Location = new System.Drawing.Point(25, 19);
            this.OpenExcelButton.Name = "OpenExcelButton";
            this.OpenExcelButton.Size = new System.Drawing.Size(75, 47);
            this.OpenExcelButton.TabIndex = 0;
            this.OpenExcelButton.Text = "打开 Excel";
            this.OpenExcelButton.UseVisualStyleBackColor = true;
            this.OpenExcelButton.Click += new System.EventHandler(this.OpenExcelButton_Click);
            // 
            // openExcelFileDialog
            // 
            this.openExcelFileDialog.FileName = "openFileDialog1";
            // 
            // OpenCsvButton
            // 
            this.OpenCsvButton.Location = new System.Drawing.Point(36, 19);
            this.OpenCsvButton.Name = "OpenCsvButton";
            this.OpenCsvButton.Size = new System.Drawing.Size(75, 47);
            this.OpenCsvButton.TabIndex = 1;
            this.OpenCsvButton.Text = "打开 CSV";
            this.OpenCsvButton.UseVisualStyleBackColor = true;
            this.OpenCsvButton.Click += new System.EventHandler(this.OpenCsvButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.SheetIndexNum);
            this.groupBox1.Controls.Add(this.OpenExcelButton);
            this.groupBox1.Location = new System.Drawing.Point(42, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 144);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sheet";
            // 
            // SheetIndexNum
            // 
            this.SheetIndexNum.Location = new System.Drawing.Point(191, 34);
            this.SheetIndexNum.Name = "SheetIndexNum";
            this.SheetIndexNum.Size = new System.Drawing.Size(44, 20);
            this.SheetIndexNum.TabIndex = 1;
            this.SheetIndexNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SheetIndexNum.ValueChanged += new System.EventHandler(this.SheetIndexNum_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.OutputFileNameText);
            this.groupBox2.Controls.Add(this.outputPathLabel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.SelectPathButton);
            this.groupBox2.Location = new System.Drawing.Point(42, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 79);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "一般设置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "输出文件名";
            // 
            // OutputFileNameText
            // 
            this.OutputFileNameText.Location = new System.Drawing.Point(236, 22);
            this.OutputFileNameText.Name = "OutputFileNameText";
            this.OutputFileNameText.Size = new System.Drawing.Size(100, 20);
            this.OutputFileNameText.TabIndex = 3;
            this.OutputFileNameText.Text = "output";
            this.OutputFileNameText.TextChanged += new System.EventHandler(this.OutputFileNameText_TextChanged);
            // 
            // outputPathLabel
            // 
            this.outputPathLabel.AutoSize = true;
            this.outputPathLabel.Location = new System.Drawing.Point(144, 50);
            this.outputPathLabel.Name = "outputPathLabel";
            this.outputPathLabel.Size = new System.Drawing.Size(35, 13);
            this.outputPathLabel.TabIndex = 2;
            this.outputPathLabel.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "XML文件保存路径";
            // 
            // SelectPathButton
            // 
            this.SelectPathButton.Location = new System.Drawing.Point(25, 20);
            this.SelectPathButton.Name = "SelectPathButton";
            this.SelectPathButton.Size = new System.Drawing.Size(93, 23);
            this.SelectPathButton.TabIndex = 0;
            this.SelectPathButton.Text = "选择保存路径";
            this.SelectPathButton.UseVisualStyleBackColor = true;
            this.SelectPathButton.Click += new System.EventHandler(this.SelectPathButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DelimiterComboBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.InputEncodingLabel);
            this.groupBox3.Controls.Add(this.EncodingComboBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.OpenCsvButton);
            this.groupBox3.Location = new System.Drawing.Point(339, 107);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 144);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CSV";
            // 
            // InputEncodingLabel
            // 
            this.InputEncodingLabel.AutoSize = true;
            this.InputEncodingLabel.Location = new System.Drawing.Point(152, 19);
            this.InputEncodingLabel.Name = "InputEncodingLabel";
            this.InputEncodingLabel.Size = new System.Drawing.Size(31, 13);
            this.InputEncodingLabel.TabIndex = 22;
            this.InputEncodingLabel.Text = "编码";
            // 
            // EncodingComboBox
            // 
            this.EncodingComboBox.FormattingEnabled = true;
            this.EncodingComboBox.Location = new System.Drawing.Point(155, 36);
            this.EncodingComboBox.Name = "EncodingComboBox";
            this.EncodingComboBox.Size = new System.Drawing.Size(56, 21);
            this.EncodingComboBox.TabIndex = 3;
            this.EncodingComboBox.SelectedIndexChanged += new System.EventHandler(this.EncodingComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "注意： 编码格式默认UTF8";
            // 
            // openCsvFileDialog
            // 
            this.openCsvFileDialog.FileName = "openFileDialog1";
            // 
            // xmlProgressBar
            // 
            this.xmlProgressBar.Location = new System.Drawing.Point(42, 276);
            this.xmlProgressBar.Name = "xmlProgressBar";
            this.xmlProgressBar.Size = new System.Drawing.Size(546, 23);
            this.xmlProgressBar.Step = 1;
            this.xmlProgressBar.TabIndex = 5;
            this.xmlProgressBar.Visible = false;
            // 
            // DelimiterComboBox
            // 
            this.DelimiterComboBox.FormattingEnabled = true;
            this.DelimiterComboBox.Location = new System.Drawing.Point(155, 114);
            this.DelimiterComboBox.Name = "DelimiterComboBox";
            this.DelimiterComboBox.Size = new System.Drawing.Size(56, 21);
            this.DelimiterComboBox.TabIndex = 23;
            this.DelimiterComboBox.SelectedIndexChanged += new System.EventHandler(this.DelimiterComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(152, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "分隔符";
            // 
            // Convert2XML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 315);
            this.Controls.Add(this.xmlProgressBar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Convert2XML";
            this.Text = "转XML";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SheetIndexNum)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenExcelButton;
        private System.Windows.Forms.OpenFileDialog openExcelFileDialog;
        private System.Windows.Forms.Button OpenCsvButton;
        private System.Windows.Forms.FolderBrowserDialog targetFolderBrowserDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown SheetIndexNum;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SelectPathButton;
        private System.Windows.Forms.Label outputPathLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OutputFileNameText;
        private System.Windows.Forms.OpenFileDialog openCsvFileDialog;
        private System.Windows.Forms.Label InputEncodingLabel;
        private System.Windows.Forms.ComboBox EncodingComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar xmlProgressBar;
        private System.Windows.Forms.ComboBox DelimiterComboBox;
        private System.Windows.Forms.Label label5;
    }
}

