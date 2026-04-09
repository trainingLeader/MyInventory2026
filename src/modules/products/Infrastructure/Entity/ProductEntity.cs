using System;
using MyInventory2026.src.modules.provider.Infrastructure.entity;

namespace MyInventory2026.src.modules.products.Infrastructure.Entity;

public class ProductEntity
{
    public int id { get; set; }
    public string? codeInv { get; set; }
    public string? nameProduct { get; set; }
    public int stock { get; set; }
    public int stockMin { get; set; }
    public int stockMax { get; set; }
    public string? Description { get; set; }
    public  ICollection<ProviderEntity> Providers { get; set; } = new List<ProviderEntity>();
}
