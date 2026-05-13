using System;
using System.Collections.Generic;

namespace DatiCondivisi.Models;

public partial class Aule
{
    public int AulaId { get; set; }

    public string NomeAula { get; set; } = null!;

    public int Capacita { get; set; }

    public virtual ICollection<Lezioni> Lezioni { get; set; } = new List<Lezioni>();
}
