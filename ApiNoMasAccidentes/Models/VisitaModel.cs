using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
	public class VisitaModel
	{
		public int id_visita { get; set; }
		public int id_contrato { get; set; }
		public DateTime fecha_inicio { get; set; }
		public DateTime fecha_termino { get; set; }
		public int usuario { get; set; }
		public string resuelto { get; set; }
		public string nombre_visita { get; set; }



	}
}
