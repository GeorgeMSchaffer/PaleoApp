namespace Shared.Models;

public class TaxaDTO
{
    public int TaxonNo { get; set; }
    
    public string RecordType { get; set; }

    public string TaxonRank { get; set; }

    public string TaxonName { get; set; }

    public string TaxonAttr { get; set; }

    public int AcceptedNo { get; set; }

    public string AcceptedRank { get; set; }

    public string AcceptedName { get; set; }

    public int ParentNo { get; set; }

    public int ReferenceNo { get; set; }

    public string IsExtant { get; set; }

    public int NumOccurances { get; set; }
}