using SQLite;
using CSVGxpInventoryApp.Models;

namespace CSVGxpInventoryApp.Services;

public class DatabaseService
{
    private SQLiteAsyncConnection? _database;

    private async Task Init()
    {
        if (_database != null)
            return;

        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "gxp_inventory.db");

        _database = new SQLiteAsyncConnection(databasePath);

        // Create tables
        await _database.CreateTableAsync<SystemEntity>();
        await _database.CreateTableAsync<Department>();
    }

    //INSERT System
    public async Task<int> AddSystemAsync(SystemEntity system)
    {
        await Init();
        return await _database!.InsertAsync(system);
    }

    // GET all Systems
    public async Task<List<SystemEntity>> GetSystemsAsync()
    {
        await Init();
        return await _database!.Table<SystemEntity>().ToListAsync();
    }

    // INSERT Department
    public async Task<int> AddDepartmentAsync(Department department)
    {
        await Init();
        return await _database!.InsertAsync(department);
    }

    // GET all Departments
    public async Task<List<Department>> GetDepartmentsAsync()
    {
        await Init();
        return await _database!.Table<Department>().ToListAsync();
    }
}