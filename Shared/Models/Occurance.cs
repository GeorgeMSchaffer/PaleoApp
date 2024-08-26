namespace Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table("occurances")]
public class Occurance
{
    [Key]
    [Required]
    [Column("occurrence_no")]
    public int id { get; set; }
    [Column("record_type")]
    public String? recordType { get; set; }
    [Column("reid_no")]
    public int? reidNo { get; set; }
    [Column("flags")]
    public String? flags { get; set; }
    [Column("collection_no")]
    public int? collectionNo { get; set; }
    [Column("identified_name")]
    public String? identifiedName { get; set; }
    [Column("identified_rank")]
    public String? identifiedRank { get; set; }
    [Column("identified_no")]
    public int? identifiedNo { get; set; }
    [Column("difference")]
    public String? difference { get; set; }
    [Column("accepted_name")]
    public String? acceptedName { get; set; }
    [Column("accepted_rank")]
    public String? acceptedRank { get; set; }
    [Column(" accepted_no")]
    public int? acceptedNo { get; set; }

    [Column("early_interval")]
    public String? earlyInterval { get; set; }
    [Column("late_interval")]
    public String? lateInterval { get; set; }
    [Column("max_ma")]
    public Decimal? maxMYA { get; set; }
    [Column("min_ma")]
    public Decimal? minMYA { get; set; }
    [Column("reference_no")]
    public int? referenceNo { get; set; }
    [Column("cc")]
    public String? cc { get; set; }
    [Column("state")]
    public String? state { get; set; }
    [Column("county")]
    public String? county { get; set; }
    [Column("latlng_basis")]
    public String? latLngBasis { get; set; }
    [Column("latlng_precision")]
    public String? latlngPrecision { get; set; }
    [Column("geogscale")]
    public String? geoscale { get; set; }
    [Column("geogcomments")]
    public String? geoComments { get; set; }
    [Column("phylum")]
    public String? phylum { get; set; }
    [Column("class")]
    public String? orderClass { get; set; }
    [Column("class_order")]
    public String? classOrder { get; set; }
    [Column("family")]
    public String? family { get; set; }
    [Column("genus")]
    public String? genus { get; set; }
}