using System;
using System.Collections.Generic;

namespace Automarket.Models;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ICollection<Model> Models { get; } = new List<Model>();
}
