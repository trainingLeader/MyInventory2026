using MyInventory2026.src.modules.products.Infrastructure.Entity;

namespace MyInventory2026.src.modules.provider.Infrastructure.entity;

public class ProviderEntity
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public  ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();

}
