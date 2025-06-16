using AutoMapper;
using EncuestasAPI.Models.DTOs;
using EncuestasAPI.Models.Entities;

namespace EncuestasAPI.Helpers
{
	public class AutomapperProfile:Profile
	{
		public AutomapperProfile()
		{
			CreateMap<Usuario, LoginUsuarioDTO>().ReverseMap();


			//Encuestas
			CreateMap<Encuesta, EncuestaDTO>();
			CreateMap<CrearEncuestaDTO, Encuesta>();
			CreateMap<CrearPreguntaDto, Pregunta>();

			//Preguntas
			CreateMap<Pregunta, PreguntaDTO>();
			CreateMap<Pregunta, PreguntasDTO>();


			//Respuestas
			CreateMap<Respuesta, RespuestaDTO>();
			CreateMap<RespuestaDTO, Respuesta>();
			CreateMap<AplicarEncuestaDTO, Respuesta>();
			CreateMap<RespuestaPreguntaDto, Encuestadetalle>();

			//Detallerespuestas
			CreateMap<Encuestadetalle, RespuestaDetalleDTO>();
		}
	}
}
