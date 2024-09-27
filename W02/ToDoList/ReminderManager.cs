class ReminderManager
{
  private List<Reminder> reminders = new List<Reminder>();
  private const string FileName = "reminders.txt";

  public void AddReminder(Reminder reminder)
  {
    reminders.Add(reminder);
    Console.WriteLine("\nReminder added successfully!");
  }

  public void ViewReminders()
  {
    if (reminders.Count == 0)
    {
      Console.WriteLine("\nNo reminders available.");
    }
    else
    {
      Console.WriteLine("\nList of Reminders:");
      for (int i = 0; i < reminders.Count; i++)
      {
        Console.WriteLine($"\nReminder #{i + 1}:\n{reminders[i]}\n");
      }
    }
  }

  public void DeleteReminder(int index)
  {
    if (index < 0 || index >= reminders.Count)
    {
      Console.WriteLine("Invalid index. Cannot delete reminder.");
    }
    else
    {
      reminders.RemoveAt(index);
      Console.WriteLine("Reminder deleted successfully!");
    }
  }

  public void SaveReminders()
  {
    using (StreamWriter writer = new StreamWriter(FileName))
    {
      foreach (Reminder reminder in reminders)
        {
          writer.WriteLine(reminder.Title);
          writer.WriteLine(reminder.Description);
          writer.WriteLine(reminder.ReminderDate.ToString("yyyy-MM-dd"));
        }
    }
  }

  public void LoadReminders()
  {
    if (File.Exists(FileName))
    {
      using (StreamReader reader = new StreamReader(FileName))
      {
        while (!reader.EndOfStream)
        {
          string title = reader.ReadLine() ?? string.Empty;
          string description = reader.ReadLine() ?? string.Empty;
          if (DateOnly.TryParse(reader.ReadLine(), out DateOnly date))
          {
            reminders.Add(new Reminder { Title = title, Description = description, ReminderDate = date });
          }
        }
      }
    }
  }
}