using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
	public class DocTributarioModel
	{

		public int id_doc_tributario { get; set; }
		public int id_contrato { get; set; }
		public int valor { get; set; }
		public string detalle { get; set; }
		public string pagado { get; set; }
		public DateTime fecha_vencimiento { get; set; }


	}
}
