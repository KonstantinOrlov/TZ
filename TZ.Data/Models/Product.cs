﻿namespace TZ.Data.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Rating> Ratings { get; set; } = new();
    }
}
