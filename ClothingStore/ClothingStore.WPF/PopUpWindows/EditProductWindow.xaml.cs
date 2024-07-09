using ClothingStore.DAL.Models;
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
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;
        private readonly int id;
        public EditProductWindow(int productId)
        {
            id = productId;
            _productService = new ProductService();
            _categoryService = new CategoryService();
            InitializeComponent();
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
                var id = Convert.ToInt32(txtProductID.Text);
                var category = await _categoryService.GetCategory(CategoryId);
                Product product = new Product { Id = id, IsDeleted = false, Name = ProductName, Quantity = UnitsInStock, Price = UnitPrice, CategoryId = CategoryId,Category = category, Description = description, Image="" };
                await _productService.UpdateProduct(id, product);
                MessageBox.Show("Product updated successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadCategoryList();
            await LoadProduct();

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
        private async Task LoadProduct()
        {
            var product = await _productService.GetProductById(id);
            txtDescription.Text = product.Description;
            txtPrice.Text = Convert.ToString(product.Price);
            txtProductID.Text = Convert.ToString(product.Id);
            txtProductName.Text = product.Name;
            txtUnitsInStock.Text = Convert.ToString(product.Quantity);
            cboCategory.SelectedValue = product.CategoryId;
        }
    }
}
