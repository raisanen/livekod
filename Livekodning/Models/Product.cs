﻿using Livekodning.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livekodning.Models {
    public abstract class Product : IPrintable {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductType Type { get; set; }

        protected Product(string name, decimal price, ProductType type) {
            Name = name;
            Price = price;
            Type = type;
        }

        public abstract string GetPrintableString();
    }
}
