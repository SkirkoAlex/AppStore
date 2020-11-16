using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppStore.Models
{
    public class Employee
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Имя сотрудника")]
        [Required]
        [StringLength(256, MinimumLength = 2, ErrorMessage = "Допустимая длина строки от 2 до 256 символов")]
        public string Name { get; set; }

        [Display(Name = "Фамилия сотрудника")]
        [StringLength(256, ErrorMessage = "Допустимая длина строки: до 256 символов")]
        public string Surname { get; set; }

        [Display(Name = "Телефон сотрудника")]
        [RegularExpression(@"[0-9]", ErrorMessage = "Введены неверные данные!")]
        [StringLength(16, ErrorMessage = "Допустимая длина строки: до 16 символов")]
        public string Phone { get; set; }

        public ICollection<Product> Products { get; set; }

        public Employee()
        {
            Products = new List<Product>();
        }
    }
}