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
    public class ClienteController : ControllerBase
    {
        // GET: api/Cliente
        [HttpGet]
        public string  Get()
        {

			EmpresaModel empresa = new EmpresaModel();
			
	
			return empresa.ListarEmpresa();
		}

        // GET: api/Cliente/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }




		//// POST: api/Cliente
		////CrearCliente
		//[HttpPost]
		//public void Post(Prueba prueba)
		//{
		//	EmpresaModel empresa = new EmpresaModel();
		//	empresa.EliminarEmpresa(prueba.id_empresa);

		//}






		// PUT: api/Cliente/5
		[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
