using SQLite;

namespace MauiCarWorkshop.Models;

public class Order
{
    [PrimaryKey, AutoIncrement] public int OrderId { get; set; }
    
    public string CustomerName { get; set; }
    
    public string Address { get; set; }
    
    public string CarBrand { get; set; }
    
    public string CarModel { get; set; }
    
    public string LicensePlateNumber { get; set; }
    
    public DateTime DeliveryDateTime { get; set; }
    
    public string TaskDescription { get; set; }
}