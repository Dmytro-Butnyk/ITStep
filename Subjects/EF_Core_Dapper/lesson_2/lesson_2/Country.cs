using System;
using System.Collections.Generic;

namespace lesson_2;

public partial class Country
{
    public int Id { get; set; }

    public string CountryName { get; set; } = null!;

    public double Area { get; set; }

    public string WorldPart { get; set; } = null!;

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
