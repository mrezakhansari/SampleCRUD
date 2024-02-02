namespace SampleCRUD.Domain;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime ProduceDate { get; set; }
    public string ManufacturePhone { get; set; }
    public string ManufactureEmail { get; set; }
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; }
}
