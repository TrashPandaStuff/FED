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

    [ObservableProperty] private string errorMessage = string.Empty;

    [RelayCommand]
    private async Task SaveOrderAsync()
    {
        ErrorMessage = string.Empty;
        
        if (string.IsNullOrWhiteSpace(CustomerName) ||
            string.IsNullOrWhiteSpace(Address) ||
            string.IsNullOrWhiteSpace(CarBrand) ||
            string.IsNullOrWhiteSpace(CarModel) ||
            string.IsNullOrWhiteSpace(LicensePlateNumber) ||
            string.IsNullOrWhiteSpace(TaskDescription))
        {
            ErrorMessage = "All fields must be filled in.";
            return;
        }
     
        var deliveryDateTime = DeliveryDate.Add(DeliveryTime);

        if (deliveryDateTime < DateTime.Now)
        {
            ErrorMessage = "Delivery date and time cannot be in the past.";
            return;
        }

        var order = new Order
        {
            CustomerName = CustomerName,
            Address = Address,
            CarBrand = CarBrand,
            CarModel = CarModel,
            LicensePlateNumber = LicensePlateNumber,
            DeliveryDateTime = deliveryDateTime,
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
        ErrorMessage = string.Empty;
    }
}