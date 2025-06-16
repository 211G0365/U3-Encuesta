using System;
using System.Collections.Generic;

namespace EncuestasAPI.Models.Entities;

public partial class Respuesta
{
    public int Id { get; set; }

    public int IdEncuesta { get; set; }

    public int IdUsuarioAplicador { get; set; }

    public string NombreAlumno { get; set; } = null!;

    public string NumControlAlumno { get; set; } = null!;

    public DateTime FechaAplicacion { get; set; }

    public virtual ICollection<Encuestadetalle> Encuestadetalle { get; set; } = new List<Encuestadetalle>();

    public virtual Encuesta IdEncuestaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioAplicadorNavigation { get; set; } = null!;
}
