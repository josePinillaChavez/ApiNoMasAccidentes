using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.DAL
{
	public interface IaccidenteRepository
	{
		 void CrearAccidente(int IN_ID_DETALLE_CONTRATO, string IN_DETALLE_ACCIDENTE, DateTime IN_FECHA_ACCIDENTE, int IN_USUARIO);
		 void EliminarAccidente(int IN_ID_ACCIDENTE);
		 void ActualizarAccidente(int IN_ID_ACCIDENTE, int IN_ID_DETALLE_CONTRATO, string IN_DETALLE_ACCIDENTE, DateTime IN_FECHA_ACCIDENTE, int IN_USUARIO);
		 string ListarAccidente();
	}
}
