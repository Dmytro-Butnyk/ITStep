using System;
using System.Collections.Generic;

namespace lesson_2;

public partial class City
{
    public int Id { get; set; }

    public string CityName { get; set; } = null!;

    public int? Population { get; set; }

    public bool? IsCapital { get; set; }

    public int CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;
}
