using System;
using System.Collections.Generic;

namespace DatiCondivisi.Models;

public partial class Lezioni
{
    public int LezioneId { get; set; }

    public int CorsoId { get; set; }

    public int AulaId { get; set; }

    public DateOnly DataLezione { get; set; }

    public TimeOnly? OraInizio { get; set; }

    public TimeOnly? OraFine { get; set; }

    public virtual Aule Aula { get; set; } = null!;

    public virtual Corsi Corso { get; set; } = null!;
}
