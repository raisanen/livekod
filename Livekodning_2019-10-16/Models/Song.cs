﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Livekodning_2019_10_16.Models {
    public class Song : Product {
        public Song(string name, decimal price) : base(name, price, ProductType.Download) { }

        public override string GetPrintableString() {
            return $"A song called {Name} ({Price})";
        }
    }
}
