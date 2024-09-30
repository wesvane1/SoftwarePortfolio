class ReminderManager
{
  private List<Reminder> reminders = new List<Reminder>();
  private List<CompletedReminder> completedReminders = new List<CompletedReminder>();
  private const string FileName = "reminders.txt";
  private const string CompleteFileName = "completed.txt";

  public int RemindersCount => reminders.Count;

  public void AddReminder(Reminder reminder)
  {
    reminders.Add(reminder);
    Console.WriteLine("\nReminder added successfully!");
  }

  public void CompleteReminder(int index)
  {
    if (index < 0 || index >= reminders.Count)
    {
      Console.WriteLine("Invalid index. Cannot complete reminder.");
      return;
    }

    var completedReminder = new CompletedReminder
    {
      Title = reminders[index].Title,
      Description = reminders[index].Description,
      CompletedDate = DateOnly.FromDateTime(DateTime.Now)
    };
    completedReminders.Add(completedReminder);
    reminders.RemoveAt(index);
    Console.WriteLine("Reminder completed successfully!");
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

  public void LoadCompletedReminders()
  {
    if (File.Exists(CompleteFileName))
    {
      using (StreamReader reader = new StreamReader(CompleteFileName))
      {
        while (!reader.EndOfStream)
        {
          string title = reader.ReadLine() ?? string.Empty;
          string description = reader.ReadLine() ?? string.Empty;
          if (DateOnly.TryParse(reader.ReadLine(), out DateOnly date))
          {
            completedReminders.Add(new CompletedReminder { Title = title, Description = description, CompletedDate = date });
          }
        }
      }
    }
  }

  public void SaveCompletedReminders()
  {
    using (StreamWriter writer = new StreamWriter(CompleteFileName))
    {
      foreach (CompletedReminder completed in completedReminders)
      {
        writer.WriteLine(completed.Title);
        writer.WriteLine(completed.Description);
        writer.WriteLine(completed.CompletedDate.ToString("yyyy-MM-dd"));
      }
    }
  }

  public void ViewCompletedReminders()
  {
    if (completedReminders.Count == 0)
    {
      Console.WriteLine("\nNo completed reminders available.");
    }
    else
    {
      Console.WriteLine("\nList of Completed Reminders:");
      for (int i = 0; i < completedReminders.Count; i++)
      {
        Console.WriteLine($"\nCompleted Reminder #{i + 1}:\n{completedReminders[i]}\n");
      }
    }
  }
}