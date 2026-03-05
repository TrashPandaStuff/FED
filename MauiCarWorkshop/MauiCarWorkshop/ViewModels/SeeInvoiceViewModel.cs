using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiCarWorkshop.Models;
using MauiCarWorkshop.Services;

namespace MauiCarWorkshop.ViewModels;

public partial class SeeInvoiceViewModel : ObservableObject
{
    private readonly DatabaseService database;

    public ObservableCollection<Invoice> Invoices { get; } = new();

    public SeeInvoiceViewModel(DatabaseService databaseService)
    {
        database = databaseService;
        
        Task.Run(async () => await LoadInvoicesAsync());
    }

    [RelayCommand]
    private async Task LoadInvoicesAsync()
    {
        Invoices.Clear();

        var invoicesFromDb = await database.GetInvoicesAsync();

        foreach (var invoice in invoicesFromDb)
            Invoices.Add(invoice);
    }

    [RelayCommand]
    private async Task DeleteInvoiceAsync(Invoice invoice)
    {
        if (invoice == null) return;

        await database.DeleteInvoiceAsync(invoice);
        Invoices.Remove(invoice);
    }
}