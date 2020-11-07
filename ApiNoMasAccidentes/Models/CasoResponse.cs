using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
	public class CasoResponse
	{
		public int ID_CASO { get; set; }
		public int ID_CONTRATO { get; set; }
		public string descripcion { get; set; }
		public string nombre { get; set; }
		public DateTime fecha_caso { get; set; }
		public string resuelto { get; set; }

	}





		public class CasoCreate
	    {
    
    	public int IN_ID_CONTRATO { get; set; }
    	public int IN_ID_TIPO_CASO { get; set; }
    	public DateTime IN_FECHA_CASO { get; set; }
    	public string IN_RESUELTO { get; set; }
    
        }
    



	public class CasoUpdate
	{
    	public int IN_ID_CASO { get; set; }
    	public int IN_ID_CONTRATO { get; set; }
    	public int IN_ID_TIPO_CASO { get; set; }
    	public  string IN_RESUELTO { get; set; }
    	public DateTime IN_FECHA_CASO { get; set; }
    
    }


	public class CasoEliminar
	{
		public int IN_ID_CASO { get; set; }
    }
}
