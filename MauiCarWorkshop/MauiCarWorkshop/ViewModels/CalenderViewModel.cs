using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using MauiCarWorkshop.Models;
using MauiCarWorkshop.Services;

namespace MauiCarWorkshop.ViewModels;

public partial class CalenderViewModel : ObservableObject
{
    private readonly DatabaseService _dataBaseService;

    public CalenderViewModel(DatabaseService databaseService)
    {
        _dataBaseService = databaseService;
        Orders = new ObservableCollection<Order>();
        SelectedDate = DateTime.Today;
        
        _ = LoadOrdersAsync();
        
    }

    [ObservableProperty] private DateTime selectedDate;
    public ObservableCollection<Order> Orders { get; }

    partial void OnSelectedDateChanged(DateTime value)
    {
        _ = LoadOrdersAsync();
    }

    [RelayCommand]
    private async Task LoadOrdersAsync()
    {
        if (_dataBaseService == null) return;
        
        var orders = await _dataBaseService.GetOrdersByDateAsync(SelectedDate.Date);
        
        Orders.Clear();

        foreach (var order in orders)
        { 
            Orders.Add(order);
        }
    }

}