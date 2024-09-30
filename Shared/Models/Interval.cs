﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Shared.Models
{
    [Table("intervals", Schema = "paleo")]
    public class Interval
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("interval_no")]
        [JsonPropertyName("interval_no")]
        [JsonProperty("interval_no")]
        public int IntervalNo { get; set; }

        // [ForeignKey("ParentNo")]
        // public virtual Interval Parent { get; set; }
        //
        // [InverseProperty("Parent")]
        // public virtual ICollection<Interval> Children { get; set; } = new HashSet<Interval>();

        [Column("interval_name"), StringLength(512)]
        [JsonPropertyName("interval_name")]
        [JsonProperty("interval_name")]
        public string? IntervalName { get; set; }
        // [ForeignKey("interval_name")]
        public List<Occurrence> Occurrences { get; set; }
        [Column("b_age")]
        [JsonPropertyName("b_age")]
        [JsonProperty("b_age")]
        public double? StartMYA { get; set; }

        [Column("t_age")]
        [JsonPropertyName("t_age")]
        [JsonProperty("t_age")]
        public double? EndMYA { get; set; }

        [Column("color"), StringLength(255)]
        [JsonPropertyName("color")]
        [JsonProperty("color")]
        public string? Color { get; set; }

        // [Column("parent_no")]
        // public int? ParentNo { get; set; }

        [Column("record_type"), StringLength(255)]
        [JsonPropertyName("record_type")]
        [JsonProperty("record_type")]
        public string? RecordType { get; set; }

        [JsonPropertyName("reference_no")]
        [JsonProperty("reference_no")]
        [Column("reference_no")]
        public int? ReferenceNo { get; set; }

        [Column("scale_no")]
        [JsonPropertyName("scale_no")]
        [JsonProperty("scale_no")]
        public int? ScaleNo { get; set; }

        // public IEnumerator GetEnumerator()
        // {
        //     throw new NotImplementedException();
        // }
    }
}