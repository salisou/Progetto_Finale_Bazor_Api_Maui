using System;
using System.Collections.Generic;

namespace DatiCondivisi.Models;

public partial class LogBackup
{
    public int Id { get; set; }

    public string NomeDatabase { get; set; } = null!;

    public string PercorsoFile { get; set; } = null!;

    public DateTime DataBackup { get; set; }

    public string Utente { get; set; } = null!;
}
