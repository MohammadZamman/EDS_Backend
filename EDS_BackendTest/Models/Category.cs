using System.ComponentModel.DataAnnotations;

namespace EDS_BackendTest.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        [MaxLength(255)]
        public string CategoryName { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [MaxLength(255)]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [MaxLength(255)]
        public string? UpdatedBy { get; set; }

        [Required]
        public bool Active { get; set; }

        public ICollection<Template>? Templates { get; set; }

    }
}
