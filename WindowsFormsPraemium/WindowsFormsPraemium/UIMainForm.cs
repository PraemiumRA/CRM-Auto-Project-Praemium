using System;
using System.Windows.Forms;
using BLL;
using System.Text;
using System.IO;
using Logging;
using System.Data;
using System.Drawing;
using UIForm.DBAction;

namespace UIForm
{   
    /// <summary>
    /// Main form of project.
    /// </summary>
    public partial class UIMainForm : Form
    {
        FolderWatcher directoryWatcher;
        Lazy<StringBuilder> builder = new Lazy<StringBuilder>();

        public UIMainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handle for main form loading.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            LogManager.LogSource = this.DataGridViewLogging;
            LogManager.form = this;

            this.DataGridViewLogging.DoubleClick += LoggingView_DoubleClick;
            this.DataGridViewLogging.DefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 192, 255);

            directoryWatcher = new FolderWatcher();
            directoryWatcher.Run();
        }

        /// <summary>
        /// Handle for showing logs in Messagebox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoggingView_DoubleClick(object sender, EventArgs e)
        {
            builder.Value.Clear();
            DataGridViewRow row = this.DataGridViewLogging.CurrentRow;
            if (DataGridViewLogging.Rows.Count == 0)
                return;
            builder.Value.Append("State: " + row.Cells[0].Value + Environment.NewLine);
            builder.Value.Append("Time: " + row.Cells[1].Value + Environment.NewLine);
            builder.Value.Append("Code: " + row.Cells[2].Value + Environment.NewLine);
            builder.Value.Append("Message: " + row.Cells[3].Value);

            MessageBox.Show(builder.Value.ToString());
        }

        /// <summary>
        /// Handle for showing window for select and delete.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Select select = new Select();
            select.Show();
            select.Disposed += Select_Disposed;
        }

        /// <summary>
        /// Handle for showing UIMainForm after closing SelectOrDelete Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Select_Disposed(object sender, EventArgs e)
        {
            this.Visible = true;
        }
    }
}
