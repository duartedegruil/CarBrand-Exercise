using System.ComponentModel.DataAnnotations;

namespace CarBrandAPI.DTO
{
    public class CarBrandDTO
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} long."), MinLength(2)]
        [DataType(DataType.Text)]
        [Display(Name = "Car Brand Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Car Brand Image")]
        public string Image { get; set; }
    }
}
