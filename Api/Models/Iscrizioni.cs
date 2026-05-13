using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Iscrizioni
{
    public int IscrizioneId { get; set; }

    public int StudenteId { get; set; }

    public int CorsoId { get; set; }

    public DateOnly DataIscrizione { get; set; }

    public virtual Corsi Corso { get; set; } = null!;

    public virtual Studenti Studente { get; set; } = null!;
}
