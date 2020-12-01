using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.DAL
{
	public interface IcasoRepository
	{
		 void CrearCaso(int IN_ID_CONTRATO, int IN_ID_TIPO_CASO, DateTime IN_FECHA_CASO, string IN_RESUELTO);
		 void EliminarCaso(int IN_ID_CASO);
		 void ActualizarCaso(int IN_ID_CASO, int IN_ID_CONTRATO, int IN_ID_TIPO_CASO, string IN_RESUELTO, DateTime IN_FECHA_CASO);
		 string ListarCaso();
	}
}
