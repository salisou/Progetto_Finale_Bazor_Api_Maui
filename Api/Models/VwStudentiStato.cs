using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class VwStudentiStato
{
    public int StudenteId { get; set; }

    public string? NomeCompleto { get; set; }

    public string Stato { get; set; } = null!;
}
