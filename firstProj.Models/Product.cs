using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace firstProj.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="پر کردن این فیلد اجباری میباشد")]
        [Display(Name = "نام غذا")] 
        public string Name { get; set; }
        
        [Display(Name = "توضیحات")] 
        public string? Description { get; set; }
       
        [Required(ErrorMessage = "پر کردن این فیلد اجباری میباشد")]
        [Display(Name = "قیمت")][Range(1, 1000000)] 
        
        public double Price { get; set; }
     
        [Required(ErrorMessage = "پر کردن این فیلد اجباری میباشد")]
        [Display(Name = "موجودی")][Range(0, 1000)] 
        public int Count { get; set; }

        [Display(Name = "دسته بندی")] public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
    }
}
