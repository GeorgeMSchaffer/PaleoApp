using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Shared.Models
{
    [Table("occurrences", Schema = "paleo")]
    public class Occurrence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("occurrence_no")]
        public int OccurrenceNo { get; set; }


        public IEnumerable<Species>? Species { get; set; }

        [Column("collection_no")] public int? CollectionNo { get; set; }

        [Column("record_type")]
        [StringLength(255)]
        public string? RecordType { get; set; }

        [Column("identified_name")]
        [StringLength(1024)]
        public string? IdentifiedName { get; set; }

        [Column("identified_rank")]
        [StringLength(1024)]
        public string? IdentifiedRank { get; set; }

        [Column("identified_no")] public int? IdentifiedNo { get; set; }

        [Column("accepted_name")]
        [StringLength(512)]

        public string? AcceptedName { get; set; }

        [Column("accepted_rank")]
        [StringLength(512)]
        public string? AcceptedRank { get; set; }


        public int? AcceptedNo { get; set; }

        [Column("early_interval")]
        [StringLength(512)]
        public string EarlyInterval { get; set; }

        [Column("late_interval")]
        [StringLength(512)]
        public string? LateInterval { get; set; }
        
        public Interval Interval { get; set; }
        // public Interval? Interval
        // {
        //     get
        //     {
        //         return LateInterval ?? EarlyInterval;
        //     }
        // }

        [Column("max_ma")] public double? MaxMya { get; set; }

        [Column("min_ma")] public double? MinMya { get; set; }

        [Column("reference_no")] public int? ReferenceNo { get; set; }

        [Column("cc")] [StringLength(1024)] public string? Cc { get; set; }

        [Column("latlng_basis")]
        [StringLength(512)]
        public string? LatlngBasis { get; set; }

        [Column("latlng_precision")]
        [StringLength(512)]
        public string? LatlngPrecision { get; set; }

        [Column("geogscale")]
        [StringLength(512)]
        public string? Geogscale { get; set; }

        [Column("phylum")] [StringLength(512)] public string? Phylum { get; set; }

        [Column("class")] [StringLength(512)] public string? Class { get; set; }

        [Column("order")] [StringLength(512)] public string? Order { get; set; }

        [Column("family")] [StringLength(512)] public string? Family { get; set; }

        [Column("genus")] [StringLength(512)] public string? Genus { get; set; }

    }
}