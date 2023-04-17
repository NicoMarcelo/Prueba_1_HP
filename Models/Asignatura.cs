using System;
using System.Collections.Generic;

namespace Prueba_1_HP.Models;

public partial class Asignatura
{
    public string NombreAsignatura { get; set; } = null!;

    public string DescripcionAsignatura { get; set; } = null!;

    public int CodigoAsignatura { get; set; }

    public DateOnly FechaActualizaciónAsignatura { get; set; }

    public virtual ICollection<AsignaturaCursadum> AsignaturaCursada { get; set; } = new List<AsignaturaCursadum>();
}
