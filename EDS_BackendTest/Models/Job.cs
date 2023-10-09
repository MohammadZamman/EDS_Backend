using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EDS_BackendTest.Model
{
    public class Job
    {
        [Key]
        public int JobID { get; set; }

        [Required]
        public bool SendNotification { get; set; }

        [Range(0, int.MaxValue)]
        public int? MinRecordCountAlarm { get; set; }

        [Range(0, int.MaxValue)]
        public int? MaxRecordCountAlarm { get; set; }

        [Range(0, int.MaxValue)]
        public int? MinRunDurationAlarm { get; set; }

        [Range(0, int.MaxValue)]
        public int? MaxRunDurationAlarm { get; set; }

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
        public int ClientID { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CriteriaID { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int TemplateID { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int FrequencyID { get; set; }

        public int LookupID { get; set; }

        // Navigation properties for related entities
        public Client Client { get; set; }
        public Criteria Criteria { get; set; }
        public Template Template { get; set; }
        public Frequency Frequency { get; set; }

        [ForeignKey("LookupID")]
        public Lookups Lookup { get; set; }

        public ICollection<JobLog> JobLogs { get; set; }

}
}
