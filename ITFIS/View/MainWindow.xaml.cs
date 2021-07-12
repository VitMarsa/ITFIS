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
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DatabaseControl databaseControl;
        public MainWindow()
        {
            databaseControl = new DatabaseControl();
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if ((idTextBox.Text != "") && (passwordTextBox.Text != ""))
            {
                try
                {
                    databaseControl.SetActiveUser(int.Parse(idTextBox.Text));
                    if (!databaseControl.CheckPassword(passwordTextBox.Text))
                    {
                        MessageBox.Show("Zkontrolujte přihlašovací údaje!", "Neplatné heslo!", MessageBoxButton.OK, MessageBoxImage.Exclamation);                        
                    }
                    else
                    {
                        UserWindow window = new UserWindow(databaseControl);
                        window.ShowDialog();
                        Close();
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message, "Chyba!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                catch
                {
                    MessageBox.Show("Zkontrolujte přihlašovací údaje!", "Uživatel nenalezen!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Neplatné údaje!", "Neplatné údaje!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
