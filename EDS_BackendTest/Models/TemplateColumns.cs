using System.ComponentModel.DataAnnotations;

namespace EDS_BackendTest.Model
{
    public class TemplateColumns
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int TemplateID { get; set; }
        public Template Template { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ColumnId { get; set; }
        public Columns Column { get; set; }

        public ICollection<Criteria> Criterias { get; set; }
    }

}
