using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.DAL
{
	public interface IvisitaRepository
	{

		 void CrearVisita(int IN_ID_DETALLE_CONTRATO, DateTime IN_FECHA_INICIO, DateTime IN_FECHA_TERMINMO, int IN_USUARIO);
		 void EliminarVisita(int IN_ID_VISITA);
		 void ActualizarVisita(int IN_ID_VISITA, int IN_ID_DETALLE_CONTRATO, DateTime IN_FECHA_INICIO, DateTime IN_FECHA_TERMINO, int IN_USUARIO, string IN_RESUELTO);
		 string ListarVisita();
	}
}
