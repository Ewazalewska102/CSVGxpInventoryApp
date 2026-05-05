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

        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "gxp_inventory_v3.db");

        _database = new SQLiteAsyncConnection(databasePath);

        // Create tables
        await _database.CreateTableAsync<SystemEntity>();
        await _database.CreateTableAsync<Department>();
    }

    // INSERT System
    public async Task<int> AddSystemAsync(SystemEntity system)
    {
        await Init();

        system.IsObsolete = false;

        return await _database!.InsertAsync(system);
    }

    // GET active systems only
    public async Task<List<SystemEntity>> GetSystemsAsync()
    {
        await Init();

        return await _database!
            .Table<SystemEntity>()
            .Where(s => !s.IsObsolete)
            .ToListAsync();
    }

    // GET obsolete systems only
    public async Task<List<SystemEntity>> GetObsoleteSystemsAsync()
    {
        await Init();

        return await _database!
            .Table<SystemEntity>()
            .Where(s => s.IsObsolete)
            .ToListAsync();
    }

    // UPDATE System
    public async Task<int> UpdateSystemAsync(SystemEntity system)
    {
        await Init();

        return await _database!.UpdateAsync(system);
    }

    // MARK System as obsolete
    public async Task<int> MarkAsObsoleteAsync(SystemEntity system)
    {
        await Init();

        system.IsObsolete = true;

        return await _database!.UpdateAsync(system);
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