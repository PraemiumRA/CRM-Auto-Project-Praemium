namespace UIForm
{
    partial class UIMainForm
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
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBoxMonitoring = new System.Windows.Forms.GroupBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.textBoxMonitoringDirectory = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBoxJsonDirectory = new System.Windows.Forms.GroupBox();
            this.buttonBrowseForJson = new System.Windows.Forms.Button();
            this.textBoxDirectoryForJsonCreation = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBoxMonitoring.SuspendLayout();
            this.groupBoxJsonDirectory.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSelect
            // 
            this.buttonSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelect.ForeColor = System.Drawing.SystemColors.Highlight;
            this.buttonSelect.Location = new System.Drawing.Point(12, 299);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(206, 43);
            this.buttonSelect.TabIndex = 1;
            this.buttonSelect.Text = "SELECT";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.SystemColors.Highlight;
            this.buttonDelete.Location = new System.Drawing.Point(305, 299);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(207, 43);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "DELETE";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox2.BackgroundImage = global::WindowsFormsPraemium.Properties.Resources.praemium;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(141, 185);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(255, 108);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // groupBoxMonitoring
            // 
            this.groupBoxMonitoring.Controls.Add(this.buttonBrowse);
            this.groupBoxMonitoring.Controls.Add(this.textBoxMonitoringDirectory);
            this.groupBoxMonitoring.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMonitoring.Location = new System.Drawing.Point(12, 12);
            this.groupBoxMonitoring.Name = "groupBoxMonitoring";
            this.groupBoxMonitoring.Size = new System.Drawing.Size(498, 46);
            this.groupBoxMonitoring.TabIndex = 12;
            this.groupBoxMonitoring.TabStop = false;
            this.groupBoxMonitoring.Text = "Monitoring Directory";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBrowse.Location = new System.Drawing.Point(447, 15);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(45, 23);
            this.buttonBrowse.TabIndex = 1;
            this.buttonBrowse.Text = ". . .";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.ButtonMonitoringDirectoryBrowse_Click);
            // 
            // textBoxMonitoringDirectory
            // 
            this.textBoxMonitoringDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMonitoringDirectory.Location = new System.Drawing.Point(7, 16);
            this.textBoxMonitoringDirectory.Name = "textBoxMonitoringDirectory";
            this.textBoxMonitoringDirectory.Size = new System.Drawing.Size(434, 21);
            this.textBoxMonitoringDirectory.TabIndex = 0;
            // 
            // groupBoxJsonDirectory
            // 
            this.groupBoxJsonDirectory.Controls.Add(this.buttonBrowseForJson);
            this.groupBoxJsonDirectory.Controls.Add(this.textBoxDirectoryForJsonCreation);
            this.groupBoxJsonDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxJsonDirectory.Location = new System.Drawing.Point(12, 61);
            this.groupBoxJsonDirectory.Name = "groupBoxJsonDirectory";
            this.groupBoxJsonDirectory.Size = new System.Drawing.Size(498, 46);
            this.groupBoxJsonDirectory.TabIndex = 13;
            this.groupBoxJsonDirectory.TabStop = false;
            this.groupBoxJsonDirectory.Text = "Directory for Json format file creation";
            // 
            // buttonBrowseForJson
            // 
            this.buttonBrowseForJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBrowseForJson.Location = new System.Drawing.Point(447, 15);
            this.buttonBrowseForJson.Name = "buttonBrowseForJson";
            this.buttonBrowseForJson.Size = new System.Drawing.Size(45, 23);
            this.buttonBrowseForJson.TabIndex = 1;
            this.buttonBrowseForJson.Text = ". . .";
            this.buttonBrowseForJson.UseVisualStyleBackColor = true;
            this.buttonBrowseForJson.Click += new System.EventHandler(this.ButtonBrowseForJson_Click);
            // 
            // textBoxDirectoryForJsonCreation
            // 
            this.textBoxDirectoryForJsonCreation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDirectoryForJsonCreation.Location = new System.Drawing.Point(7, 16);
            this.textBoxDirectoryForJsonCreation.Name = "textBoxDirectoryForJsonCreation";
            this.textBoxDirectoryForJsonCreation.Size = new System.Drawing.Size(434, 21);
            this.textBoxDirectoryForJsonCreation.TabIndex = 0;
            // 
            // UIMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(524, 354);
            this.Controls.Add(this.groupBoxJsonDirectory);
            this.Controls.Add(this.groupBoxMonitoring);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSelect);
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Name = "UIMainForm";
            this.Text = "CRM Auto-Feed Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBoxMonitoring.ResumeLayout(false);
            this.groupBoxMonitoring.PerformLayout();
            this.groupBoxJsonDirectory.ResumeLayout(false);
            this.groupBoxJsonDirectory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBoxMonitoring;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.TextBox textBoxMonitoringDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox groupBoxJsonDirectory;
        private System.Windows.Forms.Button buttonBrowseForJson;
        private System.Windows.Forms.TextBox textBoxDirectoryForJsonCreation;
    }
}

