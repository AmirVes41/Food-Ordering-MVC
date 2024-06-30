using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstProj.Models
{
    public class Company
    {
        [Required] 
        public int Id { get; set; }

        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name = "واحد")]
        public string Unit { get; set; }

        [Display(Name = "کد واحد")] 
        public string Code { get; set; }
        [Display(Name = "شماره داخلی")] 
        public string? PhoneNumber { get; set; }

    }
}
