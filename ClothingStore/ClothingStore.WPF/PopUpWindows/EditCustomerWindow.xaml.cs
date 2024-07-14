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
    /// Interaction logic for EditCustomerWindow.xaml
    /// </summary>
    public partial class EditCustomerWindow : Window
    {
        private int id;
        private readonly  CustomerService customerService;
        public EditCustomerWindow(int id)
        {
            InitializeComponent();
            this.id = id;
            customerService = new CustomerService();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var customer = await customerService.GetCustomerById(id);
            txtName.Text = customer.UserName;
            txtId.Text = customer.Id.ToString();
            txtPhone.Text = customer.Phone;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            await customerService.UpdateCustomer(id, new DAL.Models.Customer
            {
                Id = id,
                UserName = txtName.Text,
                Phone = txtPhone.Text,
                SavePoints = 0
            });
            MessageBox.Show("Updated customer successfully");
        }
    }
}
