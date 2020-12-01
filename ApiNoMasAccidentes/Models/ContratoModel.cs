using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
	public class ContratoModel
	{
		public int id_contrato { get; set; }
		public DateTime fecha_contrato { get; set; }
		public DateTime fecha_termino { get; set; }
		public string activo { get; set; }

	}
}
