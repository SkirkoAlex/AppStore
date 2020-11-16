using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}