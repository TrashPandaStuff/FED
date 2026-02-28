using SQLite;

namespace MauiCarWorkshop.Models;

public class Invoice
{
    [PrimaryKey, AutoIncrement] public int InvoiceId { get; set; }

    public required int OrderId { get; set; }

    public required string MechanicName { get; set; }

    public required string MaterialsUsed { get; set; }

    public required decimal MaterialCost { get; set; }

    public required decimal HoursWorked { get; set; }

    public required decimal HourlyRate { get; set; }

    public required decimal TotalPrice { get; set; }
}