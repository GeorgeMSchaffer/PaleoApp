using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace Shared.Models
{
    [Table("occurrences", Schema = "paleo")]
    public class Occurrence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("occurrence_no")]
        [JsonProperty("occurrence_no")]
        //[ForeignKey("occurrence_no")]
        public int OccurrenceNo { get; set; }


        //[Column("accepted_no")]
        
 //       [ForeignKey("accepted_no")]
        [Column("accepted_no")]
        [JsonProperty("accepted_no")]
        public int? AcceptedNo { get; set; }
        

        
        public List<Species>? Species { get; set; }
        //public List<Taxa>? Taxa { get; set; }

        [JsonProperty("collection_no")]
        [Column("collection_no")] public int? CollectionNo { get; set; }

        [Column("record_type")]
        [StringLength(255)]
        public string? RecordType { get; set; }

        [Column("identified_name")]
        [StringLength(1024)]
        [JsonProperty("identified_name")]
        public string? IdentifiedName { get; set; }

        [JsonProperty("identified_rank")]
        [Column("identified_rank")]
        [StringLength(1024)]
        public string? IdentifiedRank { get; set; }

        [JsonProperty("identified_no")]
        [Column("identified_no")] public int? IdentifiedNo { get; set; }

        [JsonProperty("accepted_name")]
        [Column("accepted_name")]
        [StringLength(512)]

        public string? AcceptedName { get; set; }

        [Column("accepted_rank")]
        [JsonProperty("accepted_rank")]
        [StringLength(512)]
        public string? AcceptedRank { get; set; }

      

        [Column("early_interval")]
        [JsonProperty("early_interval")]
        [StringLength(512)]
        public string? EarlyIntervalName { get; set; }

        [JsonProperty("late_interval")]
        [Column("late_interval")]
        [StringLength(512)]
        public string? LateIntervalName { get; set; }
        
        
        [JsonProperty("early_interval_no")]
        [Column("early_interval_no")]
        [ForeignKey("Interval")]
        public int? EarlyIntervalNo { get; set; }
        public Interval? Interval { get; set; }
        //public Interval? EarlyInterval { get; set;    }
        
        [JsonProperty("late_interval_no")]
        [Column("late_interval_no")]
        //[ForeignKey("Interval")]
        public int? LateIntervalNo { get; set; }
        
        //[ForeignKey("EarlyIntervalNo")]
       //public Interval? interval { get; set; }
        
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

        [Column("max_ma")] public double? MaxMya { get; set; }

        [Column("min_ma")] public double? MinMya { get; set; }
    }
}