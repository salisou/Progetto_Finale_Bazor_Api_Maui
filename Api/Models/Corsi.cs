using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Corsi
{
    public int CorsoId { get; set; }

    public string? NomeCorso { get; set; }

    public string? DescrizioneCorso { get; set; }

    public int? Crediti { get; set; }

    public int? Durata { get; set; }

    public virtual ICollection<DocentiCorso> DocentiCorsos { get; set; } = new List<DocentiCorso>();

    public virtual ICollection<Iscrizioni> Iscrizionis { get; set; } = new List<Iscrizioni>();

    public virtual ICollection<Lezioni> Lezionis { get; set; } = new List<Lezioni>();
}
