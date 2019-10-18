using Livekodning.Exceptions;
using Livekodning.Interfaces;
using Livekodning.Models;
using Livekodning.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Livekodning {
    class Program {
        static void HandleProductsAdded(List<Product> newProducts) {
            foreach (var product in newProducts) {
                Console.WriteLine("Added new Product: " + product.GetPrintableString());
            }
        }
        static void Main(string[] args) {
            var serializerService = new ProductSerializerService();
            var jsonFilename = "products.json";
            var productDb = new ProductDatabase();
            productDb.ProductsAdded += HandleProductsAdded;
            try {
                if (File.Exists(jsonFilename)) {
                    var productList = serializerService.Deserialize(jsonFilename);
                    productDb.AddProducts(productList.ToList());
                }

            } catch (ProductSerializerServiceException ex) {
                Console.WriteLine($"Exception in file {ex.Filename}: {ex.Message}");
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
