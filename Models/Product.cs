﻿using System.ComponentModel.DataAnnotations;

namespace DotNetCore8Api.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        public int? ProductStock { get; set; }
    }
}
