using ClothingStore.DAL.Models;
using ClothingStore.DAL.Repositories.Implementations;
using ClothingStore.DAL.Repositories.Interfaces;
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
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;
        public AddProductWindow()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
            InitializeComponent();
        }
        private async Task LoadCategoryList()
        {
            try
            {
                var categories = await _categoryService.GetCategories();
                cboCategory.ItemsSource = categories;
                cboCategory.DisplayMemberPath = "Name";
                cboCategory.SelectedValuePath = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadCategoryList();
        }
        public void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ProductName = txtProductName.Text;
                var UnitPrice = Convert.ToDouble(txtPrice.Text);
                var UnitsInStock = short.Parse(txtUnitsInStock.Text);
                var CategoryId = Convert.ToInt32(cboCategory.SelectedValue);
                var description = txtDescription.Text;
                var category = await _categoryService.GetCategory(CategoryId);
                Product product = new Product {IsDeleted = false, Name = ProductName, Quantity = UnitsInStock, Price = UnitPrice, CategoryId = CategoryId, Description = description, Image="", Category = category };
                await _productService.AddProduct(product);
                MessageBox.Show("Product added successfully");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
