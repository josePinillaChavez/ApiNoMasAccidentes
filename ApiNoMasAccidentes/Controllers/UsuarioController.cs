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
    public class UsuarioController : ControllerBase
    {



        // GET: api/Usuario
        [HttpGet("listar")]
        public string listar()
        {
            UsuarioModel usuario = new UsuarioModel();
            return usuario.ListarUsuario();
        }


        // POST: api/Usuario
        //CrearUsuario
        [HttpPost("crear")]
        public void crear([FromBody] UsuarioCrearRequest usuarioRequest)
        {
            UsuarioModel usuario = new UsuarioModel();
            usuario.CrearUsuario(usuarioRequest.idPerfil, usuarioRequest.usuario, usuarioRequest.contrasena, usuarioRequest.estado, usuarioRequest.rutUsuario, usuarioRequest.dvRut);
        }

        // POST: api/Usuario
        //CrearUsuario
        [HttpPost("actualizar")]
        public void actualizar([FromBody] UsuarioActualizarRequest usuarioRequest)
        {
            UsuarioModel usuario = new UsuarioModel();
            usuario.ActualizarUsuario(usuarioRequest.idUsuario, usuarioRequest.usuario, usuarioRequest.contrasena, usuarioRequest.rutUsuario, usuarioRequest.dvRut);

        }


        // POST: api/Usuario
        //CrearUsuario
        [HttpPost("eliminar")]
        public void eliminar([FromBody] UsuarioEliminarRequest usuarioRequest)
        {
            UsuarioModel usuario = new UsuarioModel();
            usuario.EliminarUsuario(usuarioRequest.idUsuario);
        }

    }
}