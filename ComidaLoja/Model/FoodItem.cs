﻿using System;
namespace ComidaLoja.Model
{
    public class FoodItem
    {
        public int Product { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public string RatingDetail { get; set; }
        public string HomeSelected { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public int ProductID { get; internal set; }
    }
}
