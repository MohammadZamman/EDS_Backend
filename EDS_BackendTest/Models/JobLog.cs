using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace EDS_BackendTest.Model
{
    public class JobLog
    {
        [Key]
        public int JobLogID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime JobRunDateTime { get; set; }

        [Range(1, int.MaxValue)]
        public int JobRunDuration { get; set; }

        [Required]
        public bool ExtractSuccess { get; set; }

        [Required]
        public bool NotificationRecipientSuccess { get; set; }

        [Range(0, int.MaxValue)]
        public int ExtractedRecordCount { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        // Foreign Key
        public int JobID { get; set; }

        // Navigation property for the associated Job
        public Job Job { get; set; }



    }
}
