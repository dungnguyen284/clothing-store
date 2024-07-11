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

namespace ClothingStore.WPF
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private bool isMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                if (isMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1000;
                    this.Height = 720;
                    isMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    isMaximized = true;
                }
            }
        }

        private void Dashboard_Clicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void Profile_Clicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Profile profile = new Profile();
            profile.Show();
        }

        

        private void Product_Clicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ProductWindow product = new ProductWindow();
            product.Show();
        }

        private void Bill_Clicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BillWindow bill = new BillWindow();
            bill.Show();
        }

        private void Customer_Clicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CustomerWindow customer = new CustomerWindow();
            customer.Show();
        }
        private void Button_Logout(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
