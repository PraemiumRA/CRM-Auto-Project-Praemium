using System;
using System.Windows.Forms;
using BLL;

namespace UIForm
{
    using DBAction;

    public partial class UIMainForm : Form
    {
        AppConfiguration appConfiguration;

        public UIMainForm()
        {
            InitializeComponent();
            
        }

        private  void Form1_Load(object sender, EventArgs e)
        {
            appConfiguration = new AppConfiguration();

            FolderWatcher watcher = new FolderWatcher(appConfiguration.GetToMnitorDirectory);
            watcher.Run();
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
