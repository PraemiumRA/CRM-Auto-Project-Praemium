namespace UIForm.DBAction
{
    partial class Delete
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_ColumnName = new System.Windows.Forms.ComboBox();
            this.textBox_Value = new System.Windows.Forms.TextBox();
            this.delete_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(54, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(54, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Column Name";
            // 
            // comboBox_ColumnName
            // 
            this.comboBox_ColumnName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ColumnName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.comboBox_ColumnName.FormattingEnabled = true;
            this.comboBox_ColumnName.Items.AddRange(new object[] {
            "TeamID",
            "TeamName",
            "MemberID",
            "MemberName",
            "MemberSurname",
            "ProjectID",
            "ProjectName",
            "ProjectCreatedDate",
            "ProjectDueDate",
            "MemberProjectID"});
            this.comboBox_ColumnName.Location = new System.Drawing.Point(57, 43);
            this.comboBox_ColumnName.Name = "comboBox_ColumnName";
            this.comboBox_ColumnName.Size = new System.Drawing.Size(172, 21);
            this.comboBox_ColumnName.TabIndex = 12;
            // 
            // textBox_Value
            // 
            this.textBox_Value.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Value.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox_Value.Location = new System.Drawing.Point(58, 90);
            this.textBox_Value.Multiline = true;
            this.textBox_Value.Name = "textBox_Value";
            this.textBox_Value.Size = new System.Drawing.Size(171, 36);
            this.textBox_Value.TabIndex = 11;
            // 
            // delete_button
            // 
            this.delete_button.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_button.ForeColor = System.Drawing.SystemColors.Highlight;
            this.delete_button.Location = new System.Drawing.Point(58, 161);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(172, 42);
            this.delete_button.TabIndex = 10;
            this.delete_button.Text = "Delete";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // Delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 260);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_ColumnName);
            this.Controls.Add(this.textBox_Value);
            this.Controls.Add(this.delete_button);
            this.MaximumSize = new System.Drawing.Size(306, 299);
            this.MinimumSize = new System.Drawing.Size(306, 299);
            this.Name = "Delete";
            this.Text = "Delete";
            this.Load += new System.EventHandler(this.Delete_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_ColumnName;
        private System.Windows.Forms.TextBox textBox_Value;
        private System.Windows.Forms.Button delete_button;
    }
}