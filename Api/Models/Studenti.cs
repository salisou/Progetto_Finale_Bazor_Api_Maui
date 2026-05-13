using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Studenti
{
    public int StudenteId { get; set; }

    public string? Nome { get; set; }

    public string Cognome { get; set; } = null!;

    public DateOnly? DataNascita { get; set; }

    public string Email { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string CodiceFiscale { get; set; } = null!;

    public virtual ICollection<Iscrizioni> Iscrizionis { get; set; } = new List<Iscrizioni>();
}
