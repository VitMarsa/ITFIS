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
    /// Interakční logika pro EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        private DatabaseControl databaseControl;
        private User editedUser;
        public EditUser(DatabaseControl databaseControl)
        {
            InitializeComponent();
            this.databaseControl = databaseControl;
        }
        public EditUser(DatabaseControl databaseControl, User user)
        {
            InitializeComponent();
            this.databaseControl = databaseControl;
            editedUser = user;
            nameTextBox.Text = editedUser.Name.Trim();
            surnameTextBox.Text = editedUser.Surname.Trim();
            idTextBox.Text = editedUser.Id.ToString();
            passwordTextBox.Text = editedUser.Password.Trim();
            roleComboBox.SelectedIndex = editedUser.RoleId.Value - 1;
        }
        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            string name;
            string surname;
            string password;
            int role;
            try 
            {
                name = nameTextBox.Text.Trim();
                surname = surnameTextBox.Text.Trim();
                password = passwordTextBox.Text.Trim();
                role = roleComboBox.SelectedIndex + 1;
                if (editedUser == null)
                {
                    User newUser = new User();
                    newUser.Name = name;
                    newUser.Surname = surname;
                    newUser.Password = password;
                    newUser.RoleId = role;
                    databaseControl.AddUser(newUser);
                }
                else
                {
                    editedUser.Name = name;
                    editedUser.Surname = surname;
                    editedUser.Password = password;
                    editedUser.RoleId = role;
                    databaseControl.EditUser(editedUser);
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
