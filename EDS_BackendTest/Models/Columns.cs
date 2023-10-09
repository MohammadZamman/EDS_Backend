using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace EDS_BackendTest.Model
{
    public class Columns
    {
        [Key]

        public int ColumnId { get; set; }

        [Required]
        [MaxLength(255)] 
        public string ColName { get; set; }

        [MaxLength(255)]
        public string ColNameExternalDB { get; set; }

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

        public ICollection<TemplateColumns> TemplateColumns { get; set; }

    }
}
