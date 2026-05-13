using System;
using System.Collections.Generic;

namespace DatiCondivisi.Models;

public partial class VwGetCorsi
{
    public int CorsoId { get; set; }

    public string? NomeCorso { get; set; }

    public string? DescrizioneCorso { get; set; }

    public int? Crediti { get; set; }

    public int? Durata { get; set; }
}
