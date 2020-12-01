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
	public class VisitaController : ControllerBase
    {

		// GET: api/Profesional
		[HttpGet("listar")]
		public string Listar()
		{
			IvisitaRepository visita = new VisitaRepository();
			return visita.ListarVisita();
		}


		// POST: api/Profesional
		//CrearProfesional
		[HttpPost("crear")]
		public void Crear([FromBody] VisitaModel request)
		{
			IvisitaRepository visita = new VisitaRepository();
			visita.CrearVisita(request.id_contrato, request.fecha_inicio, request.fecha_termino, request.usuario);
		}

		// POST: api/Profesional
		//ActualizarProfesional
		[HttpPost("actualizar")]
		public void actualizar([FromBody] VisitaModel request)
		{
			IvisitaRepository visita = new VisitaRepository();
			visita.ActualizarVisita(request.id_visita, request.id_contrato, request.fecha_inicio, request.fecha_termino, request.usuario, request.resuelto);


		}


		// POST: api/Profesional
		//EliminarProfesional
		[HttpPost("eliminar")]
		public void eliminar([FromBody] VisitaModel request)
		{
			IvisitaRepository visita = new VisitaRepository();
			visita.EliminarVisita(request.id_visita);

		}
	}
}