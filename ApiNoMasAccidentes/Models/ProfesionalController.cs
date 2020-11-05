using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNoMasAccidentes.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesionalController : ControllerBase
    {

        // GET: api/Profesional
        [HttpGet("listar")]
        public string listar()
        {
            ProfesionalModel profesional = new ProfesionalModel();
            return profesional.ListarProfesional();
        }


        // POST: api/Profesional
        //CrearProfesional
        [HttpPost("crear")]
        public void crear([FromBody] ProfesionalCrearRequest profesionalRequest)
        {
            ProfesionalModel profesional = new ProfesionalModel();
            profesional.CrearProfesional(profesionalRequest.nombre, profesionalRequest.apellidoPaterno, profesionalRequest.apellidoMaterno, profesionalRequest.rut, profesionalRequest.dvRut, profesionalRequest.telefono, profesionalRequest.email, profesionalRequest.vigente);
        }

        // POST: api/Profesional
        //ActualizarProfesional
        [HttpPost("actualizar")]
        public void actualizar([FromBody] ProfesionalActualizarRequest profesionalRequest)
        {
            ProfesionalModel profesional = new ProfesionalModel();
            profesional.ActualizarProfesional(profesionalRequest.idProfesional, profesionalRequest.nombre, profesionalRequest.apellidoPaterno, profesionalRequest.apellidoMaterno, profesionalRequest.rut, profesionalRequest.dvRut, profesionalRequest.telefono, profesionalRequest.email);


        }


        // POST: api/Profesional
        //EliminarProfesional
        [HttpPost("eliminar")]
        public void eliminar([FromBody] ProfesionalEliminarRequest profesionalRequest)
        {
            ProfesionalModel profesional = new ProfesionalModel();
            profesional.EliminarProfesional(profesionalRequest.idProfesional);

        }
    }
}