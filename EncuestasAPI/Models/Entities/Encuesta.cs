using System;
using System.Collections.Generic;

namespace EncuestasAPI.Models.Entities;

public partial class Encuesta
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public string Titulo { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Pregunta> Pregunta { get; set; } = new List<Pregunta>();

    public virtual ICollection<Respuesta> Respuesta { get; set; } = new List<Respuesta>();
}
