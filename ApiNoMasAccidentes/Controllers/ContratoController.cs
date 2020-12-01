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
	public class ContratoController : ControllerBase
    {

		// POST: api/Contrato
		//Crearempresa
		[HttpPost("crear")]
		public void CrearContrato([FromBody] ContratoModel request)
		{
			IcontratoRepository contrato = new ContratoRepository();
			contrato.CrearContrato(request.id_contrato);
		}

		// POST: api/Contrato
		//eliminarContrato
		[HttpPost("eliminar")]
		public void eliminaContrato([FromBody] ContratoModel request)
		{
			IcontratoRepository contrato = new ContratoRepository();
			contrato.EliminarContrato(request.id_contrato);
		}


		// GET: api/Empresa
		[HttpGet("listar")]
		public string Listar()
		{
			IcontratoRepository contrato = new ContratoRepository();
			return contrato.ListarContrato();
		}



	}
}