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
        private void UIMainForm_Load(object sender, EventArgs e)
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

            builder.Value.Append("Time: " + row.Cells[1].Value + Environment.NewLine);
            builder.Value.Append("Code: " + row.Cells[2].Value + Environment.NewLine);
            builder.Value.Append("Message: " + row.Cells[3].Value);

            MessageBoxIcon icon = MessageBoxIcon.None;
            if (Enum.IsDefined(typeof(LogType), row.Cells[0].Value.ToString()))
            {
                switch (row.Cells[0].Value.ToString())
                {
                    case "Error":
                        {
                            icon = MessageBoxIcon.Error;
                            break;
                        }
                    case "WrongData":
                        {
                            icon = MessageBoxIcon.Asterisk;
                            break;
                        }
                    case "Warning":
                        {
                            icon = MessageBoxIcon.Warning;
                            break;
                        }
                    default:
                        {
                            icon = MessageBoxIcon.Information;
                            break;
                        } 
                }

            } else
                icon = MessageBoxIcon.None;

            MessageBox.Show(
                                builder.Value.ToString(),
                                row.Cells[0].Value.ToString(),
                                MessageBoxButtons.OK,                               
                                icon
                            );
        }

        /// <summary>
        /// Handle for showing window for select and delete.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSelectDelete_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SelectOrDelete select = new SelectOrDelete();
            select.Show();
            select.Disposed += SelectDelete_Disposed;
        }

        /// <summary>
        /// Handle for showing UIMainForm after closing SelectOrDelete Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectDelete_Disposed(object sender, EventArgs e)
        {
            this.Visible = true;
        }
    }
}
