using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CSVGxpInventoryApp.Models;
using CSVGxpInventoryApp.Repositories;

namespace CSVGxpInventoryApp.ViewModels;

public class SystemViewModel : INotifyPropertyChanged
{
    private readonly SystemRepository _systemRepository;

    public ObservableCollection<SystemEntity> Systems { get; set; } = new();
    public ObservableCollection<SystemEntity> ObsoleteSystems { get; set; } = new();

    public ObservableCollection<string> Departments { get; set; } = new()
    {
        "Quality Assurance",
        "Quality Control",
        "Production",
        "Technical",
        "Microbiology"
    };

    public ObservableCollection<string> GampCategories { get; set; } = new()
    {
        "Category 1",
        "Category 3",
        "Category 4",
        "Category 5"
    };

    public ObservableCollection<string> GxpOptions { get; set; } = new()
    {
        "Yes",
        "No"
    };

    public ObservableCollection<string> ValidationStatuses { get; set; } = new()
    {
        "Validated",
        "In Progress",
        "Not Validated"
    };

    // DASHBOARD COUNTS
    public int TotalSystems => Systems.Count;
    public int GxpRelevantSystems => Systems.Count(s => s.IsGxpRelevant == "Yes");
    public int ValidatedSystems => Systems.Count(s => s.ValidationStatus.Equals("Validated", StringComparison.OrdinalIgnoreCase));
    public int InProgressSystems => Systems.Count(s => s.ValidationStatus.Equals("In Progress", StringComparison.OrdinalIgnoreCase));
    public int NotValidatedSystems => Systems.Count(s => s.ValidationStatus.Equals("Not Validated", StringComparison.OrdinalIgnoreCase));
    public int ObsoleteSystemsCount => ObsoleteSystems.Count;

    // FORM FIELDS
    private string _systemCode = string.Empty;
    public string SystemCode
    {
        get => _systemCode;
        set { _systemCode = value; OnPropertyChanged(); }
    }

    private string _systemName = string.Empty;
    public string SystemName
    {
        get => _systemName;
        set { _systemName = value; OnPropertyChanged(); }
    }

    private string _selectedDepartment = string.Empty;
    public string SelectedDepartment
    {
        get => _selectedDepartment;
        set { _selectedDepartment = value; OnPropertyChanged(); }
    }

    private string _owner = string.Empty;
    public string Owner
    {
        get => _owner;
        set { _owner = value; OnPropertyChanged(); }
    }

    private string _vendor = string.Empty;
    public string Vendor
    {
        get => _vendor;
        set { _vendor = value; OnPropertyChanged(); }
    }

    private string _softwareVersion = string.Empty;
    public string SoftwareVersion
    {
        get => _softwareVersion;
        set { _softwareVersion = value; OnPropertyChanged(); }
    }

    private string _selectedGampCategory = string.Empty;
    public string SelectedGampCategory
    {
        get => _selectedGampCategory;
        set { _selectedGampCategory = value; OnPropertyChanged(); }
    }

    private string _selectedGxpOption = string.Empty;
    public string SelectedGxpOption
    {
        get => _selectedGxpOption;
        set { _selectedGxpOption = value; OnPropertyChanged(); }
    }

    private string _validationStatus = string.Empty;
    public string ValidationStatus
    {
        get => _validationStatus;
        set { _validationStatus = value; OnPropertyChanged(); }
    }

    public SystemViewModel(SystemRepository systemRepository)
    {
        _systemRepository = systemRepository;
    }

    public async Task LoadSystemsAsync()
    {
        var activeSystems = await _systemRepository.GetSystemsAsync();
        var obsoleteSystems = await _systemRepository.GetObsoleteSystemsAsync();

        Systems.Clear();
        foreach (var system in activeSystems)
        {
            Systems.Add(system);
        }

        ObsoleteSystems.Clear();
        foreach (var system in obsoleteSystems)
        {
            ObsoleteSystems.Add(system);
        }

        RefreshDashboardCounts();
    }

    public async Task AddSystemAsync()
    {
        var newSystem = new SystemEntity
        {
            SystemCode = SystemCode,
            SystemName = SystemName,
            DepartmentId = GetDepartmentId(SelectedDepartment),
            Owner = Owner,
            Vendor = Vendor,
            SoftwareVersion = SoftwareVersion,
            GampCategory = SelectedGampCategory,
            IsGxpRelevant = SelectedGxpOption,
            ValidationStatus = ValidationStatus,
            IsObsolete = false
        };

        await _systemRepository.AddSystemAsync(newSystem);

        ClearForm();

        await LoadSystemsAsync();
    }

    public async Task MarkSystemAsObsoleteAsync(SystemEntity system)
    {
        if (system == null)
            return;

        await _systemRepository.MarkAsObsoleteAsync(system);

        await LoadSystemsAsync();
    }

    public async Task UpdateSystemAsync(SystemEntity system)
    {
        if (system == null)
            return;

        await _systemRepository.UpdateSystemAsync(system);

        await LoadSystemsAsync();
    }

    private int GetDepartmentId(string departmentName)
    {
        return departmentName switch
        {
            "Quality Assurance" => 1,
            "Quality Control" => 2,
            "Production" => 3,
            "Technical" => 4,
            "Microbiology" => 5,
            _ => 0
        };
    }

    private void ClearForm()
    {
        SystemCode = string.Empty;
        SystemName = string.Empty;
        SelectedDepartment = string.Empty;
        Owner = string.Empty;
        Vendor = string.Empty;
        SoftwareVersion = string.Empty;
        SelectedGampCategory = string.Empty;
        SelectedGxpOption = string.Empty;
        ValidationStatus = string.Empty;
    }

    private void RefreshDashboardCounts()
    {
        OnPropertyChanged(nameof(TotalSystems));
        OnPropertyChanged(nameof(GxpRelevantSystems));
        OnPropertyChanged(nameof(ValidatedSystems));
        OnPropertyChanged(nameof(InProgressSystems));
        OnPropertyChanged(nameof(NotValidatedSystems));
        OnPropertyChanged(nameof(ObsoleteSystemsCount));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}