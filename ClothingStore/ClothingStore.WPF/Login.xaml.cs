using ClothingStore.BLL.CustomResponse;
using ClothingStore.BLL.DTOs;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
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

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUser.Text;
            var password = txtPass.Password;
            try
            {
                var loginRequest = new LoginRequest
                {
                    Username = username,
                    Password = password
                };
                var json = JsonConvert.SerializeObject(loginRequest);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                // Ensure HttpClient is properly initialized
                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync(Api.loginApi, data);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var loginResponse = JsonConvert.DeserializeObject<ApiResponse<bool>>(result);
                        if (loginResponse.IsSuccess)
                        {
                            this.Hide();
                            Home home = new Home();
                            home.Show();
                        }
                        else
                        {
                            MessageBox.Show("Login failed: " + loginResponse.Message);
                        }
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Login failed: {response.StatusCode} - {response.ReasonPhrase}\n{errorContent}");
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

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ResetPassword resetPassword = new ResetPassword();
            resetPassword.Show();
        }
    }
}

