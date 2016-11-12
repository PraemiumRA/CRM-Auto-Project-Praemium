namespace FileGenerator
{
    partial class BaseForm
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
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBoxAutoOpen = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonXML = new System.Windows.Forms.RadioButton();
            this.radioButtonCSV = new System.Windows.Forms.RadioButton();
            this.listBoxOfFiles = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.numericOfProjectCount = new System.Windows.Forms.NumericUpDown();
            this.numericOfMemberCount = new System.Windows.Forms.NumericUpDown();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOfProjectCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOfMemberCount)).BeginInit();
            this.SuspendLayout();
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Please select directory where will creat file.";
            // 
            // checkBoxAutoOpen
            // 
            this.checkBoxAutoOpen.AutoSize = true;
            this.checkBoxAutoOpen.Location = new System.Drawing.Point(12, 128);
            this.checkBoxAutoOpen.Name = "checkBoxAutoOpen";
            this.checkBoxAutoOpen.Size = new System.Drawing.Size(192, 17);
            this.checkBoxAutoOpen.TabIndex = 14;
            this.checkBoxAutoOpen.Text = "Authomaticaly open file after create";
            this.checkBoxAutoOpen.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericOfProjectCount);
            this.groupBox3.Location = new System.Drawing.Point(239, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(108, 51);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Project Count";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonBrowse);
            this.groupBox2.Controls.Add(this.textBoxDestination);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 44);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destination";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBrowse.Location = new System.Drawing.Point(290, 15);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(35, 23);
            this.buttonBrowse.TabIndex = 1;
            this.buttonBrowse.Text = ". . .";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDestination.Location = new System.Drawing.Point(7, 17);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(277, 20);
            this.textBoxDestination.TabIndex = 0;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(71, 216);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(201, 33);
            this.buttonGenerate.TabIndex = 10;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonXML);
            this.groupBox1.Controls.Add(this.radioButtonCSV);
            this.groupBox1.Location = new System.Drawing.Point(12, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 51);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File type";
            // 
            // radioButtonXML
            // 
            this.radioButtonXML.AutoSize = true;
            this.radioButtonXML.Location = new System.Drawing.Point(59, 19);
            this.radioButtonXML.Name = "radioButtonXML";
            this.radioButtonXML.Size = new System.Drawing.Size(43, 17);
            this.radioButtonXML.TabIndex = 1;
            this.radioButtonXML.TabStop = true;
            this.radioButtonXML.Text = ".xml";
            this.radioButtonXML.UseVisualStyleBackColor = true;
            // 
            // radioButtonCSV
            // 
            this.radioButtonCSV.AutoSize = true;
            this.radioButtonCSV.Checked = true;
            this.radioButtonCSV.Location = new System.Drawing.Point(7, 19);
            this.radioButtonCSV.Name = "radioButtonCSV";
            this.radioButtonCSV.Size = new System.Drawing.Size(45, 17);
            this.radioButtonCSV.TabIndex = 0;
            this.radioButtonCSV.TabStop = true;
            this.radioButtonCSV.Text = ".csv";
            this.radioButtonCSV.UseVisualStyleBackColor = true;
            // 
            // listBoxOfFiles
            // 
            this.listBoxOfFiles.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxOfFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxOfFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxOfFiles.FormattingEnabled = true;
            this.listBoxOfFiles.ItemHeight = 15;
            this.listBoxOfFiles.Location = new System.Drawing.Point(364, 27);
            this.listBoxOfFiles.Name = "listBoxOfFiles";
            this.listBoxOfFiles.ScrollAlwaysVisible = true;
            this.listBoxOfFiles.Size = new System.Drawing.Size(230, 212);
            this.listBoxOfFiles.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(361, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "File in directory";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.numericOfMemberCount);
            this.groupBox5.Location = new System.Drawing.Point(126, 62);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(109, 51);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Member Count";
            // 
            // numericOfProjectCount
            // 
            this.numericOfProjectCount.Location = new System.Drawing.Point(6, 19);
            this.numericOfProjectCount.Name = "numericOfProjectCount";
            this.numericOfProjectCount.Size = new System.Drawing.Size(96, 20);
            this.numericOfProjectCount.TabIndex = 18;
            // 
            // numericOfMemberCount
            // 
            this.numericOfMemberCount.Location = new System.Drawing.Point(7, 19);
            this.numericOfMemberCount.Name = "numericOfMemberCount";
            this.numericOfMemberCount.Size = new System.Drawing.Size(96, 20);
            this.numericOfMemberCount.TabIndex = 19;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 261);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxOfFiles);
            this.Controls.Add(this.checkBoxAutoOpen);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(620, 300);
            this.MinimumSize = new System.Drawing.Size(620, 300);
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Generator";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericOfProjectCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOfMemberCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAutoOpen;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.TextBox textBoxDestination;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonXML;
        private System.Windows.Forms.RadioButton radioButtonCSV;
        private System.Windows.Forms.ListBox listBoxOfFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;//
        private System.Windows.Forms.NumericUpDown numericOfProjectCount;
        private System.Windows.Forms.NumericUpDown numericOfMemberCount;
    }
}

