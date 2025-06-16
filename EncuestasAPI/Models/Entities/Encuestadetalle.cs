using System;
using System.Collections.Generic;

namespace EncuestasAPI.Models.Entities;

public partial class Encuestadetalle
{
    public int Id { get; set; }

    public int IdRespuesta { get; set; }

    public int IdPregunta { get; set; }

    public int ValorEvaluacion { get; set; }

    public virtual Pregunta IdPreguntaNavigation { get; set; } = null!;

    public virtual Respuesta IdRespuestaNavigation { get; set; } = null!;
}
