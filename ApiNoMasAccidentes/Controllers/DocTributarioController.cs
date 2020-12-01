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
	public class DocTributarioController : ControllerBase
    {

		// GET: api/DocTributario
		[HttpGet("listar")]
		public string Listar()
		{
			IdocTributarioRepository doctributario = new DocTributarioRepository();
			return doctributario.ListarContrato();
		}
	}
}