using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
	public class EmpresaResponse
	{
		
		public int  id_empresa { get; set; }
	    public string rut { get; set; }
        public string dv_rut { get; set; }
		public string nombre { get; set; }
		public int telefono { get; set; }
		public string email { get; set; }
		public string vigente { get; set; }
		public string descripcion { get; set; }
	}

	public class EmpresaCreate
	{

		public int idRubro { get; set; }
		public string rut { get; set; }
		public string dv_rut { get; set; }
		public string nombre { get; set; }
		public int telefono { get; set; }
		public string email { get; set; }

	}
	public class EmpresaUpdate
	{
		public int idEmpresa { get; set; }
		public int idRubro { get; set; }
		public string rut { get; set; }
		public string dv_rut { get; set; }
		public string nombre { get; set; }
		public int telefono { get; set; }
		public string email { get; set; }

	}

	public class EmpresaEliminar
	{
		public int idEmpresa { get; set; }
	}


}
