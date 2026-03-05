using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
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
        
        WeakReferenceMessenger.Default.Register<InvoiceCreatedMessage>(this, (r, m) =>
        {
            if (!Invoices.Any(i => i.InvoiceId == m.Value.InvoiceId))
            {
                Invoices.Add(m.Value);
            }
        });
        
        Task.Run(async () => await LoadInvoicesAsync());
    }

    [RelayCommand]
    private async Task LoadInvoicesAsync()
    {
        var invoicesFromDb = await database.GetInvoicesAsync();
        
        foreach (var invoice in invoicesFromDb)
        {
            if (!Invoices.Any(i => i.InvoiceId == invoice.InvoiceId))
                Invoices.Add(invoice);
        }
    }

    [RelayCommand]
    private async Task DeleteInvoiceAsync(Invoice invoice)
    {
        if (invoice == null) return;

        await database.DeleteInvoiceAsync(invoice);
        Invoices.Remove(invoice);
    }
}

public class InvoiceCreatedMessage : ValueChangedMessage<Invoice>
{
    public InvoiceCreatedMessage(Invoice value) : base(value) { }
}