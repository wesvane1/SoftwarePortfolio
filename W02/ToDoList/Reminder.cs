class Reminder{
  public required string Title { get; set; }
  public required string Description { get; set; }
  public DateOnly ReminderDate { get; set; }

    public override string ToString()
    {
        return $"Title: {Title}\nDescription: {Description}\nReminder Time: {ReminderDate}";
    }
}