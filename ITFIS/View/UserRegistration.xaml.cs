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
    /// Interakční logika pro UserRegistration.xaml
    /// </summary>
    public partial class UserRegistration : UserControl
    {
        private DatabaseControl databaseControl;
        private UserOverview userOverview;
        public UserRegistration()
        {
            InitializeComponent();
        }
        public void Init(DatabaseControl databaseControl, UserOverview userOverview)
        {
            this.databaseControl = databaseControl;
            this.userOverview = userOverview;
            DataContext = this.databaseControl;
            courseComboBox.ItemsSource = this.databaseControl.Courses;
        }

        private void courseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (courseComboBox.SelectedItem != null)
            {
                courseLabel.Content = ((Course)courseComboBox.SelectedItem).Title;
                descriptionTextBlock.Text = ((Course)courseComboBox.SelectedItem).Description;
                SetRegistration();                
            }
        }

        private void registrationAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (courseComboBox.SelectedItem != null)
            {
                if (databaseControl.IsUserRegistered((Course)courseComboBox.SelectedItem, databaseControl.ActiveUser))
                {
                    MessageBox.Show("V kurzu jste již registrován/a!", "Chyba!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    databaseControl.AddStudentToCourse((Course)courseComboBox.SelectedItem, databaseControl.ActiveUser);                    
                    SetRegistration();
                    userOverview.SourceActualisation();
                }
            }
        }

        private void registrationRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (courseComboBox.SelectedItem != null)
            {
                if (databaseControl.IsUserRegistered((Course)courseComboBox.SelectedItem, databaseControl.ActiveUser))
                {
                    Registration registration = new Registration();
                    registration.CourseId = ((Course)courseComboBox.SelectedItem).Id;
                    registration.UserId = databaseControl.ActiveUser.Id;
                    databaseControl.RemoveStudenFromCourse(registration);
                    SetRegistration();
                    userOverview.SourceActualisation();
                }
                else
                {
                    MessageBox.Show("V kurzu nejste registrován/a!", "Chyba!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void SetRegistration()
        {
            if (databaseControl.IsUserRegistered((Course)courseComboBox.SelectedItem, databaseControl.ActiveUser))
                registrationLabel.Content = "Registrován";
            else
                registrationLabel.Content = "Neregistrován";
        }
    }
}
