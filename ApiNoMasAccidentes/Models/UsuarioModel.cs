using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
    public class UsuarioModel
    {
		public int id_usuario { get; set; }
		public int id_perfil { get; set; }
		public string usuario { get; set; }
		public string contrasena { get; set; }
		public string estado { get; set; }
		public string rut_usuario { get; set; }
		public string dv_rut { get; set; }


	}
}
