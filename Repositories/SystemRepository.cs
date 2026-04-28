using CSVGxpInventoryApp.Models;
using CSVGxpInventoryApp.Services;

namespace CSVGxpInventoryApp.Repositories;

public class SystemRepository
{
    private readonly DatabaseService _databaseService;

    public SystemRepository(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public async Task<int> AddSystemAsync(SystemEntity system)
    {
        return await _databaseService.AddSystemAsync(system);
    }

    public async Task<List<SystemEntity>> GetSystemsAsync()
    {
        return await _databaseService.GetSystemsAsync();
    }
}