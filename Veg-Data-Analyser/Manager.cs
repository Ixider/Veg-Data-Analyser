using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veg_Data_Analyser
{
    public class Manager
    {
        List<Task> tasks;
        Data.DatabaseManager databaseManager;
        System.Windows.Controls.DataGrid dataGrid;
        System.Windows.Controls.Label totalLabel;

        public Manager(System.Windows.Controls.DataGrid dg, System.Windows.Controls.Label tLabel)
        {
            databaseManager = new Data.DatabaseManager();
            tasks = new List<Task>();

            dataGrid = dg;
            totalLabel = tLabel;
            
            GetAllTasks();
        }

        public void ImportData()
        {
            databaseManager.OpenFile();
            GetAllTasks();
        }

        public void ClearData()
        {
            databaseManager.ClearData();
            GetAllTasks();
        }

        public void ApplyNeedsNoticeFilter()
        {
            tasks = databaseManager.GetTasksNeedingNotice();
            updateTasks();
        }

        public void GetAllTasks()
        {
            tasks = databaseManager.GetAllTasks();
            updateTasks();
        }

        public void FilterTaskProgress(string name, bool isChecked) 
        {
            // Determins if checkbox is being checked or unchecked
            if (!isChecked)
            {
                removalTaskProgressItems(name);

            }
            else
            {
                addTaskProgressItems(name);
            }

            sortTasks();
            updateTasks();
        }

        ///////// PRIVATE FUNCTIONS ////////////

        private void sortTasks()
        {
            tasks = tasks.OrderBy(t => t.task_number).ToList();
        }

        // Refresh the data showing inthe datagrid
        private void updateTasks()
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = tasks;
            totalLabel.Content = Convert.ToString(tasks.Count());
        }

        //Removes all tasks with the specified froup from the main tasks list
        private void removalTaskProgressItems(string group)
        {
            foreach (Task t in tasks.ToList())
            {
                if (t.task_progress.Equals(group))
                {
                    tasks.Remove(t);
                }
            }
        }

        //Gets and adds all tasks of given type and adds them to the list if they dont already exist within the list
        private void addTaskProgressItems(string name)
        {
            List<Task> taskList = databaseManager.GetAllTasksOfGroup(name);

            foreach (Task t in taskList)
            {
                if (!tasks.Contains(t))
                {
                    tasks.Add(t);
                }
            }
        }

    }
}
