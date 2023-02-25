namespace Automarket.Models;

public partial class Model
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    public int BrandId { get; set; }

    public virtual Brand? Brand { get; set; } = null!;
}
