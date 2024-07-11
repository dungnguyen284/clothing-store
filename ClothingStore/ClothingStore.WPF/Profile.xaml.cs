using ClothingStore.WPF.Services;
using System.Windows;
using System.Windows.Input;

namespace ClothingStore.WPF
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        private readonly AccountService _accountService;
        public Profile()
        {
            InitializeComponent();
            _accountService = new AccountService();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private bool isMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
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
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string oldPassword = txtOldPass.Password;
            string newPassword = txtNewPass.Password;
            string confirmPassword = txtCfPass.Password;
            var admin = await _accountService.GetAccountByName("admin");
            if(oldPassword != admin.Password)
            {
                MessageBox.Show("Old password is incorrect"); return;
            }
            if(newPassword != confirmPassword)
            {
                MessageBox.Show("Confirm password does not ma"); return;
            }
            try
            {
                await _accountService.ChangePassword(new BLL.DTOs.ChangePasswordRequest
                {
                    OldPassword = oldPassword,
                    NewPassword = newPassword,
                    ConfirmPassword = confirmPassword
                });
                MessageBox.Show("Change password successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
        }
        private void Button_Logout(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}

