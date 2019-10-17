using Livekodning.Exceptions;
using Livekodning.Interfaces;
using Livekodning.Models;
using Livekodning.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace Livekodning {
    class Program {
        static void Main(string[] args) {
            var serializerService = new ProductSerializerService();
            var jsonFilename = "products.json";
            try {
                if (File.Exists(jsonFilename)) {
                    var productList = serializerService.Deserialize(jsonFilename);
                    foreach (var product in productList) {
                        Console.WriteLine(product.GetPrintableString());
                    }
                } else {
                    var productList = new List<Product> {
                    new Song("Time and Season", 10),
                    new Phone("Pixel", 1500)
                };
                    serializerService.Serialize(jsonFilename, productList);
                    Console.WriteLine("Wrote products to " + jsonFilename);
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
