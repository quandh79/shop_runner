using System;
using System.Collections.Generic;

namespace ShopRunner.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string? GeneralityName { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public int? Status { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
