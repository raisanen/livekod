using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Livekodning.Models {
    public class ProductDatabase {
        public List<Product> Products { get; private set; }

        public delegate void ProductsAddedHandlerMethod(List<Product> products);
        public event ProductsAddedHandlerMethod ProductsAdded;

        public ProductDatabase() {
            Products = new List<Product>();
        }

        public void AddProduct(Product product) {
            Products.Add(product);
            var newProducts = new List<Product>();
            newProducts.Add(product);
            FireProductsAddedEvent(newProducts);
        }

        public void AddProducts(List<Product> products) {
            Products.AddRange(products);
            FireProductsAddedEvent(products);
        }

        public List<Product> GetProductsByType(ProductType type) {
            //var result = new List<Product>();
            //foreach (var product in Products) {
            //    if (product.Type == type) {
            //        result.Add(product);
            //    }
            //}
            //return result;

            return Products
                .Where((Product p) => p.Type == type)
                .ToList();
        }

        private void FireProductsAddedEvent(List<Product> newProducts) {
            if (ProductsAdded != null) {
                ProductsAdded(newProducts);
            }
        }
    }
}
