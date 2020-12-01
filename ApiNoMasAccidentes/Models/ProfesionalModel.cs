using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
    public class ProfesionalModel
    {
		public int id_profesional { get; set; }
		public string nombre { get; set; }
		public string apellido_paterno { get; set; }
		public string apellido_materno { get; set; }
		public string rut { get; set; }
		public string dv_rut { get; set; }
		public int telefono { get; set; }
		public string email { get; set; }
		public string vigente { get; set; }

	}
}
