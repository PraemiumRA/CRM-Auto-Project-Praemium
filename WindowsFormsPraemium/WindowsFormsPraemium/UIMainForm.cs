using System;
using System.Windows.Forms;
using BLL;
using System.Text;
using System.IO;
using Logging;
using System.Data;

namespace UIForm
{
    using DBAction;
    using System.Drawing;

    public partial class UIMainForm : Form
    {
        FolderWatcher directoryWatcher;
        Lazy<StringBuilder> builder = new Lazy<StringBuilder>();

        public UIMainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Logger.LogSource = this.DataGridViewLogging;
            Logger.form = this;

            this.DataGridViewLogging.DoubleClick += LoggingView_DoubleClick;
            directoryWatcher = new FolderWatcher();
            directoryWatcher.Run();
        }

        private void LoggingView_DoubleClick(object sender, EventArgs e)
        {
            builder.Value.Clear();
            DataGridViewRow row = this.DataGridViewLogging.CurrentRow;

            builder.Value.Append("State: " + row.Cells[0].Value + Environment.NewLine);
            builder.Value.Append("Time: " + row.Cells[1].Value + Environment.NewLine);
            builder.Value.Append("Code: " + row.Cells[2].Value + Environment.NewLine);
            builder.Value.Append("Message: " + row.Cells[3].Value);

            MessageBox.Show(builder.Value.ToString());
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
