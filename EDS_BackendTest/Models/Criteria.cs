using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace EDS_BackendTest.Model
{
    public class Criteria
    {
        [Key]
        [Required]
        public int CriteriaID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [MaxLength(255)]
        public string FilterColumnValue { get; set; }

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

        [Required]
        [Range(1, int.MaxValue)]
        public int LookupId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int TemplateColumnID { get; set; }

        // Navigation property for the associated TemplateColumn
        public TemplateColumns TemplateColumn { get; set; }

        // Navigation property for the associated Lookup
        public Lookups Lookup { get; set; }

        public ICollection<Job> Jobs { get; set; }


    }
}
