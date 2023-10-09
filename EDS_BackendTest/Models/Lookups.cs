using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace EDS_BackendTest.Model
{
    public class Lookups
    {
        [Key]
        public int LookUpID { get; set; }

        [Required]
        [MaxLength(255)]

        public string Type { get; set; }

        [MaxLength(255)]

        public string lookup_visible_value { get; set; }

        [MaxLength(255)]
        public string lookup_hidden_value { get; set; }

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

        // Navigation property for one-to-many relationship with DataRecepient
        public List<DataRecepient> DataRecipients { get; set; }

        // Navigation property for one-to-many relationship with NotificationRecepient
        public List<NotificationRecepient> NotificationRecipients { get; set; }
        public ICollection<Criteria> Criterias { get; set; }
        public ICollection<Job> Jobs { get; set; }


    }
}
