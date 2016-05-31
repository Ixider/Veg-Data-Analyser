using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Veg_Data_Analyser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

 
        Manager manager;

        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void importButton_Click(object sender, RoutedEventArgs e)
        {
            manager.ImportData();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            manager = new Manager(taskDataGrid, totalLabel);
        }


        private void ClearData_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to empty the database?", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                manager.ClearData();
            }
        }

        private void needsNoticeButton_Click(object sender, RoutedEventArgs e)
        {
            clearFilters();
            manager.ApplyAssessmentAndNoNoticeFilter();
        }

        private void hasNoticeButton_Click(object sender, RoutedEventArgs e)
        {
            clearFilters();
            manager.ApplyAssessmentAndHasNoticeFilter();
            
        }

        private void clearFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            resetCheckBoxs();
            manager.GetAllTasks();
        }

        // Task Progess Items
        private void Open_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox s = (CheckBox)sender;
            bool c = s.IsChecked.Value;
            sendCheckBoxData(0, "Open", c); // String litterals are not a good idea //TODO change to enum
        }

        private void InProgress_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox s = (CheckBox)sender;
            bool c = s.IsChecked.Value;
            sendCheckBoxData(0, "In Progress", c);
        }

        private void Cancelled_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox s = (CheckBox)sender;
            bool c = s.IsChecked.Value;
            sendCheckBoxData(0, "Cancelled", c);
        }

        private void Closed_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox s = (CheckBox)sender;
            bool c = s.IsChecked.Value;
            sendCheckBoxData(0, "Closed", c);
        }

        private void OnHold_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox s = (CheckBox)sender;
            bool c = s.IsChecked.Value;
            sendCheckBoxData(0, "On Hold", c);
        }

        private void sendCheckBoxData(int i, string s, bool b)
        {
            if (!isManagerNull())
            {
                manager.FilterTaskItems(i, s, b);
            }
        }

        private bool isManagerNull()
        {
            if (manager == null)
            {
                return true;
            }

            return false;
        }

        // Should be called before applying anyfilter
        private void clearFilters()
        {
            resetCheckBoxs();
            manager.GetAllTasks();
        }

        private void resetCheckBoxs()
        {
            OpenCheckBox.IsChecked = true;
            InProgressCheckBox.IsChecked = true;
            CancelledCheckBox.IsChecked = true;
            ClosedCheckBox.IsChecked = true;
            OnHoldCheckBox.IsChecked = true;
        }
    }
}
