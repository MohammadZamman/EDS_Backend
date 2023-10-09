using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace EDS_BackendTest.Model
{
    public class NotificationRecepient
    {
        [Key]
        public int NotificationRecipientID { get; set; }

        [Required]
        [MaxLength(255)]
        public string NotificationRecipientInfo { get; set; }

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

        // Foreign Key
        [Required]
        [Range(1, int.MaxValue)]
        public int ClientID { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int LookUpID { get; set; }

        // Navigation property for the associated Lookup
        public Lookups Lookup { get; set; }

        // Navigation property for the associated client
        public Client Client { get; set; }

    }
}
