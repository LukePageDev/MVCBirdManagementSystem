using System.ComponentModel.DataAnnotations;
using Azure;
using Azure.Data.Tables;

namespace mvcBirds.Models
{
    public class Birder : ITableEntity
    {
        [Key]
        public int Birder_Id { get; set; }// Ensure this property exists and is populated
        public string? Birder_Name { get; set; }// Ensure this property exists and is populated
        public string? email { get; set; }
        public string? password { get; set; }

        //ITableEntity implementations
        public string PartitionKey { get; set; } 
        public string RowKey { get; set; }
        public ETag ETag { get; set; } 
        public DateTimeOffset? Timestamp { get; set; }

    }
}
