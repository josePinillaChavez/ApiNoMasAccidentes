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
    public class CasoController : ControllerBase
    {


		// GET: api/Profesional
		[HttpGet("listar")]
		public string listar()
		{
			CasoModel caso = new CasoModel();
			return caso.ListarCaso();
		}


		// POST: api/Profesional
		//CrearProfesional
		[HttpPost("crear")]
		public void crear([FromBody] CasoCreate request)
		{
			CasoModel caso = new CasoModel();
			caso.CrearCaso(request.IN_ID_CONTRATO, request.IN_ID_TIPO_CASO, request.IN_FECHA_CASO, request.IN_RESUELTO);
		}

		// POST: api/Profesional
		//ActualizarProfesional
		[HttpPost("actualizar")]
		public void actualizar([FromBody] CasoUpdate request)
		{
			CasoModel caso = new CasoModel();
			caso.ActualizarCaso(request.IN_ID_CASO, request.IN_ID_CONTRATO, request.IN_ID_TIPO_CASO, request.IN_RESUELTO, request.IN_FECHA_CASO);


		}


		// POST: api/Profesional
		//EliminarProfesional
		[HttpPost("eliminar")]
		public void eliminar([FromBody] CasoEliminar request)
		{
			CasoModel caso = new CasoModel();
			caso.EliminarCaso(request.IN_ID_CASO);

	   }
	}
}