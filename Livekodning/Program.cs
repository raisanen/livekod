using Livekodning.Interfaces;
using Livekodning.Models;
using System;
using System.Collections.Generic;

namespace Livekodning {
    class Program {
        static void Main(string[] args) {
            var productList = new List<IPrintable> {
                new Song("Time and Season", 10),
                new Phone("Pixel", 1500)
            };
            foreach (var p in productList) {
                Console.WriteLine(p.GetPrintableString());
            }
            Console.ReadKey();
        }
    }
}
