﻿using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Data
{
    public class Blog : BaseEntity
    {
        public string? Slug { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public string? AuthorId { get; set; }
        public User? User { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public string? FeaturesImage { get; set; }
        public string? Status { get; set; }
        public int View { get; set; }

        public ICollection<BlogTag>? BlogTags { get; set; }
    }
}
