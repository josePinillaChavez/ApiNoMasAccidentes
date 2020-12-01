using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
	public class AccidenteModel
	{
		public int id_acciente { get; set; }
		public int id_contrato { get; set; }
		public string detalle_accidente { get; set; }
		public DateTime fecha_accidente { get; set; }
		public int usuario { get; set; }



	}
}
