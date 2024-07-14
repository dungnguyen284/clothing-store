using ClothingStore.DAL.Models;
using ClothingStore.WPF.DTOs;
using ClothingStore.WPF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for CreateBillWindow.xaml
    /// </summary>
    public partial class CreateBillWindow : Window
    {
        public List<ProductDTO> _products;
        public ObservableCollection<BillDetail> billDetails = new ObservableCollection<BillDetail>();
        public CategoryService _categoryService;
        private ProductService _productService;
        private BillService _billService;
        private BillDetailService _billDetailService;

        public static double total = 0;
        public CreateBillWindow()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
            _billService = new BillService();
            _billDetailService = new BillDetailService();
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
            if (e.ClickCount == 2)
            {
                this.Close();
                BillWindow billWindow = new BillWindow();
                billWindow.Show();
            }
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadProductList();
            dgBillItems.ItemsSource = billDetails;
        }
        private async Task LoadProductList()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                await UpdateProductList(products);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product Error: " + ex.Message);
            }
        }
        private async Task UpdateProductList(List<Product> products)
        {
            var productDTOs = new List<ProductDTO>();

            foreach (var product in products)
            {
                var category = await _categoryService.GetCategory(product.CategoryId);
                var productDTO = new ProductDTO
                {
                    Id = product.Id,
                    Category = category != null ? category.Name : "Unknown",
                    Price = product.Price,
                    Name = product.Name,
                    Quantity = product.Quantity
                };
                productDTOs.Add(productDTO);
            }

            _products = productDTOs;
            dgProducts.ItemsSource = _products;
        }
        private void Search_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var name = txtSearch.Text == null ? "" : txtSearch.Text;
                var products = _products.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
                dgProducts.ItemsSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product Error: " + ex.Message);
            }
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var dataGridRow = FindAncestor<DataGridRow>(button);
            var product = dataGridRow.Item as ProductDTO;
            
            var inStock = product.Quantity;
            var billDetailEx = billDetails.FirstOrDefault(bd => bd.ProductId == product.Id);
            if (billDetailEx != null && billDetailEx.Quantity < inStock)
            {
                billDetails.Remove(billDetailEx);
                var newBillDetail = new BillDetail
                {
                    ProductId = billDetailEx.ProductId,
                    Product = billDetailEx.Product,
                    Quantity = billDetailEx.Quantity + 1,
                    BillId = 0
                };
                billDetails.Add(newBillDetail);
                total+= billDetailEx.Product.Price;
                dgBillItems.ItemsSource = billDetails;
                price.Text ="Total price: "+ total.ToString();
                return;
            }
            
            BillDetail billDetail = new BillDetail
            {
                ProductId = product.Id,
                Product = await _productService.GetProductById(product.Id),
                Quantity = 1,
                BillId = 0
            };
            total += billDetail.Product.Price;
            billDetails.Add(billDetail);
            price.Text = "Total price: " + total.ToString();
            dgBillItems.ItemsSource = billDetails;
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var dataGridRow = FindAncestor<DataGridRow>(button);
            var billDetail = dataGridRow.Item as BillDetail;
            billDetails.Remove(billDetail);
            dgBillItems.ItemsSource = billDetails;
            total -= billDetail.Product.Price*billDetail.Quantity;
            price.Text = "Total price: " + total.ToString();

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

        private async void PurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            if(total > 0)
            {
                Bill bill = new Bill
                {
                    CustomerId = 3,
                    Date = DateTime.Now,
                    TotalPrice = total,
                    BillDetails = new List<BillDetail>(billDetails)
                };
                await _billService.AddBill(bill);
                foreach (var billDetail in billDetails)
                {
                    //var product = await _productService.GetProductById(billDetail.ProductId);
                    //product.Quantity -= billDetail.Quantity;
                    //await _productService.UpdateProduct(product.Id, product);
                    billDetail.BillId = bill.Id;
                    await _billDetailService.AddBillDetail(billDetail);
                }
                var QRCode = new QRCode(total);
                QRCode.Show();
            }
            else
            {
                MessageBox.Show("Please add products to the bill");
                return;
            }
            

        }
    }
}
