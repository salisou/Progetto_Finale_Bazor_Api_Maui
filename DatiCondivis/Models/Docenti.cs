using System;
using System.Collections.Generic;

namespace DatiCondivisi.Models;

public partial class Docenti
{
    public int DocenteId { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string? Email { get; set; }

    public string? Specializzazione { get; set; }

    public virtual ICollection<DocentiCorso> DocentiCorso { get; set; } = new List<DocentiCorso>();
}
