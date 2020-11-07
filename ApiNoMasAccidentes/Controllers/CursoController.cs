using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNoMasAccidentes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNoMasAccidentes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {



		// GET: api/Curso
		[HttpGet("listar")]
		public string listar()
		{
			CursoModel Curso = new CursoModel();
			return Curso.ListarCurso();
		}


		// POST: api/Curso
		[HttpPost("crear")]
		public void crear([FromBody] CursoCrearRequest cursoRequest)
		{
			CursoModel empresa = new CursoModel();
			empresa.CrearCurso(cursoRequest.IN_ID_CONTRATO, cursoRequest.IN_NOMBRE_CURSO,
				cursoRequest.IN_FECHA_INICIO, cursoRequest.IN_FECHA_TERMINMO, cursoRequest.IN_MATERIALES, cursoRequest.IN_USUARIO);
		}

		// POST: api/Curso
		[HttpPost("actualizar")]
		public void actualizar([FromBody] CursoActualizarRequest cursoRequest)
		{
			CursoModel empresa = new CursoModel();
			empresa.ActualizarCurso(cursoRequest.IN_ID_CURSO, cursoRequest.IN_ID_DETALLE_CONTRATO, cursoRequest.IN_NOMBRE_CURSO, cursoRequest.IN_FECHA_INICIO,
				cursoRequest.IN_FECHA_TERMINMO, cursoRequest.IN_MATERIALES, cursoRequest.IN_USUARIO);


		}


		// POST: api/Curso
		[HttpPost("eliminar")]
		public void eliminar([FromBody] CursoEliminarRequest cursoRequest)
		{
			CursoModel empresa = new CursoModel();
			empresa.EliminarCurso(cursoRequest.IN_ID_CURSO);
		}
	}
}