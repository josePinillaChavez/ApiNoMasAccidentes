using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.DAL
{
	public interface IcursoRepository
	{
		 void CrearCurso(int IN_ID_CONTRATO, string IN_NOMBRE_CURSO, DateTime IN_FECHA_INICIO, DateTime IN_FECHA_TERMINMO, string IN_MATERIALES, int IN_USUARIO);
		 void EliminarCurso(int IN_ID_CURSO);
		 void ActualizarCurso(int IN_ID_CURSO, int IN_ID_DETALLE_CONTRATO, string IN_NOMBRE_CURSO, DateTime IN_FECHA_INICIO, DateTime IN_FECHA_TERMINMO,string IN_MATERIALES, int IN_USUARIO);
		 string ListarCurso();
	}
}
