using System;
using System.Collections.Generic;

namespace EncuestasAPI.Models.Entities;

public partial class Pregunta
{
    public int IdPregunta { get; set; }

    public string Descripcion { get; set; } = null!;

    public int IdEncuesta { get; set; }

    public int NumeroPregunta { get; set; }

    public virtual ICollection<Encuestadetalle> Encuestadetalle { get; set; } = new List<Encuestadetalle>();

    public virtual Encuesta IdEncuestaNavigation { get; set; } = null!;
}
