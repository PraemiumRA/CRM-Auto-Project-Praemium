using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DataModelLibrary;
using System.Data;
using System.Configuration;
using System.Windows.Forms;

namespace BLL
{
    public class TeamMemberProjectBLL
    {
        private DataModel dataModel;
        private Database database;
        public DataTable dataTableValue { get; set; }
        object textBoxValue;
        string comboBoxValue;
        int idValue;

        public TeamMemberProjectBLL(object TextBoxValue, string ComboBoxValue)
        {
            database = new Database(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            dataModel = new DataModel();
            this.comboBoxValue = ComboBoxValue;
            this.textBoxValue = TextBoxValue;
        }

        public void DeleteAsync()
        {
            try
            {
                IdValueCheaker();

                Dictionary<string, object> parameters = new Dictionary<string, object>();

                switch (comboBoxValue)
                {
                    case "TeamID":
                        parameters.Add("@TeamID", Convert.ToInt32(textBoxValue));
                        database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                        break;
                    case "TeamName":
                        parameters.Add("@TeamName", Convert.ToString(textBoxValue));
                        database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                        break;
                    case "MemberID":
                        parameters.Add("@MemberID", Convert.ToInt32(textBoxValue));
                        database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                        break;
                    case "MemberName":
                        parameters.Add("@MemberName", Convert.ToString(textBoxValue));
                        database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                        break;
                    case "MemberSurname":
                        parameters.Add("@MemberSurname", Convert.ToString(textBoxValue));
                        database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                        break;
                    case "ProjectID":
                        parameters.Add("@ProjectID", Convert.ToInt32(textBoxValue));
                        database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                        break;
                    case "ProjectName":
                        parameters.Add("@ProjectName", Convert.ToString(textBoxValue));
                        database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                        break;
                    case "ProjectCreatedDate":
                        parameters.Add("@ProjectCreatedDate", Convert.ToDateTime(textBoxValue));
                        database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                        break;
                    case "ProjectDueDate":
                        parameters.Add("@ProjectDueDate", Convert.ToDateTime(textBoxValue));
                        database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                        break;
                    case "MemberProjectID":
                        parameters.Add("@MemberProjectID", Convert.ToInt32(textBoxValue));
                        database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                        break;
                }
                if (database.affectedRowsCount != 0)
                    MessageBox.Show(string.Format("{0} row(s) were deleted", database.affectedRowsCount.ToString()));

                else MessageBox.Show(string.Format("'{0}' does not exist in {1} column", textBoxValue, comboBoxValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SelectAsync()
        {
            try
            {
                IdValueCheaker();
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                switch (comboBoxValue)
                {
                    case "TeamID":
                        parameters.Add("@TeamID", Convert.ToInt32(textBoxValue));
                        dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                        break;
                    case "TeamName":
                        parameters.Add("@TeamName", Convert.ToString(textBoxValue));
                        dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                        break;
                    case "MemberID":
                        parameters.Add("@MemberID", Convert.ToInt32(textBoxValue));
                        dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                        break;
                    case "MemberName":
                        parameters.Add("@MemberName", Convert.ToString(textBoxValue));
                        dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                        break;
                    case "MemberSurname":
                        parameters.Add("@MemberSurname", Convert.ToString(textBoxValue));
                        dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                        break;
                    case "ProjectID":
                        parameters.Add("@ProjectID", Convert.ToInt32(textBoxValue));
                        dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                        break;
                    case "ProjectName":
                        parameters.Add("@ProjectName", Convert.ToString(textBoxValue));
                        dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                        break;
                    case "ProjectCreatedDate":
                        parameters.Add("@ProjectCreatedDate", Convert.ToDateTime(textBoxValue));
                        dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                        break;
                    case "ProjectDueDate":
                        parameters.Add("@ProjectDueDate", Convert.ToDateTime(textBoxValue));
                        dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                        break;
                    case "AllMembers":
                        parameters.Add("@All", 1);
                        dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                        break;
                    case "AllTeams":
                        parameters.Add("@All", 2);
                        dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                        break;
                    case "AllProjects":
                        parameters.Add("@All", 3);
                        dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                        break;
                    default:
                        MessageBox.Show("Can't find the column");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IdValueCheaker()
        {
            if ((comboBoxValue == "TeamID" || comboBoxValue == "MemberID" || comboBoxValue == "ProjectID" || comboBoxValue == "MemberProjectID"))
            {

                if (int.TryParse(textBoxValue.ToString(), out idValue))
                {
                    if (idValue <= 0)
                    {
                        throw new ArgumentOutOfRangeException("Argument must be bigger than '0' ");
                    }
                }
                else
                {
                    throw new FormatException("Argument must be a number");
                }
            }
        }
    }
}
