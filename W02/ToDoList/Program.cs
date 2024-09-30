using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ReminderApp
{
  class Program
  {
    static void Main(string[] args)
    {
      ReminderManager manager = new ReminderManager();
      manager.LoadReminders();
      manager.LoadCompletedReminders();

      bool exit = false;

      while (!exit)
      {
        Console.WriteLine("\nReminder Application");
        Console.WriteLine("1. Add a Reminder");
        Console.WriteLine("2. View Reminders");
        Console.WriteLine("3. Complete Reminder");
        Console.WriteLine("4. View Complete Reminders");
        Console.WriteLine("5. Delete a Reminder");
        Console.WriteLine("6. Exit");
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
            CompleteReminder(manager);
            break;
          case "4":
            manager.ViewCompletedReminders();
            break;
          case "5":
            DeleteReminder(manager);
            break;
          case "6":
            exit = true;
            break;
          default:
            Console.WriteLine("\nInvalid option. Please try again.");
            break;
        }
      }

      manager.SaveReminders();
      manager.SaveCompletedReminders(); // Save completed reminders when exiting
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

      Reminder reminder = new Reminder
      {
        Title = title,
        Description = description,
        ReminderDate = reminderDate
      };
      manager.AddReminder(reminder);
    }

    static void CompleteReminder(ReminderManager manager)
    {
      manager.ViewReminders();

      Console.Write("Enter the reminder number to complete: ");
      int index;
      while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > manager.RemindersCount)
      {
        Console.Write("Invalid input. Please enter a valid number: ");
      }

      manager.CompleteReminder(index - 1);
    }

    static void DeleteReminder(ReminderManager manager)
    {
      manager.ViewReminders();

      Console.Write("Enter the reminder number to delete: ");
      int index;
      while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > manager.RemindersCount)
      {
        Console.Write("Invalid input. Please enter a valid number: ");
      }

      manager.DeleteReminder(index - 1);
    }
  }
}
