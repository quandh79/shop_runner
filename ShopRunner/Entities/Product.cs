using System;
using System.Collections.Generic;

namespace ShopRunner.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal ImportPrice { get; set; }

    public decimal Price { get; set; }

    public int? Sale { get; set; }

    public string? Description { get; set; }

    public string Slug { get; set; } = null!;

    public int? Status { get; set; }

    public int? SizeId { get; set; }

    public int? Amount { get; set; }

    public int? ViewCount { get; set; }

    public int? CategoryId { get; set; }

    public int? ProviderId { get; set; }

    public virtual Category? Category { get; set; } = null;
}
