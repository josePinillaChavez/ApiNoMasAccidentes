using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
	public class ContratoResponse
	{

		public int id_contrato { get; set; }
		public DateTime fecha_contrato { get; set; }
		public DateTime fecha_termino { get; set; }
		public string activo { get; set; }
		public string nombre { get; set; }
		public string nombreProfesional { get; set; }


	}

	public class ContratoCrearRequest
	{

		public int idEmpresa { get; set; }
		public int idProfesional { get; set; }
	}

	public class ContratoEliminarRequest
	{

		public int idContrato{ get; set; }

	}





}
