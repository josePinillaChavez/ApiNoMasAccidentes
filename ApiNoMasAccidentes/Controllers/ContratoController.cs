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
    public class ContratoController : ControllerBase
    {

		// POST: api/Contrato
		//Crearempresa
		[HttpPost("crear")]
		public void crearContrato([FromBody] ContratoCrearRequest contratoRequest)
		{
			ContratoModel contrato = new ContratoModel();
			contrato.CrearContrato(contratoRequest.idEmpresa, contratoRequest.idProfesional);
		}

		// POST: api/Contrato
		//eliminarContrato
		[HttpPost("eliminar")]
		public void eliminaContrato([FromBody] ContratoEliminarRequest contratoRequest)
		{
			ContratoModel contrato = new ContratoModel();
			contrato.EliminarContrato(contratoRequest.idContrato);
		}


		// GET: api/Empresa
		[HttpGet("listar")]
		public string listar()
		{
			ContratoModel contrato = new ContratoModel();
			return contrato.ListarContrato();
		}



	}
}