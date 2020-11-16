using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppStore.Models
{
    public class ViewProducts
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingModel PagingModel { get; set; }
    }
}