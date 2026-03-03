using MauiCarWorkshop.Models;
using SQLite;

namespace MauiCarWorkshop.Services;

public class DatabaseService : IDatabaseService
{
    private readonly SQLiteAsyncConnection _connection;

    public DatabaseService()
    {
        var dataDir = FileSystem.AppDataDirectory;
        var databasePath = Path.Combine(dataDir, "MauiCarWorkshop.db");

        string _dbEncryptionKey = SecureStorage.GetAsync("dbKey").Result;

        if (string.IsNullOrEmpty(_dbEncryptionKey))
        {
            Guid g = Guid.NewGuid();
            _dbEncryptionKey = g.ToString();
            SecureStorage.SetAsync("dbKey", _dbEncryptionKey);
        }

        var dbOptions = new SQLiteConnectionString(databasePath, true, key: _dbEncryptionKey);

        _connection = new SQLiteAsyncConnection(dbOptions);
        _ = Intialise();
    }

    private async Task Intialise()
    {
        await _connection.CreateTableAsync<Order>();
        await _connection.CreateTableAsync<Invoice>();
    }


    // Order 
    public async Task<List<Order>> GetOrdersAsync()
    {
        return await _connection.Table<Order>().ToListAsync();
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        var query = _connection.Table<Order>().Where(t => t.OrderId == id);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<int> AddOrderAsync(Order item)
    {
        return await _connection.InsertAsync(item);
    }

    public async Task<int> DeleteOrderAsync(Order item)
    {
        return await _connection.DeleteAsync(item);
    }

    public async Task<int> UpdateOrderAsync(Order item)
    {
        return await _connection.UpdateAsync(item);
    }

    public async Task<List<Order>> GetOrdersByDateAsync(DateTime date)
    {
        var start = date.Date;
        var end = start.AddDays(1);

        return await _connection.Table<Order>()
            .Where(o => o.DeliveryDateTime >= start && o.DeliveryDateTime < end)
            .ToListAsync();
    }


    // Invoice
    public async Task<List<Invoice>> GetInvoicesAsync()
    {
        return await _connection.Table<Invoice>().ToListAsync();
    }

    public async Task<Invoice> GetInvoiceByIdAsync(int id)
    {
        var query = _connection.Table<Invoice>().Where(t => t.InvoiceId == id);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<int> AddInvoiceAsync(Invoice item)
    {
        return await _connection.InsertAsync(item);
    }

    public async Task<int> DeleteInvoiceAsync(Invoice item)
    {
        return await _connection.DeleteAsync(item);
    }

    public async Task<int> UpdateInvoiceAsync(Invoice item)
    {
        return await _connection.UpdateAsync(item);
    }
}