using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCarWorkshop.Services;
using MauiCarWorkshop.Models;

namespace MauiCarWorkshop.ViewModels;

public partial class CreateInvoiceViewModel : ObservableObject
{
    private readonly DatabaseService database;

    public CreateInvoiceViewModel(DatabaseService dataBaseService)
    {
        database = dataBaseService;
    }

    [ObservableProperty] private string mechanicName = string.Empty;
    [ObservableProperty] private string materialsUsed = string.Empty;
    [ObservableProperty] private decimal materialCost = 0;
    [ObservableProperty] private decimal hoursWorked = 0;
    [ObservableProperty] private decimal hourlyRate = 0;
    [RelayCommand]

    private async Task SaveInvoiceAsync()
    {
        var invoice = new Invoice
        {
           MechanicName = string.Empty,
           MaterialsUsed = string.Empty,
           MaterialCost = 0,
           HoursWorked = 0,
           HourlyRate = 0
        };
        await database.AddInvoiceAsync(invoice);

        ClearForm();
    }

    private void ClearForm()
    {
        MechanicName = string.Empty;
        MaterialsUsed = string.Empty;
        MaterialCost = 0;
        HoursWorked = 0;
        HourlyRate = 0;
    }
}