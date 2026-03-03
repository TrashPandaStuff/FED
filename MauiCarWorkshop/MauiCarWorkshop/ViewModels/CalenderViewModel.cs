using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using MauiCarWorkshop.Models;
using MauiCarWorkshop.Services;

namespace MauiCarWorkshop.ViewModels;

public partial class CalenderViewModel : ObservableObject
{
    private readonly DataBaseService _dataBaseService;

    public CalenderViewModel(DataBaseService dataBaseService)
    {
        _dataBaseService = dataBaseService;
        Orders = new ObservableCollection<Order>();
        SelectedDate = DateTime.Today;
        
    }

    [ObservableProperty] private DateTime selectedDate;
    
    public ObservableCollection<Order> Orders { get; }

    partial void OnSelectedDateChanged(DateTime value)
    {
        _ = LoadOrdersAsync();
    }

    [RelayCommand]
    public async Task LoadOrdersAsync()
    {
        var orders = await _dataBaseService.GetOrdersByDateAsync(SelectedDate);
        
        Orders.Clear();

        foreach (var order in orders)
        { 
            Orders.Add(order);
        }
    }

}