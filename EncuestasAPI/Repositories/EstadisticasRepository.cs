using EncuestasAPI.Models.DTOs;
using EncuestasAPI.Models.Entities;

namespace EncuestasAPI.Repositories
{
	public class EstadisticasRepository
	{
		public EncuestaContext Context { get; set; }


		public EstadisticasRepository(EncuestaContext context) {
			Context = context;
		}
		public int GetTotalEncuestasCreadas()
		{
			return Context.Encuesta.Count();
		}

		public int GetTotalEncuestasSinResponder()
		{
			return Context.Encuesta
				.Count(e => !Context.Respuesta.Any(r => r.IdEncuesta == e.Id));
		}


		public int GetTotalEncuestasRespondidas()
		{
			return Context.Respuesta.Count();
		}

		public double GetPromedioRespuestasPorEncuesta()
		{
			var totalEncuestas = GetTotalEncuestasCreadas();
			if (totalEncuestas == 0) return 0;

			var totalRespuestas = GetTotalEncuestasRespondidas();
			return Math.Round((double)totalRespuestas / totalEncuestas, 2);
		}
		public int GetTotalAlumnosEntrevistados()
		{
			return Context.Respuesta
				.Select(r => r.NumControlAlumno)
				.Distinct()
				.Count();
		}
		public List<EncuestaConTotalRespuestasDTO> GetEncuestasConTotalRespuestas()
		{
			var encuestas = Context.Encuesta
				.Select(e => new EncuestaConTotalRespuestasDTO
				{
					NombreEncuesta = e.Titulo,
					TotalRespuestas = Context.Respuesta.Count(r => r.IdEncuesta == e.Id)
				})
				.ToList();

			return encuestas;
		}

		//Preguntas
		public int GetTotalPreguntas()
		{
			return Context.Pregunta.Count();
		}
		public List<RespuestasPorPreguntasDTO> GetCantidadRespuestasPorPregunta()
		{
			var resultado = Context.Pregunta.Select(p => new RespuestasPorPreguntasDTO
			{
				IdPregunta = p.IdPregunta,
				Descripcion = p.Descripcion,
				CantidadRespuestas = p.Encuestadetalle.Count()
			})
				.ToList();
			return resultado;
		}


		//USUARIOS RESPONDIENDO:

	}
}
