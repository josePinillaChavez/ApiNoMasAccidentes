using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
	public class AccidenteResponse
	{

		public int ID_ACCIDENTE { get; set; }
		public int id_contrato { get; set; }
		public string DETALLE_ACCIDENTE { get; set; }
		public DateTime FECHA_ACCIDENTE { get; set; }
		public int USUARIO { get; set; }


	}

	public class AccidenteCreate
	{

		public int IN_ID_DETALLE_CONTRATO { get; set; }
		public string IN_DETALLE_ACCIDENTE { get; set; }
		public DateTime IN_FECHA_ACCIDENTE { get; set; }
		public int IN_USUARIO { get; set; }

	}

	public class AccidenteUpdate
    {
		public int IN_ID_ACCIDENTE { get; set; }
		public int IN_ID_DETALLE_CONTRATO { get; set; }
		public string IN_DETALLE_ACCIDENTE { get; set; }
		public DateTime IN_FECHA_ACCIDENTE { get; set; }
		public int IN_USUARIO { get; set; }

	}

	public class AccidenteEliminar
    {
		public int IN_ID_ACCIDENTE { get; set; }
	}

}
