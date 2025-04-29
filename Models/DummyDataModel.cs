namespace TodoApi.Models
{
    // This class represents the data model for items in the database
    public class Item
    {
        // Unique identifier for each item
        public int Id { get; set; }

        // Name of the item (e.g., task name or title)
        public string Name { get; set; } = string.Empty;

        // Description of the item (e.g., task details or description)
        public string Description { get; set; } = string.Empty;

        // Date associated with the item (e.g., due date or creation date)
        public DateTime Date { get; set; }
    }
}
