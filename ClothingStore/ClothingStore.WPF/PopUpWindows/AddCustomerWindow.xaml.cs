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

namespace ClothingStore.WPF.PopUpWindows
{
    /// <summary>
    /// Interaction logic for AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        private readonly CustomerService customerService;
        public AddCustomerWindow()
        {
            customerService = new CustomerService();
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var customer = new DAL.Models.Customer
            {
                UserName = txtName.Text,
                Phone = txtPhone.Text,
                SavePoints = 0
            };
            await customerService.AddCustomer(customer);
            MessageBox.Show("Added customer successfully");
        }
    }
}
