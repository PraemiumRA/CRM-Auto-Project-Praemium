using System;
using System.Windows.Forms;
using BLL;
using System.IO;

namespace UIForm
{
    using DBAction;
    using System.Drawing;

    public partial class UIMainForm : Form
    {
        FolderWatcher directoryWatcher;

        public UIMainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {      
            directoryWatcher = new FolderWatcher();
            directoryWatcher.Run();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete();
            delete.Show();
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            Select select = new Select();
            select.Show();
        }
         
    }
}
