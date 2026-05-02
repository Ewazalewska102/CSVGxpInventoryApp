namespace CSVGxpInventoryApp.Models;

public class SystemEntity
{
    public int SystemId { get; set; }

    public string SystemCode { get; set; } = string.Empty;

    public string SystemName { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public string Owner { get; set; } = string.Empty;

    public string Vendor { get; set; } = string.Empty;

    public string SoftwareVersion { get; set; } = string.Empty;

    public string GampCategory { get; set; } = string.Empty;

    public string IsGxpRelevant { get; set; } = string.Empty;

    public string ValidationStatus { get; set; } = string.Empty;
}