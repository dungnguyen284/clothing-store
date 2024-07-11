using ClothingStore.WPF.DTOs;
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
    /// Interaction logic for BillDetailsWindow.xaml
    /// </summary>
    public partial class BillDetailsWindow : Window
    {
        private readonly BillDetailService _billDetailService;
        private readonly BillService _billService;
        private readonly CustomerService _customerService;
        private readonly ProductService _productService;
        private int id;
        public BillDetailsWindow(int billId)
        {
            InitializeComponent();
            _billDetailService = new BillDetailService();
            _billService = new BillService();
            _customerService = new CustomerService();
            _productService = new ProductService();
            id = billId;
        }
        public async Task LoadBillDetails(int billId)
        {
            try
            {
                var billDetails = await _billDetailService.GetBillDetails(billId);
                var bill = await _billService.GetBillById(billId);
                var billDetailDtos = new List<BillDetailDTO>();
                foreach (var item in billDetails)
                {
                    var product = await _productService.GetProductById(item.ProductId);
                    billDetailDtos.Add(new BillDetailDTO
                    {
                        Id = item.Id,
                        BillId = item.BillId,
                        ProductName = product.Name,
                        Quantity = item.Quantity,
                        Price = product.Price * item.Quantity
                    }) ;
                }
                var customer = await _customerService.GetCustomerById(bill.CustomerId);
                txtID.Text = bill.Id.ToString();
                txtName.Text = customer.UserName;
                txtDate.Text = bill.Date.ToString();
                txtPrice.Text = bill.TotalPrice.ToString();
                dgData.ItemsSource = billDetailDtos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadBillDetails(id);
        }
    }
}
