using ClothingStore.BLL.CustomResponse;
using ClothingStore.DAL.Models;
using ClothingStore.WPF.DTOs;
using ClothingStore.WPF.PopUpWindows;
using ClothingStore.WPF.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ClothingStore.WPF
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public List<ProductDTO> _products;
        private readonly CategoryService _categoryService;
        private readonly ProductService _productService;
        public ProductWindow()
        {
            InitializeComponent();
            _categoryService = new CategoryService();
            _productService = new ProductService();
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
            Bill bill = new Bill();
            bill.Show();
        }

        private void Customer_Clicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Customer customer = new Customer();
            customer.Show();
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

        private void Cbo_Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategory = (Category)Cbo_Category.SelectedItem;
            if (selectedCategory != null) { 
                if (selectedCategory.Id == 0)
                {
                    dgProducts.ItemsSource = _products;
                    return;
                }
                var products = _products.Where(p => p.Category == selectedCategory.Name).ToList();
                dgProducts.ItemsSource = products;
            }
        }
        private async Task LoadProductList()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                await UpdateProductList(products);
            }catch (Exception ex)
            {
                MessageBox.Show("Product Error: " + ex.Message);
            }
        }
        private async Task LoadCategoryList()
        {
            try
            {
                var categories = await _categoryService.GetCategories();
                var allCategories = new List<Category>();
                allCategories.Add(new Category { Id = 0, Name = "All Categories" });
                allCategories.AddRange(categories);
                Cbo_Category.ItemsSource = allCategories;
                Cbo_Category.DisplayMemberPath = "Name";
                Cbo_Category.SelectedValuePath = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadCategoryList();  
            await LoadProductList();
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
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var dataGridRow = FindAncestor<DataGridRow>(button);
            var product = dataGridRow.Item as ProductDTO;

            EditProductWindow editWindow = new EditProductWindow(product.Id);
            editWindow.ShowDialog();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addWindow = new AddProductWindow();
            addWindow.ShowDialog();
        }
        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var dataGridRow = FindAncestor<DataGridRow>(button);
            var product = dataGridRow.Item as ProductDTO;

            var result = MessageBox.Show($"Are you sure you want to delete {product.Name}?", "Confirm Delete", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // Delete the product from the collection
                var apiResponse = await _productService.DeleteProductById(product.Id);
                var products = await _productService.GetAllProducts();
                await UpdateProductList(products);
            }
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
    }
}
