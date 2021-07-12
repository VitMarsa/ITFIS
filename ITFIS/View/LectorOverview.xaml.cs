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
using ITFIS;

namespace View
{
    /// <summary>
    /// Interakční logika pro LectorOverview.xaml
    /// </summary>
    public partial class LectorOverview : UserControl
    {
        private DatabaseControl databaseControl;
        public LectorOverview()
        {
            InitializeComponent();
        }
        public void Init(DatabaseControl databaseControl)
        {
            this.databaseControl = databaseControl;
            DataContext = this.databaseControl;
            userComboBox.ItemsSource = databaseControl.Students();
            SourceActualisation();
        }
        public void SourceActualisation()
        {
            courseComboBox.ItemsSource = null;
            if (databaseControl != null)
                courseComboBox.ItemsSource = databaseControl.Courses;            
        }
        private void coursesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (courseComboBox.SelectedItem != null)
            {
                userListBox.ItemsSource = databaseControl.StudentsByCourse(((Course)courseComboBox.SelectedItem).Id);
                courseNameLabel.Content = ((Course)courseComboBox.SelectedItem).Title;
                courseCapacityLabel.Content = ((Course)courseComboBox.SelectedItem).Capacity.ToString();
                userListBox.UnselectAll();
            }
            else
            {
                userListBox.ItemsSource = null;
                courseNameLabel.Content = null;
                courseCapacityLabel.Content = null;
            }
        }

        private void userComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (userComboBox.SelectedItem != null)
            {
                newUserNameLabel.Content = ((User)userComboBox.SelectedItem).Name.Trim() + " " + ((User)userComboBox.SelectedItem).Surname.Trim();
                newUserIDLabel.Content = ((User)userComboBox.SelectedItem).Id.ToString();
            }
        }

        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            if ((userComboBox.SelectedItem != null) && (courseComboBox.SelectedItem != null))
            {
                if ((((Course)courseComboBox.SelectedItem).LectorId == databaseControl.ActiveUser.Id) || (databaseControl.ActiveUser.RoleId == 1))
                {
                    try
                    {
                        databaseControl.AddStudentToCourse((Course)courseComboBox.SelectedItem, (User)userComboBox.SelectedItem);
                        userListBox.ItemsSource = databaseControl.StudentsByCourse(((Course)courseComboBox.SelectedItem).Id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Chyba při registraci!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Nemáte oprávnění upravit tento kurz!", "Chyba!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void userListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((userListBox.SelectedItem != null) && (courseComboBox.SelectedItem != null))
            {
                registredUserNameLabel.Content = ((User)userListBox.SelectedItem).Name.Trim() + " " + ((User)userListBox.SelectedItem).Surname.Trim();
                registredUserIDLabel.Content = ((User)userListBox.SelectedItem).Id.ToString();
                selectedUserNameLabel.Content = ((User)userListBox.SelectedItem).Name.Trim() + " " + ((User)userListBox.SelectedItem).Surname.Trim();
                selectedUserIDLabel.Content = ((User)userListBox.SelectedItem).Id.ToString();
                classificationListBox.ItemsSource = databaseControl.ClassificationOfStudentInCourse((Course)courseComboBox.SelectedItem, (User)userListBox.SelectedItem);
            }
            else
            {
                registredUserNameLabel.Content = "";
                registredUserIDLabel.Content = "";
                selectedUserNameLabel.Content = "";
                selectedUserIDLabel.Content = "";
                classificationListBox.ItemsSource = null;
            }
        }

        private void removeUser_Click(object sender, RoutedEventArgs e)
        {
            if ((userListBox.SelectedItem != null) && (courseComboBox.SelectedItem != null))
            {
                if ((((Course)courseComboBox.SelectedItem).LectorId == databaseControl.ActiveUser.Id) || (databaseControl.ActiveUser.RoleId == 1))
                {
                    Registration registration = new Registration();
                    registration.CourseId = ((Course)courseComboBox.SelectedItem).Id;
                    registration.UserId = ((User)userListBox.SelectedItem).Id;
                    databaseControl.RemoveStudenFromCourse(registration);
                    databaseControl.RemoveAllClassicationOfStudentInCourse((Course)courseComboBox.SelectedItem, (User)userListBox.SelectedItem);

                    userListBox.ItemsSource = databaseControl.StudentsByCourse(((Course)courseComboBox.SelectedItem).Id);
                    userListBox.UnselectAll();
                    classificationListBox.ItemsSource = null;
                }
                else
                {
                    MessageBox.Show("Nemáte oprávnění upravit tento kurz!", "Chyba!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void addClassificationButton_Click(object sender, RoutedEventArgs e)
        {
            if ((userListBox.SelectedItem != null) && (courseComboBox.SelectedItem != null))
            {
                if ((((Course)courseComboBox.SelectedItem).LectorId == databaseControl.ActiveUser.Id) || (databaseControl.ActiveUser.RoleId == 1))
                {
                    Classification classification = new Classification();
                    classification.CourseId = ((Course)courseComboBox.SelectedItem).Id;
                    classification.UserId = ((User)userListBox.SelectedItem).Id;
                    classification.GradeId = gradeComboBox.SelectedIndex + 1;
                    databaseControl.AddClassification(classification);
                    classificationListBox.ItemsSource = databaseControl.ClassificationOfStudentInCourse((Course)courseComboBox.SelectedItem, (User)userListBox.SelectedItem);
                }
                else
                {
                    MessageBox.Show("Nemáte oprávnění upravit tento kurz!", "Chyba!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void removeClassificationButton_Click(object sender, RoutedEventArgs e)
        {
            if (classificationListBox.SelectedItem != null)
            {
                if ((((Course)courseComboBox.SelectedItem).LectorId == databaseControl.ActiveUser.Id) || (databaseControl.ActiveUser.RoleId == 1))
                {
                    databaseControl.RemoveClassification((Classification)classificationListBox.SelectedItem);
                    classificationListBox.ItemsSource = databaseControl.ClassificationOfStudentInCourse((Course)courseComboBox.SelectedItem, (User)userListBox.SelectedItem);
                }
                else
                {
                    MessageBox.Show("Nemáte oprávnění upravit tento kurz!", "Chyba!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }
    }
}
