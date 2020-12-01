using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNoMasAccidentes.DAL;
using ApiNoMasAccidentes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNoMasAccidentes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Authorize]
	public class CursoController : ControllerBase
    {



		// GET: api/Curso
		[HttpGet("listar")]
		public string listar()
		{
			IcursoRepository Curso = new CursoRepository();
			return Curso.ListarCurso();
		}


		// POST: api/Curso
		[HttpPost("crear")]
		public void Crear([FromBody] CursoModel request)
		{
			IcursoRepository Curso = new CursoRepository();
			Curso.CrearCurso(request.id_contrato, request.nombre_curso, request.fecha_inicio, request.fecha_termino, request.materiales, request.usuario);
		}

		// POST: api/Curso
		[HttpPost("actualizar")]
		public void Actualizar([FromBody] CursoModel request)
		{
			IcursoRepository Curso = new CursoRepository();
			Curso.ActualizarCurso(request.id_curso, request.id_contrato, request.nombre_curso, request.fecha_inicio, request.fecha_termino, request.materiales, request.usuario);


		}


		// POST: api/Curso
		[HttpPost("eliminar")]
		public void Eliminar([FromBody] CursoModel request)
		{
			IcursoRepository Curso = new CursoRepository();
			Curso.EliminarCurso(request.id_curso);
		}
	}
}