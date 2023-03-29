using System;
using System.Collections.Generic;

namespace lesohem.DataBase;

public partial class User
{
    public int Id { get; set; }

    public string? UserLogin { get; set; }

    public string? UserPassword { get; set; }

    public string? UserRole { get; set; }

    public byte[]? Photo { get; set; }

    public string? CountryName { get; set; }

    public string? CityName { get; set; }

    public string? GroupName { get; set; }

    public string? DirectionName { get; set; }

    public string? Gender { get; set; }

    public string? Name { get; set; }

    public string? SurName { get; set; }

    public virtual City? CityNameNavigation { get; set; }

    public virtual Country? CountryNameNavigation { get; set; }

    public virtual Direction? DirectionNameNavigation { get; set; }

    public virtual Group? GroupNameNavigation { get; set; }

    public virtual ICollection<SocMedium> SocMedia { get; } = new List<SocMedium>();
}
