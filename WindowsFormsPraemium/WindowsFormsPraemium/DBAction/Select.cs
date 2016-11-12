using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UIForm.DBAction
{
    public partial class Select : Form
    {
        public Select()
        {
            InitializeComponent();
            comboBoxValue.SelectedIndex = 0;
        }

        private async void buttonSelect_Click(object sender, EventArgs e)
        {
            TeamMemberProjectBLL tmpBLL = new TeamMemberProjectBLL(value_textbox.Text, comboBoxValue.SelectedItem.ToString());
            await Task.Factory.StartNew(tmpBLL.SelectAsync);
            dataGridViewValue.DataSource = tmpBLL.dataTableValue;
            value_textbox.Clear();
        }

        private void comboBoxValue_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxValue.SelectedIndex == 9 || comboBoxValue.SelectedIndex == 10 || comboBoxValue.SelectedIndex == 11 || comboBoxValue.SelectedIndex == 12)
            {
                value_textbox.Enabled = false;
            }
            else
            {
                value_textbox.Enabled = true;
            }
        }

        private void Select_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
