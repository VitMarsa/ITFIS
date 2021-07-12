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
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Interakční logika pro EditCourse.xaml
    /// </summary>
    public partial class EditCourse : Window
    {
        private DatabaseControl databaseControl;
        private Course editedCourse;
        public EditCourse(DatabaseControl databaseControl)
        {
            InitializeComponent();
            this.databaseControl = databaseControl;
            lectorComboBox.ItemsSource = databaseControl.Lectors();
            if (databaseControl.ActiveUser.RoleId == 2)
            {
                lectorComboBox.SelectedItem = databaseControl.ActiveUser;
                lectorComboBox.Visibility = Visibility.Hidden;
            }
        }
        public EditCourse(DatabaseControl databaseControl, Course course)
        {
            InitializeComponent();
            this.databaseControl = databaseControl;
            lectorComboBox.ItemsSource = databaseControl.Lectors();
            editedCourse = course;
            nameTextBox.Text = editedCourse.Title.Trim();
            capacityTextBox.Text = editedCourse.Capacity.ToString().Trim();
            descriptionTextBox.Text = editedCourse.Description.Trim();
            if (databaseControl.ActiveUser.RoleId == 2)
            {
                lectorComboBox.SelectedItem = databaseControl.ActiveUser;
                lectorComboBox.Visibility = Visibility.Hidden;
            }
            else if (databaseControl.ActiveUser.RoleId == 1)
            {
                lectorComboBox.SelectedItem = databaseControl.FindUser(editedCourse.LectorId.Value);
            }
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            string name;
            int lector;
            int capacity;
            string description;
            try
            {
                name = nameTextBox.Text.Trim();
                if (lectorComboBox.SelectedItem != null)
                    lector = ((User)lectorComboBox.SelectedItem).Id;
                else if (databaseControl.ActiveUser.RoleId == 2)
                {
                    lector = databaseControl.ActiveUser.Id;
                }
                else
                    throw new Exception("Je třeba doplnit lektora!");
                capacity = int.Parse(capacityTextBox.Text);
                description = descriptionTextBox.Text.Trim();
                if (editedCourse == null)
                {
                    Course newCourse = new Course();
                    newCourse.Title = name;
                    newCourse.LectorId = lector;
                    newCourse.Capacity = capacity;
                    newCourse.Description = description;
                    databaseControl.AddCourse(newCourse);
                }
                else
                {
                    editedCourse.Title = name;
                    editedCourse.LectorId = lector;
                    editedCourse.Capacity = capacity;
                    editedCourse.Description = description;
                    databaseControl.EditCourse(editedCourse);
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
