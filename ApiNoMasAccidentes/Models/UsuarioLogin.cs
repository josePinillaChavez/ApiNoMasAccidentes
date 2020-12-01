using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
	public class UsuarioLogin
	{
		public string Usuario { get; set; }
		public string Password { get; set; }
		public int Perfil { get; set; }
	}
}
