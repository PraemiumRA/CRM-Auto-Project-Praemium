using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using BLL;
namespace UIForm.DBAction
{
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
            comboBox_ColumnName.SelectedIndex = 0;
        }

        private async void delete_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Value.Text.ToString()))
            {
                MessageBox.Show("Please fill the value area");
            }
            else
            {
                TeamMemberProjectBLL tmpBLL = new TeamMemberProjectBLL(textBox_Value.Text, comboBox_ColumnName.SelectedItem.ToString());
                await Task.Factory.StartNew(tmpBLL.DeleteAsync);
                textBox_Value.Clear();
            }
        }

        private void Delete_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
