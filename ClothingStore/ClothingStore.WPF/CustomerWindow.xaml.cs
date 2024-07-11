using ClothingStore.DAL.Models;
using ClothingStore.WPF.DTOs;
using ClothingStore.WPF.PopUpWindows;
using ClothingStore.WPF.Services;
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
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private readonly CustomerService _customerService;
        public List<Customer> _customers;
        public CustomerWindow()
        {
            InitializeComponent();
            _customerService = new CustomerService();
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
        private void Search_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var name = txtSearch.Text == null ? "" : txtSearch.Text;
                var products = _customers.Where(p => p.UserName.ToLower().Contains(name.ToLower()) || p.Phone.Contains(name)).ToList();
                dgCustomers.ItemsSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product Error: " + ex.Message);
            }
        }

        private async Task LoadCustomerList()
        {
            try
            {
                var customers = await _customerService.GetCustomers();
                UpdateCustomerList(customers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product Error: " + ex.Message);
            }
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadCustomerList();
        }

        private void UpdateCustomerList(List<Customer> customers)
        {
            _customers = customers;
            dgCustomers.ItemsSource = _customers;
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var dataGridRow = FindAncestor<DataGridRow>(button);
            var customer = dataGridRow.Item as Customer;

            EditCustomerWindow editWindow = new EditCustomerWindow(customer.Id);
            editWindow.ShowDialog();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow addWindow = new AddCustomerWindow();
            addWindow.ShowDialog();
        }



        private T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }
        private void Button_Logout(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
