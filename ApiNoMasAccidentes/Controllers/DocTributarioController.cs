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
    public class DocTributarioController : ControllerBase
    {

		// GET: api/DocTributario
		[HttpGet("listar")]
		public string listar()
		{
			DocTributarioModel docTributario = new DocTributarioModel();
			return docTributario.ListarContrato();
		}
	}
}