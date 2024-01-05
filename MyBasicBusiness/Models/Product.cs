using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBasicBusiness.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="3 to 50 letter name")]
        
        public string Name { get; set; }
        [Required]
        
        public int Price { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
