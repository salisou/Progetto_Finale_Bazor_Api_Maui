using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class VwCorsiStato
{
    public string? NomeCorso { get; set; }

    public int? TotaleStudenti { get; set; }

    public string StatoCorso { get; set; } = null!;
}
