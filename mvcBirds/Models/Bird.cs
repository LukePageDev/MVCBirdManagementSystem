﻿using System.ComponentModel.DataAnnotations;
using Azure;
using Azure.Data.Tables;

namespace mvcBirds.Models
{
    public class Bird : ITableEntity
    {
        [Key]
        public int Bird_Id { get; set; }
        public string? Bird_Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? Location { get; set; }
        public string? PartitionKey { get; set; }
        public string? RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
        
    }
}
