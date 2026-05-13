using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Aule
{
    public int AulaId { get; set; }

    public string NomeAula { get; set; } = null!;

    public int Capacita { get; set; }

    public virtual ICollection<Lezioni> Lezionis { get; set; } = new List<Lezioni>();
}
