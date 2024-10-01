// Union-like struct to simulate handling multiple types
// The Reminder Data struct does nothing, simply shows that you can create a union in C#
struct ReminderData
{
  public string Title;
  public string Description;
  public int ReminderNumber;

  public ReminderData(string title, string description)
  {
    ReminderNumber = 0;
    Title = title;
    Description = description;
  }

  public ReminderData(int reminderNumber)
  {
    Title = string.Empty;
    Description = string.Empty;
    ReminderNumber = reminderNumber;
  }

  public override string ToString()
  {
    if (!string.IsNullOrEmpty(Title))
    {
      return $"Title: {Title}, Description: {Description}";
    }
    else
    {
      return $"Reminder Number: {ReminderNumber}";
    }
  }
}

// Struct for simple date, converts input to SimpleDate
struct SimpleDate
{
  public int Year;
  public int Month;
  public int Day;

  public DateOnly ToDateOnly()
  {
    return new DateOnly(Year, Month, Day);
  }
}