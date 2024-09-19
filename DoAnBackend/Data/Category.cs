﻿namespace DoAnBackend.Data
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
