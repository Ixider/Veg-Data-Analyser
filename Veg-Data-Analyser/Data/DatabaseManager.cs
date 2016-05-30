using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Office.Interop.Excel;

namespace Veg_Data_Analyser.Data
{
    public class DatabaseManager
    {

        public enum DataField { TaskNo = 0, TaskProgress = 1, Assesment = 2, Inspection = 3, Notice = 4, FellOrTrim = 5, AssessmentDate = 6, MetersExposed = 7 };  

        public DatabaseManager()
        {

        }

        // QUERY FUNCTIONS 
        public List<Task> GetAllTasks()
        {
            using (var db = new Veg_Connection())
            {
                var query = from r in db.Tasks select r;

                return listafyQuery(query);
            }
        }

        public List<Task> GetTasksNeedingNotice()
        {
            using (var db = new Veg_Connection())
            {

                var query = from t in db.Tasks
                            where t.assesment == "Yes" && t.notice == "No"
                            select t;

                return listafyQuery(query);
            }
        }

        public List<Task> GetAllTasksOfGroup(string groupName)
        {
            using(var db = new Veg_Connection()) 
            {
                var query = from t in db.Tasks
                            where t.task_progress == groupName
                            select t;

                return listafyQuery(query);
            }
        }


        /// ADD NEW XLSX DATA SET
        //Opens dialog for user to select csv file
        public void OpenFile()
        {
            // Create OpenFileDialog 
            OpenFileDialog dlg = new OpenFileDialog();

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            dlg.Filter = "CSV files (*.csv)|*.csv|XML files (*.xml)|*.xml";

            // Get the selected file name
            if (result == true)
            {
                //Get file name
                string fileName = dlg.FileName;

                //Get the file names extension
                string ext = Path.GetExtension(fileName);

                //Check file extension is csv
                if (ext.Equals(".xlsx"))
                {
                    // Open document 
                    //readFile(fileName);
                    importData(fileName);
                }

            }
        }

        // Reads excel file
        public void importData(string filename)
        {
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties='Excel 12.0;IMEX=1;HDR=YES;'";


            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                OleDbCommand command = new OleDbCommand("SELECT DISTINCT [Task No], [Task Status], [Work Flow Site Assessment], [Work Flow Final Inspection], [Work Flow Issue Notice], [Work Flow Fell Or Trim], [WFSA Onsite Dttm], [WFSA Length Exposed] FROM [Publish_VegAllData$]", conn);
                conn.Open();
                OleDbDataReader reader = command.ExecuteReader();

                Task currTask = new Task();
                reader.Read();
                while (reader.Read())
                {
                    string status = reader.GetString(1);

                    currTask.task_number = Convert.ToInt32(reader.GetValue(0));
                    currTask.task_progress = reader.GetString(1);
                    currTask.assesment = reader.GetString(2);
                    currTask.inspection = reader.GetString(3);
                    currTask.notice = reader.GetString(4);
                    currTask.fellortrim = reader.GetString(5);

                    DateTime dt = new DateTime();
                    try
                    {
                        dt = reader.GetDateTime(6);
                        currTask.assessment_date = dt;
                    }
                    catch (Exception e)
                    {
                        currTask.assessment_date = null;
                    }

                    currTask.meters_exposed = Convert.ToInt32(reader.GetValue(7));
                    saveTask(currTask);  
                }

                conn.Close();
            }

        }

        public void ClearData()
        {
            using (var db = new Veg_Connection())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Tasks]");
            }
        }


        ///////////// PRIVATE FUNCITONS //////////

        private void saveTask(Task task)
        {
            using (var db = new Veg_Connection())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }
        }

        private List<Task> listafyQuery(IQueryable<Task> query)
        {
            List<Task> tasks = new List<Task>();

            foreach (var t in query)
            {
                tasks.Add(t);
            }

            return tasks;
        }

    }
}
