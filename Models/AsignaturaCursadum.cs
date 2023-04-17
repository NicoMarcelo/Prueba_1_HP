using System;
using System.Collections.Generic;

namespace Prueba_1_HP.Models;

public partial class AsignaturaCursadum
{
    public int IdAsignaturaCursada { get; set; }

    public string EstudiantesRutEstudiante { get; set; } = null!;

    public int AsignaturasCodigoAsignatura { get; set; }

    public virtual Asignatura AsignaturasCodigoAsignaturaNavigation { get; set; } = null!;

    public virtual Estudiante EstudiantesRutEstudianteNavigation { get; set; } = null!;
}
