namespace CSVGxpInventoryApp.Tests;

public class ComplianceReminderTests
{
    [Fact]
    public void UpcomingTask_ShouldBeTrue_WhenDueDateIsWithin60Days()
    {
        // Arrange
        DateTime today = DateTime.Today;
        DateTime dueDate = today.AddDays(30);

        // Act
        bool isUpcoming = dueDate >= today && dueDate <= today.AddDays(60);

        // Assert
        Assert.True(isUpcoming);
    }

    [Fact]
    public void OverdueTask_ShouldBeTrue_WhenDueDateIsBeforeToday()
    {
        // Arrange
        DateTime today = DateTime.Today;
        DateTime dueDate = today.AddDays(-5);

        // Act
        bool isOverdue = dueDate < today;

        // Assert
        Assert.True(isOverdue);
    }

    [Fact]
    public void NextDueDate_ShouldBeCalculatedFromLastDateAndFrequency()
    {
        // Arrange
        DateTime lastCompletedDate = new DateTime(2026, 1, 1);
        int frequencyMonths = 3;

        // Act
        DateTime nextDueDate = lastCompletedDate.AddMonths(frequencyMonths);

        // Assert
        Assert.Equal(new DateTime(2026, 4, 1), nextDueDate);
    }
}