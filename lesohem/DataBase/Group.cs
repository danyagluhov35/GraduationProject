using System;
using System.Collections.Generic;

namespace lesohem.DataBase;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Info { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
