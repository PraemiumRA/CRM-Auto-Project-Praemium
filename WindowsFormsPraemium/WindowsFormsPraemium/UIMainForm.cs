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
        AppConfiguration appConfiguration;
        FolderWatcher watcher;//

        string monitoringPath = "";
        string directoryPathForJsonCreation = "";

        public UIMainForm()
        {
            InitializeComponent();
            appConfiguration = new AppConfiguration();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            monitoringPath = appConfiguration.GetToMnitorDirectory;
            directoryPathForJsonCreation = appConfiguration.JsonCreationDirectory;

            this.textBoxMonitoringDirectory.Text = monitoringPath;
            this.textBoxDirectoryForJsonCreation.Text = directoryPathForJsonCreation;

            watcher = new FolderWatcher(monitoringPath, directoryPathForJsonCreation);
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

        private void ButtonMonitoringDirectoryBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            this.textBoxMonitoringDirectory.Text = folderBrowserDialog.SelectedPath;

            monitoringPath = this.textBoxMonitoringDirectory.Text;
        }

        private void ButtonBrowseForJson_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            this.textBoxDirectoryForJsonCreation.Text = folderBrowserDialog.SelectedPath;

            directoryPathForJsonCreation = this.textBoxDirectoryForJsonCreation.Text;
        }
    }
}
