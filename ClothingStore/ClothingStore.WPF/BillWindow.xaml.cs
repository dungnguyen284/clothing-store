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
    /// Interaction logic for Bill.xaml
    /// </summary>
    public partial class BillWindow : Window
    {
        public List<BillDTO> _bills;
        private readonly BillService _billService;
        private readonly BillDetailService _billDetailService;
        private readonly CustomerService _customerService;
        public BillWindow()
        {
            InitializeComponent();
            _customerService = new CustomerService();
            _billDetailService = new BillDetailService();
            _billService = new BillService();   
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
        private void Button_Logout(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
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
        private async Task LoadBillList()
        {
            try
            {
                var products = await _billService.GetBills();
                await UpdateBillList(products);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product Error: " + ex.Message);
            }
        }
        
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadBillList();

        }
        private async Task UpdateBillList(List<Bill> bills)
        {
            var billDTOs = new List<BillDTO>();

            foreach (var bill in bills)
            {
                var customer = await _customerService.GetCustomerById(bill.CustomerId);
                var billDTO = new BillDTO
                {
                    Id = bill.Id,
                    Customer = customer.UserName,
                    Date = bill.Date,
                    TotalPrice = bill.TotalPrice
                };
                billDTOs.Add(billDTO);
            }

            _bills = billDTOs;
            dgProducts.ItemsSource = _bills;
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var dataGridRow = FindAncestor<DataGridRow>(button);
            var bill = dataGridRow.Item as BillDTO;

            BillDetailsWindow editWindow = new BillDetailsWindow(bill.Id);
            editWindow.ShowDialog();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }
        //private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        //{

        //}
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
    }
}
