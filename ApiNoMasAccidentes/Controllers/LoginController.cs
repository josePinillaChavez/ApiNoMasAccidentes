using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiNoMasAccidentes.DAL;
using ApiNoMasAccidentes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ApiNoMasAccidentes.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class LoginController : ControllerBase
	{


		private readonly IConfiguration configuration;

		// TRAEMOS EL OBJETO DE CONFIGURACIÓN (appsettings.json)
		// MEDIANTE INYECCIÓN DE DEPENDENCIAS.
		public LoginController(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		// POST: api/Login
		[HttpPost("login")]
		[AllowAnonymous]
		public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
		{
			var _userInfo = await AutenticarUsuarioAsync(usuarioLogin.Usuario, usuarioLogin.Password,usuarioLogin.Perfil);
			if (_userInfo != null)
			{
				return Ok(new { token = GenerarTokenJWT(_userInfo) });
			}
			else
			{
				return Unauthorized();
			}
		}

		// COMPROBAMOS SI EL USUARIO EXISTE EN LA BASE DE DATOS 
		private async Task<UsuarioModel> AutenticarUsuarioAsync(string usuario, string password,int perfil)
		{
			// AQUÍ LA LÓGICA DE AUTENTICACIÓN //

			IusuarioRepository usuarioRepo = new UsuarioRepository();
			UsuarioModel usuarioModel = new UsuarioModel();

			usuarioModel = usuarioRepo.Autenticar(usuario, password, perfil);

			// Supondremos que el Usuario existe en la Base de Datos.
			// Retornamos un objeto del tipo UsuarioInfo, con toda
			// la información del usuario necesaria para el Token.
			return new UsuarioModel()
			{
				// Id del Usuario en el Sistema de Información (BD)
				id_usuario = 1,
				usuario = usuarioModel.usuario,
				id_perfil = usuarioModel.id_perfil
			};

			// Supondremos que el Usuario NO existe en la Base de Datos.
			// Retornamos NULL.
			//return null;
		}

		// GENERAMOS EL TOKEN CON LA INFORMACIÓN DEL USUARIO
		private string GenerarTokenJWT(UsuarioModel usuarioInfo)
		{



			// CREAMOS EL HEADER //
			var _symmetricSecurityKey = new SymmetricSecurityKey(
					Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"])
				);
			var _signingCredentials = new SigningCredentials(
					_symmetricSecurityKey, SecurityAlgorithms.HmacSha256
				);
			var _Header = new JwtHeader(_signingCredentials);



			// CREAMOS LOS CLAIMS //
			var _Claims = new[] {
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.NameId, usuarioInfo.id_usuario.ToString()),
				new Claim("nombre", usuarioInfo.usuario),
				//new Claim("apellidos", usuarioInfo.Apellidos),
				new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.usuario),
				new Claim(ClaimTypes.Role, usuarioInfo.id_perfil.ToString())
			};

			// CREAMOS EL PAYLOAD //
			var _Payload = new JwtPayload(
					issuer: configuration["JWT:Issuer"],
					audience: configuration["JWT:Audience"],
					claims: _Claims,
					notBefore: DateTime.UtcNow,
					// Exipra a la 24 horas.
					expires: DateTime.UtcNow.AddHours(24)
				);

			// GENERAMOS EL TOKEN //
			var _Token = new JwtSecurityToken(
					_Header,
					_Payload
				);

			return new JwtSecurityTokenHandler().WriteToken(_Token);
		}

	}
}