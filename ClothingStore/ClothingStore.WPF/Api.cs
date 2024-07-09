using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.WPF
{
    public static class Api
    {
        //authentication
        public static string loginApi = "https://localhost:7295/api/authentication/login";
        public static string forgotPasswordApi = "https://localhost:7295/api/authentication/forgot-password";
        public static string changePasswordApi = "https://localhost:7295/api/authentication/change-password/";
        
        //product
        public static string getAllProductsApi = "https://localhost:7295/api/products";
        public static string getProductByIdApi = "https://localhost:7295/api/products/";
        public static string getProductByCategoryIdApi = "https://localhost:7295/api/products/category/";
        public static string getProductByNameApi = "https://localhost:7295/api/products/search?Name=";


        //category
        public static string getAllCategoriesApi = "https://localhost:7295/api/categories";
        public static string getCategoryByIdApi = "https://localhost:7295/api/categories/";
    }
}
