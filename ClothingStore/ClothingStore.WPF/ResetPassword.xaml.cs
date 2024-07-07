using ClothingStore.BLL.CustomResponse;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    /// Interaction logic for ResetPassword.xaml
    /// </summary>
    public partial class ResetPassword : Window
    {
        public ResetPassword()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void btnReset_Click(object sender, RoutedEventArgs e)
        {
            var email = txtEmail.Text;
            try
            {
                var json = JsonConvert.SerializeObject(email);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                // Ensure HttpClient is properly initialized
                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync(Api.forgotPasswordApi, data);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var resetPasswordResponse = JsonConvert.DeserializeObject<ApiResponse<bool>>(result);
                        if (resetPasswordResponse.IsSuccess)
                        {
                            MessageBox.Show("Password has been sent, check your mail");
                        }
                        else
                        {
                            MessageBox.Show("Password sent failed: " + resetPasswordResponse.Message);
                        }
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Password sent failed: {response.StatusCode} - {response.ReasonPhrase}\n{errorContent}");
                    }
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                MessageBox.Show($"Request error: {httpRequestException.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
