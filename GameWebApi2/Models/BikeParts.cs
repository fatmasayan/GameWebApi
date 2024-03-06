namespace GameWebApi2.Models;

public class BikeParts : BaseEntity
{
    public int id { get; set; }
    public string partType { get; set; }
    public string partName { get; set; }
}
