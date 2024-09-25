namespace ReminderApp
{
  class Program
  {
    static void Main(string[] args)
    {
      ReminderManager manager = new ReminderManager();
      bool exit = false;

      while (!exit)
      {
        Console.WriteLine("\nReminder Application");
        Console.WriteLine("1. Add a Reminder");
        Console.WriteLine("2. View Reminders");
        Console.WriteLine("3. Delete a Reminder");
        Console.WriteLine("4. Exit");
        Console.Write("Choose an option: ");
        
        string? choice = Console.ReadLine();
        if (choice == null)
        {
          Console.WriteLine("\nInvalid option. Please try again.");
          continue;
        }

        switch (choice)
        {
          case "1":
            AddReminder(manager);
            break;
          case "2":
            manager.ViewReminders();
            break;
          case "3":
            DeleteReminder(manager);
            break;
          case "4":
            exit = true;
            break;
          default:
            Console.WriteLine("\nInvalid option. Please try again.");
            break;
        }
      }
      Console.WriteLine("\nGoodbye!");
    }

    static void AddReminder(ReminderManager manager)
    {
      Console.Write("Enter a reminder title: ");
      string title = Console.ReadLine() ?? "Default Title";
      Console.Write("Enter reminder description: ");
      string description = Console.ReadLine() ?? "Default Description";
      Console.Write("Enter reminder date (yyyy-mm-dd): ");
      DateOnly reminderDate;
      while (!DateOnly.TryParse(Console.ReadLine(), out reminderDate))
      {
        Console.Write("Invalid date format. Please enter date (yyyy-mm-dd): ");
      }

      if (title != null && description != null)
      {
        Reminder reminder = new Reminder
        {
          Title = title,
          Description = description,
          ReminderDate = reminderDate
        };
        manager.AddReminder(reminder);
      }
      else
      {
        throw new ArgumentNullException("Title or Description cannot be null");
      }
    }

    static void DeleteReminder(ReminderManager manager)
    {
      manager.ViewReminders();
      
      Console.Write("Enter the reminder number to delete: ");
      int index;
      while (!int.TryParse(Console.ReadLine(), out index))
      {
        Console.Write("Invalid input. Please enter a valid number: ");
      }

      manager.DeleteReminder(index - 1);
    }
  }
}