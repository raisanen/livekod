using Livekodning_2019_10_16.Interfaces;
using Livekodning_2019_10_16.Models;
using System;
using System.Collections.Generic;

namespace Livekodning_2019_10_16 {
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
