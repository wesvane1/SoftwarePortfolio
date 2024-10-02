class CompletedReminder
{
  public required string Title { get; set; }
  public required string Description { get; set; }
  public DateOnly CompletedDate { get; set; }

  public override string ToString()
  {
    return $"Title: {Title}\nDescription: {Description}\nDate Completed: {CompletedDate}";
  }
}