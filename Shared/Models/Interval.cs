using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("intervals")]
public class Interval
{
    [Key]
    [Column(name:"interval_no")]
    public int id { get; set; }
    
    [Column(name:"record_type")]
    public String? recordType { get; set; }

    [Column(name:"interval_name")]
    public String? intervalName { get; set; }
    
    public String? abbrev { get; set; }
    public String? type { get; set; }
    
    [Column(name:"parent_no")]
    public int? parentNo { get; set; }
    
    [Column(name:"color")]
    public String? color { get; set; }
    
    [Column(name:"t_age")]
    public Decimal? tAge { get; set; }

    [Column(name:"b_age")]
    public Decimal? bAge { get; set; }

    [Column(name:"reference_no")]
    public int? referenceNo { get; set; }
}