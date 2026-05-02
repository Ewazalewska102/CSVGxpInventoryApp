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

    public async Task<List<SystemEntity>> GetObsoleteSystemsAsync()
    {
        return await _databaseService.GetObsoleteSystemsAsync();
    }

    public async Task<int> UpdateSystemAsync(SystemEntity system)
    {
        return await _databaseService.UpdateSystemAsync(system);
    }

    public async Task<int> MarkAsObsoleteAsync(SystemEntity system)
    {
        return await _databaseService.MarkAsObsoleteAsync(system);
    }
}