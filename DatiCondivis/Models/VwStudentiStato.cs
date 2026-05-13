using System;
using System.Collections.Generic;

namespace DatiCondivisi.Models;

public partial class VwStudentitato
{
    public int StudenteId { get; set; }

    public string? NomeCompleto { get; set; }

    public string Stato { get; set; } = null!;
}
