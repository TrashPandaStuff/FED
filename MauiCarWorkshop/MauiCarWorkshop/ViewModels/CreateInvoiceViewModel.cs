using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCarWorkshop.Models;
using MauiCarWorkshop.Services;

namespace MauiCarWorkshop.ViewModels;

public partial class CreateInvoiceViewModel : ObservableObject
{
    private readonly DatabaseService database;

    public CreateInvoiceViewModel(DatabaseService databaseService)
    {
        database = databaseService;
    }

    [ObservableProperty] private string mechanicName = string.Empty;
    [ObservableProperty] private string orderId = string.Empty;
    [ObservableProperty] private string materialsUsed = string.Empty;
    [ObservableProperty] private string materialCost = string.Empty;
    [ObservableProperty] private string hoursWorked = string.Empty;
    [ObservableProperty] private string hourlyRate = string.Empty;
    [ObservableProperty] private string errorMessage = string.Empty;

    [RelayCommand]
    private async Task SaveInvoiceAsync()
    {
        ErrorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(MechanicName))
        {
            ErrorMessage = "Mechanic name is required.";
            return;
        }

        if (!decimal.TryParse(MaterialCost, out var materialCost) ||
            !decimal.TryParse(HoursWorked, out var hoursWorked) ||
            !decimal.TryParse(HourlyRate, out var hourlyRate) ||
            !int.TryParse(OrderId, out var orderId))
        {
            ErrorMessage = "Please enter valid numeric values.";
            return;
        }

        if (materialCost < 0 || hoursWorked < 0 || hourlyRate < 0 || orderId < 0)
        {
            ErrorMessage = "Values cannot be negative.";
            return;
        }

        var invoice = new Invoice
        {
            MechanicName = mechanicName,
            OrderId = orderId,
            MaterialsUsed = materialsUsed,
            MaterialCost = materialCost,
            HoursWorked = hoursWorked,
            HourlyRate = hourlyRate
        };

        await database.AddInvoiceAsync(invoice);

        ClearForm();
    }

    private void ClearForm()
    {
        MechanicName = string.Empty;
        OrderId = string.Empty;
        MaterialsUsed = string.Empty;
        MaterialCost = string.Empty;
        HoursWorked = string.Empty;
        HourlyRate = string.Empty;
    }
}