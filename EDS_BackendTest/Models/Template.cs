using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace EDS_BackendTest.Model
{
    public class Template
    {
        [Key]
        public int TemplateID { get; set; }

        [Required]
        [MaxLength(255)]
        public string TemplateName { get; set; }

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
         
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        // Navigation property for the associated Category
        public Category Category { get; set; }
        public ICollection<TemplateColumns> TemplateColumns { get; set; }

        public ICollection<Job> Jobs { get; set; }


    }
}
