using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UIForm.DBAction
{
    public partial class Select : Form
    {
        string selectedRow;
        public Select()
        {
            InitializeComponent();
            comboBoxValue.SelectedIndex = 0;
        }

        private async void buttonSelect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(value_textbox.Text.ToString()) && value_textbox.Enabled == true)
            {
                MessageBox.Show("Please fill the value area");
            }
            else
            {
                TeamMemberProjectBLL tmpBLL = new TeamMemberProjectBLL(value_textbox.Text, comboBoxValue.SelectedItem.ToString());
                await Task.Factory.StartNew(tmpBLL.SelectAsync);
                dataGridViewValue.DataSource = tmpBLL.dataTableValue;
                value_textbox.Clear();
            }
        }


        private void comboBoxValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxValue.SelectedIndex == 0 || comboBoxValue.SelectedIndex == 2 || comboBoxValue.SelectedIndex == 5)
                buttonSelect.Enabled = false;
            else buttonSelect.Enabled = true;

            if (comboBoxValue.SelectedIndex == 9 || comboBoxValue.SelectedIndex == 10 || comboBoxValue.SelectedIndex == 11 || comboBoxValue.SelectedIndex == 12)
                value_textbox.Enabled = false;
            else value_textbox.Enabled = true;
        }

        private void Select_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void dataGridViewValue_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridViewValue.RowCount > 0)
                selectedRow = dataGridViewValue.SelectedRows[0].Cells[0].Value.ToString();
        }

        private async void button_Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(value_textbox.Text.ToString()) && selectedRow == null && value_textbox.Enabled == true)
            {
                MessageBox.Show("Please fill the value area.");
            }
            else
            {
                TeamMemberProjectBLL tmpBLL = new TeamMemberProjectBLL(value_textbox.Text, comboBoxValue.SelectedItem.ToString(), selectedRow);
                await Task.Factory.StartNew(tmpBLL.DeleteAsync);
                value_textbox.Clear();
            }
        }
    }
}
