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
    public class VisitaController : ControllerBase
    {

		// GET: api/Profesional
		[HttpGet("listar")]
		public string listar()
		{
			VisitaModel visita = new VisitaModel();
			return visita.ListarVisita();
		}


		// POST: api/Profesional
		//CrearProfesional
		[HttpPost("crear")]
		public void crear([FromBody] VisitaCreate visitalRequest)
		{
			VisitaModel visita = new VisitaModel();
			visita.CrearVisita(visitalRequest.IN_ID_DETALLE_CONTRATO, visitalRequest.IN_FECHA_INICIO, visitalRequest.IN_FECHA_TERMINMO, visitalRequest.IN_USUARIO);
		}

		// POST: api/Profesional
		//ActualizarProfesional
		[HttpPost("actualizar")]
		public void actualizar([FromBody] VisitaUpdate visitalRequest)
		{
			VisitaModel visita = new VisitaModel();
			visita.ActualizarVisita(visitalRequest.IN_ID_VISITA, visitalRequest.IN_ID_DETALLE_CONTRATO, visitalRequest.IN_FECHA_INICIO, visitalRequest.IN_FECHA_TERMINO, visitalRequest.IN_USUARIO, visitalRequest.IN_RESUELTO);


		}


		// POST: api/Profesional
		//EliminarProfesional
		[HttpPost("eliminar")]
		public void eliminar([FromBody] VisitaEliminar visitalRequest)
		{
			VisitaModel visita = new VisitaModel();
			visita.EliminarVisita(visitalRequest.IN_ID_VISITA);

		}
	}
}