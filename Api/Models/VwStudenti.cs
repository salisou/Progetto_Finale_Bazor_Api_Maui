using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class VwStudenti
{
    public int StudenteId { get; set; }

    public string? NomeCompleto { get; set; }

    public string DataNascita { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string CodiceFiscale { get; set; } = null!;
}
