using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
	public class VisitaResponse
	{

		public int id_visita { get; set; }
		public DateTime fecha_inicio { get; set; }
		public DateTime fecha_termino { get; set; }
		public string nombre { get; set; }
		public string nombreProfesional { get; set; }
		public string resuelto { get; set; }

	}

	public class VisitaCreate
	{

		public int IN_ID_DETALLE_CONTRATO { get; set; }
		public DateTime IN_FECHA_INICIO { get; set; }
		public DateTime IN_FECHA_TERMINMO { get; set; }
		public int IN_USUARIO { get; set; }


	}
	public class VisitaUpdate
	{
		public int IN_ID_VISITA { get; set; }
		public int IN_ID_DETALLE_CONTRATO { get; set; }
		public DateTime IN_FECHA_INICIO { get; set; }
		public DateTime IN_FECHA_TERMINO { get; set; }
		public int IN_USUARIO { get; set; }
		public string IN_RESUELTO { get; set; }


	}

	public class VisitaEliminar
	{
		public int IN_ID_VISITA { get; set; }
	}
}
