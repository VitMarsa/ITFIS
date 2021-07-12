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
    /// Interakční logika pro UserAbout.xaml
    /// </summary>
    public partial class UserAbout : UserControl
    {
        private DatabaseControl databaseControl;
        public UserAbout()
        {
            InitializeComponent();
        }

        public void Init(DatabaseControl databaseControl)
        {
            this.databaseControl = databaseControl;
            DataContext = databaseControl.ActiveUser;
            roleLabel.Content = databaseControl.Roles[databaseControl.ActiveUser.RoleId.Value - 1].Title;
        }
    }
}
