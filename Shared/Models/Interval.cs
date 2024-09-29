using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
    [Table("intervals", Schema = "paleo")]
    public class Interval
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("interval_no")]
        public int IntervalNo { get; set; }

        // [ForeignKey("ParentNo")]
        // public virtual Interval Parent { get; set; }
        //
        // [InverseProperty("Parent")]
        // public virtual ICollection<Interval> Children { get; set; } = new HashSet<Interval>();

        [Column("interval_name"), StringLength(512)]
        public string? IntervalName { get; set; }

        public List<Occurrence> Occurrences { get; set; }
        [Column("b_age")]
        public double? StartMYA { get; set; }

        [Column("t_age")]
        public double? EndMYA { get; set; }

        [Column("color"), StringLength(255)]
        public string? Color { get; set; }

        // [Column("parent_no")]
        // public int? ParentNo { get; set; }

        [Column("record_type"), StringLength(255)]
        public string? RecordType { get; set; }

        [Column("reference_no")]
        public int? ReferenceNo { get; set; }

        [Column("scale_no")]
        public int? ScaleNo { get; set; }

        // public IEnumerator GetEnumerator()
        // {
        //     throw new NotImplementedException();
        // }
    }
}