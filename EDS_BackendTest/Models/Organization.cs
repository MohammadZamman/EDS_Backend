using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDS_BackendTest.Model
{
    public class Organization
    {
        [Key]
        public int OrgID { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        [MaxLength(255)]
        public string OrgName { get; set; }

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

        // Navigation property
        public List<Client> Clients { get; set; }

        // Add a property to represent levels and sublevels
        public List<OrganizationLevel> Levels { get; set; }
    }

    public class OrganizationLevel
    {
        [Key]
        public int LevelID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        // Relationship with Organization
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        // Navigation property for sublevels
        public List<Sublevel> Sublevels { get; set; }
    }

    public class Sublevel
    {
        [Key]
        public int SublevelID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        // Relationship with OrganizationLevel
        public int OrganizationLevelId { get; set; }
        public OrganizationLevel OrganizationLevel { get; set; }
    }
}
