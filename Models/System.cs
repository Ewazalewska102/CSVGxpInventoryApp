namespace CSVGxpInventoryApp.Models;

public class System
{
    public int SystemId { get; set; }

    public string SystemName { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public string Owner { get; set; } = string.Empty;

    public string Vendor { get; set; } = string.Empty;

    public string ValidationStatus { get; set; } = string.Empty;
}