using System;
using System.Collections.Generic;

namespace Prueba_1_HP.Models;

public partial class Estudiante
{
    public string NombreEstudiante { get; set; } = null!;

    public string EmailEstudiante { get; set; } = null!;

    public string ApellidoEstudiante { get; set; } = null!;

    public string RutEstudiante { get; set; } = null!;

    public string DireccionEstudiante { get; set; } = null!;

    public string? sexo { get; set; }

    public string nombre_apoderado { get; set; } = null!;

    public int EdadEstudiante { get; set; }

    public DateOnly FechaNacimientoEstudiante { get; set; }

    public virtual ICollection<AsignaturaCursadum> AsignaturaCursada { get; set; } = new List<AsignaturaCursadum>();
}
