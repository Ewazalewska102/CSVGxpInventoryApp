using System.Collections.ObjectModel;
using CSVGxpInventoryApp.Models;
using CSVGxpInventoryApp.Repositories;

namespace CSVGxpInventoryApp.ViewModels;

public class SystemViewModel
{
    private readonly SystemRepository _systemRepository;

    public ObservableCollection<SystemEntity> Systems { get; set; } = new();

    public SystemViewModel(SystemRepository systemRepository)
    {
        _systemRepository = systemRepository;
    }

    public async Task LoadSystemsAsync()
    {
        var systems = await _systemRepository.GetSystemsAsync();

        Systems.Clear();

        foreach (var system in systems)
        {
            Systems.Add(system);
        }
    }
}