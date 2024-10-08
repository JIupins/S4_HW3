﻿using S4_HW3.Models;
using System.ComponentModel.DataAnnotations;

namespace S4_HW3.Contracts.Requests
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
        public int? CategoryId { get; set; }
    }
}