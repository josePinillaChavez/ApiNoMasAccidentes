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
	public class EmpresaController : ControllerBase
    {
		// GET: api/Empresa
		[HttpGet("listar")]
		public string Listar()
		{
			IempresaRepository empresa = new EmpresaRepository();
			return empresa.ListarEmpresa();
		}


		// POST: api/Empresa
		//Crearempresa
		[HttpPost("crear")]
		public void Crear([FromBody] EmpresaModel reqest)
		{
			IempresaRepository empresa = new EmpresaRepository();
			empresa.CrearEmpresa(reqest.id_rubro, reqest.rut, reqest.dv_rut, reqest.nombre, reqest.telefono, reqest.email);
		}

		// POST: api/Empresa
		//Crearempresa
		[HttpPost("actualizar")]
		public void Actualizar([FromBody] EmpresaModel reqest)
		{
			IempresaRepository empresa = new EmpresaRepository();
			empresa.ActualizarEmpresa(reqest.id_empresa,reqest.id_rubro, reqest.rut, reqest.dv_rut, reqest.nombre, reqest.telefono, reqest.email);


		}


		// POST: api/Cliente
		//CrearCliente
		[HttpPost("eliminar")]
		public void Eliminar([FromBody] EmpresaModel reqest)
		{
			IempresaRepository empresa = new EmpresaRepository();
			empresa.EliminarEmpresa(reqest.id_empresa);
		}





	}
}