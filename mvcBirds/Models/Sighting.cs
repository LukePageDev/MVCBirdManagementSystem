using Azure;
using Azure.Data.Tables;
using System.ComponentModel.DataAnnotations;

namespace mvcBirds.Models
{
    public class Sighting : ITableEntity
    {
        [Key]
        public int Sighting_Id { get; set; }
        public string? PartitionKey { get; set; }
        public string? RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
        // Introduce validation sameple
        [Required(ErrorMessage = "Please select a birder")]
        public int Birder_ID { get; set; } // Foreign key to the Birder who made the sighting

        [Required(ErrorMessage = "Please select a bird")]
        public int Bird_ID { get; set; } // Foreign key to the Bird that was sighted

        [Required(ErrorMessage = "Please enter a date")]
        public DateTime Sighting_Date { get; set; } // Date of the sighting

        [Required(ErrorMessage = "Please enter a location")]
        public string? Sighting_Location { get; set; } // Location of the sighting
    }
}
