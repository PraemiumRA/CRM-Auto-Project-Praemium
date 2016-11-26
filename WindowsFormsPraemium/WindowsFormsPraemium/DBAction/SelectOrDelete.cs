using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using System.Data;
using BLL.BusinessDataModel;

namespace UIForm.DBAction
{
    /// <summary>
    /// Main form for Select and Delete
    /// </summary>
    public partial class SelectOrDelete : Form
    {
        bool wasException = false;
        string selectedRow;
        TablesData tablesData;
        public SelectOrDelete()
        {
            InitializeComponent();
            tablesData = new TablesData();
            comboBoxValue.SelectedIndex = 0;
        }

        /// <summary>
        /// Handle for Select button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(
                () =>
                {
                    if (string.IsNullOrEmpty(value_textbox.Text.ToString()) && value_textbox.Enabled == true)
                    {
                        MessageBox.Show("Please fill the value area");
                    }
                    else
                    {
                        dataGridViewValue.DataSource = ColumnNameGiver(tablesData.SelectBy(value_textbox.Text, comboBoxValue.SelectedItem.ToString()));
                        value_textbox.Clear();
                    }
                }));
        }

        /// <summary>
        /// Handle for combobox item changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewValue.DataSource = null;

            if (comboBoxValue.SelectedIndex == 0 || comboBoxValue.SelectedIndex == 2 || comboBoxValue.SelectedIndex == 6)
                buttonSelect.Enabled = false;
            else buttonSelect.Enabled = true;

            if (comboBoxValue.SelectedIndex == 10 || comboBoxValue.SelectedIndex == 11 || comboBoxValue.SelectedIndex == 12)
                value_textbox.Enabled = false;
            else value_textbox.Enabled = true;
        }

        private void Select_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        /// <summary>
        /// Handle which will give selected rows value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewValue_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridViewValue.RowCount > 0 && (comboBoxValue.SelectedIndex == 10 || comboBoxValue.SelectedIndex == 11 || comboBoxValue.SelectedIndex == 12))
                selectedRow = dataGridViewValue.SelectedRows[0].Cells[0].Value.ToString();
        }

        /// <summary>
        /// Handle for Delete button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(value_textbox.Text.ToString()) && value_textbox.Enabled == true && !((comboBoxValue.SelectedIndex == 10 || comboBoxValue.SelectedIndex == 11 || comboBoxValue.SelectedIndex == 12)))
            {
                MessageBox.Show("Please fill the value area.");
            }
            else if (string.IsNullOrEmpty(value_textbox.Text.ToString()) && selectedRow == null)
                MessageBox.Show("Choose the line to delete");
            else
            {
                int effectedRowsCount = 0;
                this.Invoke(new Action(
                () =>
                {
                    effectedRowsCount = tablesData.DeleteBy(value_textbox.Text, comboBoxValue.SelectedItem.ToString(), ref wasException, selectedRow);
                }));

                if (effectedRowsCount > 0)
                {
                    MessageBox.Show(string.Format("{0} row(s) were deleted", effectedRowsCount.ToString()));
                    Logging.LogManager.DoLogging(Logging.LogType.Delete, null, $"{effectedRowsCount.ToString()} row(s) were deleted");
                }
                else if (!wasException)
                { MessageBox.Show(string.Format("'{0}' does not exist in {1} column", value_textbox.Text, comboBoxValue.SelectedItem)); }

                value_textbox.Clear();
                selectedRow = null;
                wasException = false;
                dataGridViewValue.DataSource = ColumnNameGiver(tablesData.SelectBy(value_textbox.Text, comboBoxValue.SelectedItem.ToString()));
            }
        }

        /// <summary>
        /// Gives names for tables columns.
        /// </summary>
        /// <param name="table"></param>
        private DataTable ColumnNameGiver(DataTable table)
        {
            if (table != null)
            {
                if (table.Columns.Contains("PassportNumber"))
                {
                    table.Columns["PassportNumber"].ColumnName = "Passport №";
                }
                if (table.Columns.Contains("MemberName"))
                {
                    table.Columns["MemberName"].ColumnName = "Member Name";
                }
                if (table.Columns.Contains("MemberSurname"))
                {
                    table.Columns["MemberSurname"].ColumnName = "Suername";
                }
                if (table.Columns.Contains("TeamName"))
                {
                    table.Columns["TeamName"].ColumnName = "Team Name";
                }
                if (table.Columns.Contains("ProjectName"))
                {
                    table.Columns["ProjectName"].ColumnName = "Project Name";
                }
                if (table.Columns.Contains("ProjectCreatedDate"))
                {
                    table.Columns["ProjectCreatedDate"].ColumnName = "Created Date";
                }
                if (table.Columns.Contains("ProjectDueDate"))
                {
                    table.Columns["ProjectDueDate"].ColumnName = "Due Date";
                }
                if (table.Columns.Contains("ProjectDescription"))
                {
                    table.Columns["ProjectDescription"].ColumnName = "Description";
                }
            }
            return table;
        }
    }
}
