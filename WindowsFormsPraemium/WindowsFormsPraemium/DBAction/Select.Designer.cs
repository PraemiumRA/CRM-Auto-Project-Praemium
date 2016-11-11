namespace UIForm.DBAction
{
    partial class Select
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
            this.dataGridViewValue = new System.Windows.Forms.DataGridView();
            this.comboBoxValue = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.value_textbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewValue)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewValue
            // 
            this.dataGridViewValue.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewValue.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewValue.Location = new System.Drawing.Point(5, 153);
            this.dataGridViewValue.Name = "dataGridViewValue";
            this.dataGridViewValue.Size = new System.Drawing.Size(752, 250);
            this.dataGridViewValue.TabIndex = 37;
            // 
            // comboBoxValue
            // 
            this.comboBoxValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxValue.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.comboBoxValue.FormattingEnabled = true;
            this.comboBoxValue.Items.AddRange(new object[] {
            "TeamName",
            "MemberName",
            "MemberSurname",
            "ProjectName",
            "ProjectCreated Date",
            "ProjectDueDate",
            "AllTeams",
            "AllMembers",
            "AllProjects"});
            this.comboBoxValue.Location = new System.Drawing.Point(95, 14);
            this.comboBoxValue.Name = "comboBoxValue";
            this.comboBoxValue.Size = new System.Drawing.Size(228, 26);
            this.comboBoxValue.TabIndex = 36;
            this.comboBoxValue.SelectedIndexChanged += new System.EventHandler(this.comboBoxValue_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(1, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 20);
            this.label11.TabIndex = 35;
            this.label11.Text = "Select By`";
            // 
            // buttonSelect
            // 
            this.buttonSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelect.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelect.ForeColor = System.Drawing.SystemColors.Highlight;
            this.buttonSelect.Location = new System.Drawing.Point(95, 89);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(228, 37);
            this.buttonSelect.TabIndex = 34;
            this.buttonSelect.Text = "SELECT";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // value_textbox
            // 
            this.value_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.value_textbox.Location = new System.Drawing.Point(95, 46);
            this.value_textbox.Multiline = true;
            this.value_textbox.Name = "value_textbox";
            this.value_textbox.Size = new System.Drawing.Size(228, 37);
            this.value_textbox.TabIndex = 33;
            // 
            // Select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 415);
            this.Controls.Add(this.dataGridViewValue);
            this.Controls.Add(this.comboBoxValue);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.value_textbox);
            this.MaximumSize = new System.Drawing.Size(774, 454);
            this.MinimumSize = new System.Drawing.Size(774, 454);
            this.Name = "Select";
            this.Text = "Select";
            this.Load += new System.EventHandler(this.Select_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewValue;
        private System.Windows.Forms.ComboBox comboBoxValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.TextBox value_textbox;
    }
}