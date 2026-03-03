using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCarWorkshop.Models;
using MauiCarWorkshop.Services;

namespace MauiCarWorkshop.ViewModels;

public partial class CreateOrderViewModel : ObservableObject
{
    private readonly DatabaseService database;

    public CreateOrderViewModel(DatabaseService databaseService)
    {
        database = databaseService;
    }
    
    [ObservableProperty] private string customerName = string.Empty;
    [ObservableProperty] private string address = string.Empty;
    [ObservableProperty] private string carBrand = string.Empty;
    [ObservableProperty] private string carModel = string.Empty;
    [ObservableProperty] private string licensePlateNumber = string.Empty;
    [ObservableProperty] private DateTime deliveryDate = DateTime.Today;
    [ObservableProperty] private TimeSpan deliveryTime = TimeSpan.Zero;
    [ObservableProperty] private string taskDescription = string.Empty;
    [RelayCommand]
    
    private async Task SaveOrderAsync()
    {
        var order = new Order
        {
            CustomerName = CustomerName,
            Address = Address,
            CarBrand = CarBrand,
            CarModel = CarModel,
            LicensePlateNumber = LicensePlateNumber,
            DeliveryDateTime = DeliveryDate.Add(DeliveryTime),
            TaskDescription = TaskDescription
        };

        await database.AddOrderAsync(order);
        
        ClearForm();
    }

    private void ClearForm()
    {
        CustomerName = string.Empty;
        Address = string.Empty;
        CarBrand = string.Empty;
        CarModel = string.Empty;
        LicensePlateNumber = string.Empty;
        TaskDescription = string.Empty;
        DeliveryDate = DateTime.Today;
        DeliveryTime = TimeSpan.Zero;
    }
}