using System;
using System.Collections.Generic;
using System.Text;

namespace Livekodning_2019_10_16.Models {
    public class Phone : Product {
        public Phone(string name, decimal price) : base(name, price, ProductType.Physical) {

        }
        public override string GetPrintableString() {
            return $"{Name} - {Price} [Phone]";
        }
    }
}
