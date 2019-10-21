using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Newtonsoft.Json;

using Livekodning.Exceptions;
using Livekodning.Models;
using System.Threading.Tasks;

namespace Livekodning.Services {
    public class ProductSerializerService {
        public async Task<IEnumerable<Product>> Deserialize(string filename) {
            try {
                return await Task.Run<IEnumerable<Product>>(() => {
                    var serializer = CreateSerializer();
                    using (var sr = new StreamReader(filename)) {
                        using (var jr = new JsonTextReader(sr)) {
                            var list = serializer.Deserialize<IEnumerable<Product>>(jr);
                            return list;
                        }
                    }
                });
            } catch (Exception) {
                throw new ProductSerializerServiceException(filename, "Couldn't deserialize file!");
            }
        }
        public void Serialize(string filename, IEnumerable<Product> products) {
            try {
                var serializer = CreateSerializer();
                using (var sw = new StreamWriter(filename)) {
                    using (var jw = new JsonTextWriter(sw)) {
                        serializer.Serialize(jw, products);
                    }
                }
            } catch (Exception) {
                throw new ProductSerializerServiceException(filename, "Couldn't serialize to file!");
            }
        }

        #region Private methods
        private JsonSerializer CreateSerializer() {
            return new JsonSerializer {
                TypeNameHandling = TypeNameHandling.All
            };
        }
        #endregion
    }
}
