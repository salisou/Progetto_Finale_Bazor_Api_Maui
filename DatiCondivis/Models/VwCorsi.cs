using System;
using System.Collections.Generic;

namespace DatiCondivisi.Models;

public partial class VwCorsi
{
    public int CorsoId { get; set; }

    public string? NomeDelCorso { get; set; }

    public string DescrizioneCorso { get; set; } = null!;

    public string Crediti { get; set; } = null!;

    public int Durata { get; set; }
}
