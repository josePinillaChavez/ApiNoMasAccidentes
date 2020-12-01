using ApiNoMasAccidentes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.DAL
{
	public interface IusuarioRepository
	{
		 void CrearUsuario(int idPerfil, string usuario, string contrasena, string estado, string rutUsuario, string dvRut);
		 void EliminarUsuario(int idUsuario);
		 void ActualizarUsuario(int idUsuario, string usuario, string contrasena, string rutUsuario, string dvRut);
		 string ListarUsuario();
		 UsuarioModel Autenticar(string usuario, string contrasena, int perfi);
	}
}
