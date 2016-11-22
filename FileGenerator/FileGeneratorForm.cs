﻿using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
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
            this.numericOfMemberCount.Minimum = 1;
            this.numericOfMemberCount.Maximum = 99;

            this.numericOfProjectCount.Minimum = 1;
            this.numericOfProjectCount.Maximum = 99;

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

            this.textBoxDestination.Text = fileDirectory;
            this.numericOfMemberCount.TextChanged += CheckInputText;
            this.numericOfProjectCount.TextChanged += CheckInputText;

        }

        /// <summary>
        /// Choose creating file directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  void ButtonBrowse_Click(object sender, EventArgs e)
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
        /// Generate button hundle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonGenerate_Click(object sender, EventArgs e)
        {
            int memberCount = Check.CheckNumber(((int)this.numericOfMemberCount.Value).ToString());
            int projectCount = Check.CheckNumber(((int)this.numericOfProjectCount.Value).ToString());

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
                chooseFileType.GenerateTheFile(tempType, fileInformation);
            }
            catch (Exception exception)
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

            Process process = null;
            try
            {
                process = Process.Start(builder.ToString());
            }
            catch (ObjectDisposedException disposedException)
            {
                MessageBox.Show(disposedException.Message);
            }
            catch (FileNotFoundException notFound)
            {
                MessageBox.Show(notFound.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                if (process != null)
                    process.Close();
            }

            builder.Clear();
        }


        /// <summary>
        /// checker for input text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckInputText(object sender, EventArgs e)
        {
            NumericUpDown numberUpDown = sender as NumericUpDown;
            decimal temp = numberUpDown.Maximum;

            builder.Clear();
            builder.Append(@"^\d{1,");
            builder.Append(numberUpDown.Maximum.ToString());
            builder.Append("}$");

            if (!Regex.IsMatch(numberUpDown.Text, builder.ToString()))
            {
                numberUpDown.BackColor = Color.FromArgb(202, 108, 109);
                this.buttonGenerate.Enabled = false;
            }
            else
            {
                this.buttonGenerate.Enabled = true;
                numberUpDown.BackColor = Color.White;
            }
            try
            {
                if (numberUpDown.Text.Length > 2)
                {
                    if (decimal.TryParse(numberUpDown.Value.ToString().Remove(2, numberUpDown.Text.Length - 2), out temp))
                    {
                        numberUpDown.Value = Math.Abs(temp);
                    }
                }
            }
            catch
            {
                numberUpDown.Value = numberUpDown.Minimum;
            }

        }

        /// <summary>
        /// Button handle for open selected directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOpenDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(this.textBoxDestination.Text))
                {
                    Process process = null;
                    try
                    {
                        process = Process.Start(this.textBoxDestination.Text);
                    }
                    finally
                    {
                        if (process != null)
                            process.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Directory doesn't exist.");
                }
            }
            catch (ObjectDisposedException disposedException)
            {
                MessageBox.Show(disposedException.Message);
            }
            catch (FileNotFoundException notFound)
            {
                MessageBox.Show(notFound.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
    }
}
