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
	public class ProfesionalController : ControllerBase
    {


		// GET: api/Profesional
		[HttpGet("listar")]

		public string Listar()
		{
			IprofesionalRepository profesional = new ProfesionalRepository();
			return profesional.ListarProfesional();
		}

		[HttpPost("crear")]
		public void Crear([FromBody] ProfesionalModel request)
		{
			IprofesionalRepository profesional = new ProfesionalRepository();
			profesional.CrearProfesional(request.nombre, request.apellido_paterno, request.apellido_materno, request.rut, request.dv_rut, request.telefono, request.email, request.vigente);				
		}
		// POST: api/Profesional
		//ActualizarProfesional
		[HttpPost("actualizar")]
		public void Actualizar([FromBody] ProfesionalModel request)
		{
			IprofesionalRepository profesional = new ProfesionalRepository();
			profesional.ActualizarProfesional(request.id_profesional, request.nombre, request.apellido_paterno, request.apellido_materno, request.rut, request.dv_rut, request.telefono, request.email);


		}


		// POST: api/Profesional
		//EliminarProfesional
		[HttpPost("eliminar")]
		public void Eliminar([FromBody] ProfesionalModel request)
		{
			IprofesionalRepository profesional = new ProfesionalRepository();
			profesional.EliminarProfesional(request.id_profesional);

		}
	}
}