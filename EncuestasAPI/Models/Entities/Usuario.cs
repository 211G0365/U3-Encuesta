using System;
using System.Collections.Generic;

namespace EncuestasAPI.Models.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string EsAdmin { get; set; } = null!;

    public virtual ICollection<Encuesta> Encuesta { get; set; } = new List<Encuesta>();

    public virtual ICollection<Respuesta> Respuesta { get; set; } = new List<Respuesta>();
}
