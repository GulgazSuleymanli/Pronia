﻿namespace Pronia_FronttoBack.Models
{
    public class Image:BaseEntity
    {
        public string ImageUrl { get; set; }
        public bool? IsPrimary { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
