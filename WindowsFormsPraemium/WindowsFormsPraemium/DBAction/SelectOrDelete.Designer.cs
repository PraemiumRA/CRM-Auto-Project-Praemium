namespace UIForm.DBAction
{
    partial class SelectOrDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectOrDelete));
            this.comboBoxValue = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.value_textbox = new System.Windows.Forms.TextBox();
            this.button_Delete = new System.Windows.Forms.Button();
            this.dataGridViewValue = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewValue)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxValue
            // 
            this.comboBoxValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxValue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxValue.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.comboBoxValue.FormattingEnabled = true;
            this.comboBoxValue.Items.AddRange(new object[] {
            "TeamID",
            "TeamName",
            "MemberID",
            "PassportNumber",
            "MemberName",
            "MemberSurname",
            "ProjectID",
            "ProjectName",
            "ProjectCreatedDate",
            "ProjectDueDate",
            "AllTeams",
            "AllMembers",
            "AllProjects"});
            this.comboBoxValue.Location = new System.Drawing.Point(237, 31);
            this.comboBoxValue.Name = "comboBoxValue";
            this.comboBoxValue.Size = new System.Drawing.Size(256, 26);
            this.comboBoxValue.TabIndex = 36;
            this.comboBoxValue.SelectedIndexChanged += new System.EventHandler(this.comboBoxValue_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(233, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 20);
            this.label11.TabIndex = 35;
            this.label11.Text = "Select \\ Delete  By`";
            // 
            // buttonSelect
            // 
            this.buttonSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelect.ForeColor = System.Drawing.SystemColors.Highlight;
            this.buttonSelect.Location = new System.Drawing.Point(237, 106);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(125, 37);
            this.buttonSelect.TabIndex = 34;
            this.buttonSelect.Text = "SELECT";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // value_textbox
            // 
            this.value_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.value_textbox.Location = new System.Drawing.Point(237, 63);
            this.value_textbox.Multiline = true;
            this.value_textbox.Name = "value_textbox";
            this.value_textbox.Size = new System.Drawing.Size(256, 37);
            this.value_textbox.TabIndex = 33;
            // 
            // button_Delete
            // 
            this.button_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Delete.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button_Delete.Location = new System.Drawing.Point(368, 106);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(125, 36);
            this.button_Delete.TabIndex = 38;
            this.button_Delete.Text = "DELETE";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // dataGridViewValue
            // 
            this.dataGridViewValue.AllowUserToAddRows = false;
            this.dataGridViewValue.AllowUserToDeleteRows = false;
            this.dataGridViewValue.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewValue.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewValue.Location = new System.Drawing.Point(5, 153);
            this.dataGridViewValue.Name = "dataGridViewValue";
            this.dataGridViewValue.ReadOnly = true;
            this.dataGridViewValue.RowHeadersVisible = false;
            this.dataGridViewValue.RowHeadersWidth = 43;
            this.dataGridViewValue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewValue.Size = new System.Drawing.Size(752, 250);
            this.dataGridViewValue.TabIndex = 37;
            this.dataGridViewValue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewValue_MouseClick);
            // 
            // Select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 415);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.dataGridViewValue);
            this.Controls.Add(this.comboBoxValue);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.value_textbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.ComboBox comboBoxValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.TextBox value_textbox;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.DataGridView dataGridViewValue;
    }
}