using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace firstProj.Models
{
    public class OrderHeader
    {


        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        [Display(Name = "قیمت نهایی")]
        public double OrderTotal { get; set; }


        [Display(Name = "وضعیت سفارش")] public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public string? TrackingNumber { get; set; }
        public string? Carrier { get; set; }

        public DateTime PaymentDate { get; set; }
        public DateOnly PaymentDueDate { get; set; }
        [DefaultValue("fake session ID")]
        public string SessionId { get; set; }
        public string? PaymentIntentId { get; set; }

        [Required]
        [Display(Name = "نام")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "کد ملی")]
        public string? Code { get; set; }
        [Required]
        [Display(Name = "شماره تماس")]
        public string? PhoneNumber { get; set; }

    }
}

