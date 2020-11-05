using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
	public class DocTributarioResponse
	{

		public int id_doc_tributarios { get; set; }
		public int id_contrato { get; set; }
		public string detalle { get; set; }
		public string pagado { get; set; }
		public DateTime fecha_vencimiento { get; set; }
		public string nombre { get; set; }
	}


}

