using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livekodning.Models {
    public class ProductDatabase {
        public List<Product> Products { get; private set; }

        public delegate void ProductsAddedHandlerMethod(List<Product> products);
        public event ProductsAddedHandlerMethod ProductsAdded;

        public ProductDatabase() { Products = new List<Product>(); }
        private void FireProductsAddedEvent(List<Product> newProducts) {
            if (ProductsAdded != null) {
                ProductsAdded(newProducts);
            }
        }
        public bool NameIsSame(Product p, Product otherProduct) {
            return p.Name == otherProduct.Name;
        }

        public async Task AddProduct(Product product) {
            if (Products.Any(p => p.Name == product.Name)) {
                return;
            }
            var newProducts = new List<Product>();
            newProducts.Add(product);
            await AddProducts(newProducts);
        }

        public async Task AddProducts(List<Product> products) {
            await Task.Run(() => {
                Products.AddRange(products);
                FireProductsAddedEvent(products);
            });
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
        public List<Product> GetProductsWithPriceBetween(decimal min, decimal max) {
            return Products
                .Where((p) => p.Price > min && p.Price < max)
                .ToList();
        }

        public List<Product> GetProductsSortedByName() {
            return Products
                .OrderBy((p) => p.Name)
                    .ThenBy((p) => p.Price)
                .ToList();
        }

        public List<string> GetProductNames() {
            return Products
                .Select((p) => p.Name)
                .OrderBy(n => n.ToUpper())
                .ToList();
        }
    }
}
