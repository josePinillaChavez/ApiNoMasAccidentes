using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
	public class CursoModel
	{
		public int id_curso { get; set; }
		public int id_contrato { get; set; }
		public string nombre_curso { get; set; }
		public DateTime fecha_inicio { get; set; }
		public DateTime fecha_termino { get; set; }
		public string materiales { get; set; }
		public int usuario { get; set; }
		public string resuelto { get; set; }
		

	}
}
