using ITFIS;
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

namespace View
{
    /// <summary>
    /// Interakční logika pro UserOverview.xaml
    /// </summary>
    public partial class UserOverview : UserControl
    {
        private DatabaseControl databaseControl;
        public UserOverview()
        {
            InitializeComponent();
        }
        public void Init(DatabaseControl databaseControl)
        {
            this.databaseControl = databaseControl;
            DataContext = this.databaseControl;
            SourceActualisation();
        }

        private void courseListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (courseListBox.SelectedItem != null)
            {
                classificationListBox.ItemsSource = databaseControl.ClassificationOfStudentInCourse((Course)courseListBox.SelectedItem, databaseControl.ActiveUser);
            }
            else 
            {
                classificationListBox.ItemsSource = null;
            }
        }

        public void SourceActualisation()
        {
            courseListBox.ItemsSource = this.databaseControl.CoursesByUser(databaseControl.ActiveUser);
        }

    }
}
