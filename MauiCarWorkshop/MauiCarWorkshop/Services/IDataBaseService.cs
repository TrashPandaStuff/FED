using MauiCarWorkshop.Models;

namespace MauiCarWorkshop.Services;

public interface IDatabaseService
{
    // Orders
    Task<int> AddOrderAsync(Order order);
    Task<List<Order>> GetOrdersAsync();
    Task<Order?> GetOrderByIdAsync(int id);
    Task<List<Order>> GetOrdersByDateAsync(DateTime date);

    // Invoices
    Task<int> AddInvoiceAsync(Invoice invoice);
    Task<List<Invoice>> GetInvoicesAsync();
    Task<Invoice?> GetInvoiceByIdAsync(int id);
}