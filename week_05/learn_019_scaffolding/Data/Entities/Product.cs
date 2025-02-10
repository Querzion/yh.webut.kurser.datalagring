using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public int Price { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
