using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using DataModelLibrary;

namespace FileGenerator
{

    public partial class BaseForm : Form
    {
        DirectoryChoose checkService;
        ChooseFileType chooseFileType;
        FileInformation fileInformation;
        FileNameGiver fileNameGiver;
        StringBuilder builder;
        Random random;
        public string fileDirectory = "";


        public BaseForm()
        {

            InitializeComponent();
            random = new Random();
            builder = new StringBuilder();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

            checkService = new DirectoryChoose();
            chooseFileType = new ChooseFileType();

            //Get directory for creating file
            try
            {
                fileDirectory = checkService.GetDirectoryPath();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            for (FileCount i = FileCount.Single; i < FileCount.Count; i++)
            {
                this.comboBoxFileCount.Items.Add(i.ToString());
            }

            //Settings
            this.comboBoxFileCount.SelectedIndex = 0;
            this.textBoxDestination.Text = fileDirectory;
            this.textBoxMemeberCount.TextChanged += CheckInputText;
            this.textBoxProjectCount.TextChanged += CheckInputText;

            GetAllFilesFromSelectedDirectory();
        }

        /// <summary>
        /// Choose creating file directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            builder.Clear();
            folderBrowserDialog.ShowDialog();

            builder.Append(folderBrowserDialog.SelectedPath);

            if (checkService.IsDirectoryExist(builder.ToString()))
            {
                this.textBoxDestination.Text = builder.ToString();
                this.fileDirectory = builder.ToString();
            }

        }

        /// <summary>
        /// Show all file names in chose directory
        /// </summary>
        /// <param name="taker"></param>
        private void ShowAllFilesName(FileNameGiver taker = null)
        {
            if (taker == null)
                this.listBoxOfFiles.DataSource = GetAllFilesFromSelectedDirectory();
            else
                this.listBoxOfFiles.DataSource = taker.fileList;

            this.listBoxOfFiles.DisplayMember = "ToString();";
        }


        private List<string> GetAllFilesFromSelectedDirectory()
        {
            List<string> filesInDirectory = new List<string>();
            string[] files = Directory.GetFiles(fileDirectory);

            for (int i = 0; i < files.Length; i++)
            {
                if (Path.GetExtension(files[i]) == ".xml" || Path.GetExtension(files[i]) == ".csv")
                {
                    filesInDirectory.Add(files[i]);
                }
            }

            return filesInDirectory;
        }

        /// <summary>
        /// Generate button hundle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonGenerate_Click(object sender, EventArgs e)
        {
            int memberCount = Check.CheckNumber(this.textBoxMemeberCount.Text);
            int projectCount = Check.CheckNumber(this.textBoxProjectCount.Text);

            if (memberCount == -1 || projectCount == -1)
            {
                //TODO: Logging
                MessageBox.Show("Not currect input value. Please check all input fields.");
                return;
            }

            try
            {
                fileNameGiver = new FileNameGiver(fileDirectory);
                await Task.Factory.StartNew(fileNameGiver.GetAllFilesInDirectory);
            }
            catch (Exception exceptin)
            {
                //Loging
                MessageBox.Show(exceptin.Message);
            }

            FileType tempType = FileType.Xml; ;

            if (radioButtonCSV.Checked)
            {
                tempType = FileType.Csv;
            }
            else
                if (radioButtonXML.Checked)
            {
                tempType = FileType.Xml;
            }

            if (checkService.IsDirectoryExist(this.textBoxDestination.Text))
            {
                fileDirectory = this.textBoxDestination.Text;
            }
            else
            {
                //Loggig
                this.textBoxDestination.Text = fileDirectory;
                this.textBoxDestination.BackColor = Color.FromArgb(90, 190, 255);
            }

            //Collect information for creating file
            fileInformation = new FileInformation()
            {
                MemberCount = memberCount,
                ProjectCount = projectCount,
                FileDirectory = fileDirectory,
                FileName = fileNameGiver.GetFileName(tempType)
            };
            try
            {
                //Generate random data and create file
                if (chooseFileType.GenerateTheFile(tempType, fileInformation))
                {
                    //Show all file names in listBox
                    ShowAllFilesName(fileNameGiver);
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            //open file after generate
            if (this.checkBoxAutoOpen.Checked)
            {
                try
                {
                    this.OpenAferGenerate(fileInformation, tempType);
                }
                catch (FileNotFoundException fnf)
                {
                    MessageBox.Show(fnf.Message);
                }
                catch (Exception ex)
                {
                    //TODO: Logging
                    MessageBox.Show(ex.Message);
                }
            }

        }

        /// <summary>
        /// Open generated file after create
        /// </summary>
        /// <param name="fileInformation"></param>
        /// <param name="tempType"></param>
        private void OpenAferGenerate(FileInformation fileInformation, FileType tempType)
        {

            builder.Clear();
            builder.Append(fileDirectory);
            builder.Append('\\');
            builder.Append(fileInformation.FileName);//
            builder.Append('.');
            builder.Append(tempType.ToString().ToLower());

            do
            {
                if (File.Exists(builder.ToString()))
                    break;
            } while (true);

            try
            {
                Process.Start(builder.ToString());
            }
            catch (FileNotFoundException fileNotFound)
            {
                //TODO: Logging
                MessageBox.Show(fileNotFound.Message);
            }
            catch (Exception exception)
            {
                //TODO: Logging
                MessageBox.Show(exception.Message);
            }

            builder.Clear();

        }

        /// <summary>
        /// ComboBox Content hundle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxFileCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox.SelectedIndex == (int)FileCount.Multiple)
            {
                this.textBoxMemeberCount.Enabled = true;
                this.textBoxProjectCount.Enabled = true;
            }
            else
            {
                this.textBoxMemeberCount.Enabled = false;
                this.textBoxProjectCount.Enabled = false;
            }
            this.textBoxMemeberCount.Text = "1";
        }

        /// <summary>
        /// checker for input text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckInputText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            builder.Clear();
            builder.Append(@"^\d{1,");
            builder.Append(textBox.MaxLength.ToString());
            builder.Append("}$");

            if (!Regex.IsMatch(textBox.Text, builder.ToString()))
            {
                textBox.BackColor = Color.FromArgb(202, 108, 109);
                this.buttonGenerate.Enabled = false;
            }
            else
            {
                this.buttonGenerate.Enabled = true;
                textBox.BackColor = Color.White;
            }
        }
    }
}

