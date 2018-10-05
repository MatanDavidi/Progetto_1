using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progetto_1.Helper
{
    public static class CollectionHelper
    {
        public object GetValue(object key, IFormCollection collection)
        {
            foreach (var item in collection)
            {
                if (item.Value == key)
                {

                }
            }
        }
    }
}
