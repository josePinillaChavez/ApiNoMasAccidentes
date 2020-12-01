using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
	public class CasoModel
	{
		public int id_caso { get; set; }
		public int id_contrato { get; set; }
		public int id_tipo_caso { get; set; }
		public string resuelto { get; set; }
		public DateTime fecha_caso { get; set; }



	}
}
