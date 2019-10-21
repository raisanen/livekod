using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Livekodning.Exceptions;
using Livekodning.Models;
using Livekodning.Services;

namespace Livekodning {
    class Program {
        static void HandleProductsAdded(List<Product> newProducts) {
            foreach (var product in newProducts) {
                Console.WriteLine("Added new Product: " + product.GetPrintableString());
            }
        }
        static void Main(string[] _) {
            var serializerService = new ProductSerializerService();
            var jsonFilename = "products.json";
            var productDb = new ProductDatabase();
            productDb.ProductsAdded += HandleProductsAdded;
            try {
                if (File.Exists(jsonFilename)) {
                    var productList = serializerService.Deserialize(jsonFilename);
                    // .Result väntar på Deserialize
                    productDb.AddProducts(productList.Result.ToList());
                    // AddProducts är async, nästa rad hinner (oftast) före
                    Console.WriteLine("Efter AddProducts");
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
