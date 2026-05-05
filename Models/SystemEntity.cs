using SQLite;

namespace CSVGxpInventoryApp.Models;

public class SystemEntity
{
    [PrimaryKey, AutoIncrement]
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
    public bool IsObsolete { get; set; } = false;

    public DateTime? LastReviewDate { get; set; }
    public int ReviewFrequencyMonths { get; set; } = 12;

    public DateTime? LastBackupDate { get; set; }
    public int BackupFrequencyMonths { get; set; } = 3;

    public DateTime? LastAuditTrailReviewDate { get; set; }
    public int AuditTrailFrequencyMonths { get; set; } = 3;

    [Ignore]
    public DateTime? NextReviewDueDate => LastReviewDate?.Date.AddMonths(ReviewFrequencyMonths);

    [Ignore]
    public DateTime? NextBackupDueDate => LastBackupDate?.Date.AddMonths(BackupFrequencyMonths);

    [Ignore]
    public DateTime? NextAuditTrailDueDate => LastAuditTrailReviewDate?.Date.AddMonths(AuditTrailFrequencyMonths);

    [Ignore]
    public string ReviewStatusMessage => GetStatusMessage(NextReviewDueDate);

    [Ignore]
    public string BackupStatusMessage => GetStatusMessage(NextBackupDueDate);

    [Ignore]
    public string AuditTrailStatusMessage => GetStatusMessage(NextAuditTrailDueDate);

    private string GetStatusMessage(DateTime? dueDate)
    {
        if (dueDate == null)
            return "No schedule set";

        int days = (dueDate.Value.Date - DateTime.Today).Days;

        if (days < 0)
            return $"Overdue by {Math.Abs(days)} day(s)";

        if (days == 0)
            return "Due today";

        if (days <= 30)
            return $"Due in {days} day(s)";

        return $"Due in {days} day(s)";
    }
}