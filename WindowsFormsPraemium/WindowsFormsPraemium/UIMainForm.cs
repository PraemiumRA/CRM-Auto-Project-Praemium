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
            CenterToScreen();
            directoryWatcher = new FolderWatcher();
            directoryWatcher.Run();
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
