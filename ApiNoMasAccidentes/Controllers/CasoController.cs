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
	public class CasoController : ControllerBase
    {


		// GET: api/Profesional
		[HttpGet("listar")]
		public string Listar()
		{
			IcasoRepository caso = new CasoRepository();
			return caso.ListarCaso();
		}


		// POST: api/Profesional
		//CrearProfesional
		[HttpPost("crear")]
		public void Crear([FromBody] CasoModel request)
		{
			IcasoRepository caso = new CasoRepository();
			caso.CrearCaso(request.id_contrato, request.id_tipo_caso, request.fecha_caso, request.resuelto);
		}

		// POST: api/Profesional
		//ActualizarProfesional
		[HttpPost("actualizar")]
		public void Actualizar([FromBody] CasoModel request)
		{
			IcasoRepository caso = new CasoRepository();
			caso.ActualizarCaso(request.id_caso, request.id_contrato, request.id_tipo_caso, request.resuelto, request.fecha_caso);


		}


		// POST: api/Profesional
		//EliminarProfesional
		[HttpPost("eliminar")]
		public void Eliminar([FromBody] CasoModel request)
		{
			IcasoRepository caso = new CasoRepository();
			caso.EliminarCaso(request.id_caso);

	   }
	}
}