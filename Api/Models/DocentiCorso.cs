using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class DocentiCorso
{
    public int Id { get; set; }

    public int DocenteId { get; set; }

    public int CorsoId { get; set; }

    public virtual Corsi Corso { get; set; } = null!;

    public virtual Docenti Docente { get; set; } = null!;
}
