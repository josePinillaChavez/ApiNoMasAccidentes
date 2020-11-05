using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
	public class CursoResponse
	{

		public int id_curso { get; set; }
		public string nombre_curso { get; set; }
		public DateTime fecha_inicio { get; set; }
		public DateTime fecha_terminmo { get; set; }
		public string nombre { get; set; }
		public string nombreProfesional { get; set; }
		public string resuelto { get; set; }

	
	}

	public class CursoCrearRequest
	{
		
		public int IN_ID_DETALLE_CONTRATO { get; set; }
		public string IN_NOMBRE_CURSO { get; set; }
		public DateTime IN_FECHA_INICIO { get; set; }
		public DateTime IN_FECHA_TERMINMO { get; set; }
		public string IN_MATERIALES { get; set; }
		public int IN_USUARIO { get; set; }

	}


	public class CursoActualizarRequest
	{
		public int IN_ID_CURSO { get; set; }
		public int IN_ID_DETALLE_CONTRATO { get; set; }
		public string IN_NOMBRE_CURSO { get; set; }
		public DateTime IN_FECHA_INICIO { get; set; }
		public DateTime IN_FECHA_TERMINMO { get; set; }
		public string IN_MATERIALES { get; set; }
		public int IN_USUARIO { get; set; }


	}


	public class CursoEliminarRequest
	{

		public int IN_ID_CURSO { get; set; }
	}
}
