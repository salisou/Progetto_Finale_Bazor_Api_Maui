using System;
using System.Collections.Generic;

namespace DatiCondivisi.Models;

public partial class VwCorsitato
{
    public string? NomeCorso { get; set; }

    public int? TotaleStudenti { get; set; }

    public string StatoCorso { get; set; } = null!;
}
