using System;
using System.Collections.Generic;

namespace lesohem.DataBase;

public partial class TableBlock
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<TableContent> TableContents { get; } = new List<TableContent>();
}
