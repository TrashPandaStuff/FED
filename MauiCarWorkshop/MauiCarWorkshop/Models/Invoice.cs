using SQLite;

namespace MauiCarWorkshop.Models;

public class Invoice
{
    [PrimaryKey, AutoIncrement] public int InvoiceId { get; set; }

    public int OrderId { get; set; }

    public string MechanicName { get; set; }

    public string MaterialsUsed { get; set; }

    public decimal MaterialCost { get; set; }

    public decimal HoursWorked { get; set; }

    public decimal HourlyRate { get; set; }

    public decimal Total => (HoursWorked * HourlyRate) + MaterialCost;
}