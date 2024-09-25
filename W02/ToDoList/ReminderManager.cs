class ReminderManager
{
  private List<Reminder> reminders = new List<Reminder>();

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
}