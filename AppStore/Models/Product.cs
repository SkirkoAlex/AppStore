using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppStore.Models
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name ="Название товара")]
        [Required(ErrorMessage ="Введите название товара")]
        [StringLength(256, MinimumLength = 2, ErrorMessage = "Допустимая длина строки от 2 до 256 символов")]
        public string ProductName { get; set; }

        [Display(Name = "Категория")]
        [StringLength(256, ErrorMessage = "Допустимая длина строки: до 256 символов")]
        public string Category { get; set; }

        [Display(Name = "Стоимость")]
        [Required(ErrorMessage = "Введите стоимость товара")]
        [Range(1,999_999,ErrorMessage = "Цена не входит в допустимый диапазон!")]
        [RegularExpression(@"[0-9]+",ErrorMessage = "Введены неверные данные!")]
        public int Price { get; set; }

        [Display(Name = "Описание")]
        [StringLength(256, ErrorMessage = "Допустимая длина строки: до 256 символов")]
        public string Description { get; set; }

        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}