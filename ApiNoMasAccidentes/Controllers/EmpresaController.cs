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
    public class EmpresaController : ControllerBase
    {
		// GET: api/Empresa
		[HttpGet("listar")]
		public string listar()
		{
			EmpresaModel empresa = new EmpresaModel();
			return empresa.ListarEmpresa();
		}


		// POST: api/Empresa
		//Crearempresa
		[HttpPost("crear")]
		public void crear([FromBody] EmpresaCreate empresaRequest)
		{
			EmpresaModel empresa = new EmpresaModel();
			empresa.CrearEmpresa(empresaRequest.idRubro, empresaRequest.rut, empresaRequest.dv_rut, empresaRequest.nombre, empresaRequest.telefono, empresaRequest.email);
		}

		// POST: api/Empresa
		//Crearempresa
		[HttpPost("actualizar")]
		public void actualizar([FromBody] EmpresaUpdate empresaRequest)
		{
			EmpresaModel empresa = new EmpresaModel();
			empresa.ActualizarEmpresa(empresaRequest.idEmpresa, empresaRequest.idRubro, empresaRequest.rut,  empresaRequest.dv_rut, empresaRequest.nombre, empresaRequest.telefono, empresaRequest.email);


		}


		// POST: api/Cliente
		//CrearCliente
		[HttpPost("eliminar")]
		public void eliminar([FromBody] EmpresaEliminar empresaRequest)
		{
			EmpresaModel empresa = new EmpresaModel();
			empresa.EliminarEmpresa(empresaRequest.idEmpresa);
		}





	}
}