using System;
using System.Collections.Generic;
using System.Text;

namespace Livekodning.Exceptions {
    public class ProductSerializerServiceException : Exception {
        private readonly string _filename;

        public string Filename {
            get {
                return _filename;
            }
        }

        public ProductSerializerServiceException(string filename, string message) : base(message) {
            _filename = filename;
        }
    }
}
