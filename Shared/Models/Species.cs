using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Entities;
using Shared.Models;

namespace Shared.Entities
{
    [Table("species")]
    public class Species
    {
        [Key]
        [Column("specimen_no")]
        public int SpecimenNo { get; set; }

        [Column("record_type", TypeName = "text")]
        public string RecordType { get; set; }

        [Column("flags", TypeName = "text")]
        public string Flags { get; set; }

        // [ForeignKey("occurrence_no")]
        // [Column("occurrence_no", TypeName = "text")]
        // public string OccurrenceNo { get; set; }
        // public Occurrence Occurrence { get; set; }
        
        [Column("reid_no")]
        public int? ReidNo { get; set; }


        [Column("collection_no", TypeName = "text")]
        public string CollectionNo { get; set; }

        [Column("specimen_id", TypeName = "text")]
        public string SpecimenId { get; set; }

        [Column("is_type", TypeName = "text")]
        public string IsType { get; set; }

        [Column("specelt_no", TypeName = "text")]
        public string SpeceltNo { get; set; }

        [Column("specimen_side", TypeName = "text")]
        public string SpecimenSide { get; set; }

        [Column("specimen_part", TypeName = "text")]
        public string SpecimenPart { get; set; }

        [Column("specimen_sex", TypeName = "text")]
        public string SpecimenSex { get; set; }

        [Column("n_measured")]
        public int? NMeasured { get; set; }

        [Column("measurement_source", TypeName = "text")]
        public string MeasurementSource { get; set; }

        [Column("magnification", TypeName = "text")]
        public string Magnification { get; set; }

        [Column("comments", TypeName = "text")]
        public string Comments { get; set; }

        [Column("identified_name", TypeName = "text")]
        public string IdentifiedName { get; set; }

        [Column("identified_rank", TypeName = "text")]
        public string IdentifiedRank { get; set; }

        [Column("identified_no")]
        public int? IdentifiedNo { get; set; }

        [Column("difference", TypeName = "text")]
        public string Difference { get; set; }

        [Column("accepted_name", TypeName = "text")]
        public string AcceptedName { get; set; }

        [Column("accepted_rank", TypeName = "text")]
        public string AcceptedRank { get; set; }

        [Column("accepted_no")]
        public int? AcceptedNo { get; set; }

        [Column("max_ma", TypeName = "text")]
        public string MaxMa { get; set; }

        [Column("min_ma", TypeName = "text")]
        public string MinMa { get; set; }

        [Column("reference_no")]
        public int? ReferenceNo { get; set; }
    }
}