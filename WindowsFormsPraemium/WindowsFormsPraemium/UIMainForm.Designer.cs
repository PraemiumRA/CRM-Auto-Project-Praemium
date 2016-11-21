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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIMainForm));
            this.buttonSelect = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.DataGridViewLogging = new System.Windows.Forms.DataGridView();
            this.LogType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogDataTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogExceptionCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewLogging)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSelect
            // 
            this.buttonSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelect.ForeColor = System.Drawing.SystemColors.Highlight;
            this.buttonSelect.Location = new System.Drawing.Point(12, 214);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(200, 37);
            this.buttonSelect.TabIndex = 1;
            this.buttonSelect.Text = "SELECT / DELETE";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox2.BackgroundImage = global::WindowsFormsPraemium.Properties.Resources.praemium;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(4, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(208, 132);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // DataGridViewLogging
            // 
            this.DataGridViewLogging.AllowUserToAddRows = false;
            this.DataGridViewLogging.AllowUserToDeleteRows = false;
            this.DataGridViewLogging.AllowUserToResizeColumns = false;
            this.DataGridViewLogging.AllowUserToResizeRows = false;
            this.DataGridViewLogging.BackgroundColor = System.Drawing.Color.White;
            this.DataGridViewLogging.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.DataGridViewLogging.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewLogging.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewLogging.ColumnHeadersHeight = 18;
            this.DataGridViewLogging.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridViewLogging.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LogType,
            this.LogDataTime,
            this.LogExceptionCode,
            this.LogMessage});
            this.DataGridViewLogging.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewLogging.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewLogging.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.DataGridViewLogging.Location = new System.Drawing.Point(218, 12);
            this.DataGridViewLogging.Name = "DataGridViewLogging";
            this.DataGridViewLogging.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewLogging.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridViewLogging.RowHeadersVisible = false;
            this.DataGridViewLogging.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataGridViewLogging.RowTemplate.Height = 18;
            this.DataGridViewLogging.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGridViewLogging.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewLogging.Size = new System.Drawing.Size(413, 240);
            this.DataGridViewLogging.TabIndex = 6;
            // 
            // LogType
            // 
            this.LogType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LogType.DefaultCellStyle = dataGridViewCellStyle2;
            this.LogType.Frozen = true;
            this.LogType.HeaderText = "State";
            this.LogType.MaxInputLength = 20;
            this.LogType.MinimumWidth = 60;
            this.LogType.Name = "LogType";
            this.LogType.ReadOnly = true;
            this.LogType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LogType.ToolTipText = "Current state of action.";
            this.LogType.Width = 60;
            // 
            // LogDataTime
            // 
            this.LogDataTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LogDataTime.HeaderText = "Date Time";
            this.LogDataTime.MinimumWidth = 80;
            this.LogDataTime.Name = "LogDataTime";
            this.LogDataTime.ReadOnly = true;
            this.LogDataTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LogDataTime.Width = 80;
            // 
            // LogExceptionCode
            // 
            this.LogExceptionCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LogExceptionCode.HeaderText = "Description";
            this.LogExceptionCode.MinimumWidth = 80;
            this.LogExceptionCode.Name = "LogExceptionCode";
            this.LogExceptionCode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // LogMessage
            // 
            this.LogMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LogMessage.HeaderText = "Message";
            this.LogMessage.MinimumWidth = 150;
            this.LogMessage.Name = "LogMessage";
            this.LogMessage.ReadOnly = true;
            this.LogMessage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // UIMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(634, 263);
            this.Controls.Add(this.DataGridViewLogging);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.buttonSelect);
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(650, 302);
            this.MinimumSize = new System.Drawing.Size(650, 302);
            this.Name = "UIMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CRM Auto-Feed Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewLogging)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.DataGridView DataGridViewLogging;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogType;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogDataTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogExceptionCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogMessage;
    }
}

