using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System;
using System.ComponentModel.DataAnnotations;

namespace EDS_BackendTest.Model
{
    public class Frequency
    {
        [Key]
        public int FrequencyID { get; set; }

        [Required]
        [MaxLength(255)]
        public string FrequencyType { get; set; }

        [MaxLength(255)]
        public string DayOfWeek { get; set; }

        [Range(1, 31)]
        public int DateOfMonth { get; set; }

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

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

        public ICollection<Job> Jobs { get; set; }



    }
}
