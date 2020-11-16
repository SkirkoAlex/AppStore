using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppStore.Models
{
    public class PagingModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalProducts { get; set; }
        public int TotalPages
        {
            get => (int)Math.Ceiling((double)TotalProducts / PageSize);
        }
    }
}