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
    }
    
    private async Task LoadInvoicesAsync()
    {
        if (database == null) return;
        
        Invoices.Clear();

        var invoicesFromDb = await database.GetInvoicesAsync();

        foreach (var invoice in invoicesFromDb)
                Invoices.Add(invoice);
    }
}
