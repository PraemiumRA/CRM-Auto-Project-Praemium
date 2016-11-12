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
            this.Visible = false;
            Delete delete = new Delete();
            delete.Show();
            delete.Disposed += Delete_Disposed;
        }

        private void Delete_Disposed(object sender, EventArgs e)
        {
            this.Visible = true; ;
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Select select = new Select();
            select.Show();
            select.Disposed += Select_Disposed;
        }

        private void Select_Disposed(object sender, EventArgs e)
        {
            this.Visible = true;
        }
    }
}
