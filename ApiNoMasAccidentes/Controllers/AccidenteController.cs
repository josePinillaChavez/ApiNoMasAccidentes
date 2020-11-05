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
    public class AccidenteController : ControllerBase
    {


		// GET: api/Profesional
		[HttpGet("listar")]
		public string listar()
		{
			AccidenteModel accidente = new AccidenteModel();
			return accidente.ListarAccidente();
		}


		// POST: api/Profesional
		//CrearProfesional
		[HttpPost("crear")]
		public void crear([FromBody] AccidenteCreate accidentelRequest)
		{
			AccidenteModel accidente = new AccidenteModel();
			accidente.CrearAccidente(accidentelRequest.IN_ID_DETALLE_CONTRATO, accidentelRequest.IN_DETALLE_ACCIDENTE, accidentelRequest.IN_FECHA_ACCIDENTE, accidentelRequest.IN_USUARIO);
		}

		// POST: api/Profesional
		//ActualizarProfesional
		[HttpPost("actualizar")]
		public void actualizar([FromBody] AccidenteUpdate accidentelRequest)
		{
			AccidenteModel accidente = new AccidenteModel();
			accidente.ActualizarAccidente(accidentelRequest.IN_ID_ACCIDENTE, accidentelRequest.IN_ID_DETALLE_CONTRATO, accidentelRequest.IN_DETALLE_ACCIDENTE, accidentelRequest.IN_FECHA_ACCIDENTE, accidentelRequest.IN_USUARIO);


		}


		// POST: api/Profesional
		//EliminarProfesional
		[HttpPost("eliminar")]
		public void eliminar([FromBody] AccidenteEliminar accidentelRequest)
		{
			AccidenteModel accidente = new AccidenteModel();
			accidente.EliminarAccidente(accidentelRequest.IN_ID_ACCIDENTE);

		}
	}
}