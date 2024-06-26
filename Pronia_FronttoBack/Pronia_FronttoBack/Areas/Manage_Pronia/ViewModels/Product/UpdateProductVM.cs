﻿namespace Pronia_FronttoBack.Areas.Manage_Pronia.ViewModels
{
    public class UpdateProductVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public List<Category>? Categories { get; set; }
        public List<int>? ColorIds { get; set; }
        public List<Color>? Colors { get; set; }
        public List<int>? SizeIds { get; set; }
        public List<Size>? Sizes { get; set; }
        public List<int>? TagIds { get; set; }
        public List<Tag>? Tags { get; set; }
        public IFormFile? MainPhoto { get; set; }
        public IFormFile? HoverPhoto { get; set; }
        public List<IFormFile>? Photos { get; set; }
        public List<ImageVM>? ImagesVM { get; set; }
        public List<int>? ImageIds { get; set; }
    }

    public class ImageVM
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsPrimary { get; set; }
    }
}
