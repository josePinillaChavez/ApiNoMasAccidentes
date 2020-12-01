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
    public class AccidenteController : ControllerBase
    {


		// GET: api/Profesional
		[HttpGet("listar")]
		public string listar()
		{
			IaccidenteRepository accidente = new AccidenteRepository();
			return accidente.ListarAccidente();
		}


		// POST: api/Profesional
		//CrearProfesional
		[HttpPost("crear")]
		public void Crear([FromBody] AccidenteModel request)
		{
			IaccidenteRepository accidente = new AccidenteRepository();
			accidente.CrearAccidente(request.id_contrato, request.detalle_accidente, request.fecha_accidente, request.usuario);
		}

		// POST: api/Profesional
		//ActualizarProfesional
		[HttpPost("actualizar")]
		public void Actualizar([FromBody] AccidenteModel request)
		{
			IaccidenteRepository accidente = new AccidenteRepository();
			accidente.ActualizarAccidente(request.id_acciente, request.id_contrato, request.detalle_accidente, request.fecha_accidente, request.usuario);
		}


		// POST: api/Profesional
		//EliminarProfesional
		[HttpPost("eliminar")]
		public void Eliminar([FromBody] AccidenteModel request)
		{
			IaccidenteRepository accidente = new AccidenteRepository();
			accidente.EliminarAccidente(request.id_acciente);

		}
	}
}