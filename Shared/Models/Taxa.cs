using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Entities;

namespace Shared.Models
{
    [Table("taxa")]
    public class Taxa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("taxon_no")]
        public int TaxonNo { get; set; }

        [Column("record_type")]
        public string? RecordType { get; set; }

        [Column("taxon_rank")]
        public string? TaxonRank { get; set; }

        [Column("taxon_name")]
        public string? TaxonName { get; set; }

        [Column("taxon_attr")]
        public string? TaxonAttr { get; set; }

        [ForeignKey("accepted_no")]
        public int? AcceptedNo { get; set; }
        //public Occurrence? Occurrence { get; set; }
        public Species? Species { get; set; }

        [Column("accepted_rank")]
        public string? AcceptedRank { get; set; }

        [Column("accepted_name")]
        public string? AcceptedName { get; set; }

        [Column("parent_no")]
        public int? ParentNo { get; set; }

        [Column("reference_no")]
        public int? ReferenceNo { get; set; }

        [Column("is_extant")]
        public string? IsExtant { get; set; }

        [Column("n_occs")]
        public int? NumOccurances { get; set; }
    }
}