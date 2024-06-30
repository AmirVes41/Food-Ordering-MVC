using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstProj.Models { 
    public class ApplicationUser:IdentityUser {
        [Required]
        [DisplayName("نام")]
        public string FirstName { get; set; }
        [DisplayName("نام خانوادگی")]
        public string LastName { get; set; }
        [DisplayName("کد ملی")]
        public string? Code { get; set; }

        //[DisplayName("شماره تلفن")]
        //public string? PhoneNumber { get; set; }
        
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        [ValidateNever]
        public Company Company { get; set; }    
    }
}
