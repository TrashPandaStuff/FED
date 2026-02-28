using SQLite;

namespace MauiCarWorkshop.Models;

public class Order
{
    [PrimaryKey, AutoIncrement] public int OrderId { get; set; }
    public required string CustomerName { get; set; }
    public required string Address { get; set; }
    public required string CarBrand { get; set; }
    public required string CarModel { get; set; }
    public required string LicensePlateNumber { get; set; }
    public required DateTime DeliveryDate { get; set; }
    public required string TaskDescription { get; set; }
}