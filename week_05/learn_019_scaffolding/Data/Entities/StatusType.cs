using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class StatusType
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
