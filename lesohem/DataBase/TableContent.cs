using System;
using System.Collections.Generic;

namespace lesohem.DataBase;

public partial class TableContent
{
    public int Id { get; set; }

    public string? ElementDiv { get; set; }

    public string? Path { get; set; }

    public string? Name { get; set; }

    public int? TableBlockId { get; set; }

    public virtual TableBlock? TableBlock { get; set; }
}
