namespace Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table("occurances")]
public class OccurrenceDTO
{
    public int? OccurrenceNo { get; set; }
    public int intervalNo { get; set; }
    public String? recordType { get; set; }
    public int? reidNo { get; set; }
    public String? flags { get; set; }
    public int? collectionNo { get; set; }
    public String? identifiedName { get; set; }
    public String? identifiedRank { get; set; }
    public int? identifiedNo { get; set; }
    public String? difference { get; set; }
    public String? acceptedName { get; set; }
    public String? acceptedRank { get; set; }
    public int? acceptedNo { get; set; }
    public string? EarlyIntervalName { get; set; }
    public string? LateIntervalName { get; set; }
    public int? EarlyIntervalNo { get; set; }
    public int? LateIntervalNo { get; set; }
    public Double minMya { get; set; }
    public Double maxMYA { get; set; }
    public int? referenceNo { get; set; }
    public String? cc { get; set; }
    public String? state { get; set; }
    public String? county { get; set; }
    public String? latLngBasis { get; set; }
    public String? latlngPrecision { get; set; }
    public String? geoscale { get; set; }
    public String? geoComments { get; set; }
    public String? phylum { get; set; }
    public String? orderClass { get; set; }
    public String? classOrder { get; set; }
    public String? family { get; set; }
    public String? genus { get; set; }
}