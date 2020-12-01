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
	public class UsuarioController : ControllerBase
    {



        // GET: api/Usuario
        [HttpGet("listar")]
        public string Listar()
        {
            IusuarioRepository usuario = new UsuarioRepository();
            return usuario.ListarUsuario();
        }


        // POST: api/Usuario
        //CrearUsuario
        [HttpPost("crear")]
        public void Crear([FromBody] UsuarioModel request)
        {
			IusuarioRepository usuario = new UsuarioRepository();
			usuario.CrearUsuario(request.id_perfil,request.usuario,request.contrasena, request.estado, request.rut_usuario, request.dv_rut);
        }

        // POST: api/Usuario
        //CrearUsuario
        [HttpPost("actualizar")]
        public void Actualizar([FromBody] UsuarioModel request)
        {
			IusuarioRepository usuario = new UsuarioRepository();
			usuario.ActualizarUsuario(request.id_usuario, request.usuario, request.contrasena, request.rut_usuario, request.dv_rut);

        }


        // POST: api/Usuario
        //CrearUsuario
        [HttpPost("eliminar")]
        public void Eliminar([FromBody] UsuarioModel request)
        {
			IusuarioRepository usuario = new UsuarioRepository();
			usuario.EliminarUsuario(request.id_usuario);
        }

    }
}