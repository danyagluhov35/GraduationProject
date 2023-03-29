using System;
using System.Collections.Generic;

namespace lesohem.DataBase;

public partial class Direction
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
