using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace firstProj.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "پر کردن این فیلد اجباری میباشد")]
        [MaxLength(50)]
        [DisplayName("نام دسته بندی")]
        public string Name { get; set; }
        [DisplayName("کد")]
        [Range(1, 1000, ErrorMessage = "عدد وارد شده باید بین 1 تا 1000 باشد")]
        public int DisplayOrder { get; set; }


    }
}
