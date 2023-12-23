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
using Сursovaya.Context;
using Сursovaya.Controllers;

namespace Сursovaya
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyDbContext _db;
        public MainWindow()
        {
            _db = new MyDbContext();
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (UserController.SignIn(login.Text, password.Text, _db)==false)
            {
                MessageBox.Show("Un correct input data");
            }
            else
            {
                Menu menu = new Menu();
                menu.Show();
            }
        }
    }
}