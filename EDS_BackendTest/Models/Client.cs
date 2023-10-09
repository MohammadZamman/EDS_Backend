using System.ComponentModel.DataAnnotations;

namespace EDS_BackendTest.Model
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }

        [Required]
        [MaxLength(255)]
        public string ClientName { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [MaxLength(255)]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
         
        public string? UpdatedBy { get; set; }

        [Required]
        public bool Active { get; set; }

        // Foreign Key 
        [Range(1, int.MaxValue)]
        // Navigation property
        public int Organization { get; set; } 
    }
}
