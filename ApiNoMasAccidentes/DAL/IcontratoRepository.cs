using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.DAL
{
	interface IcontratoRepository
	{
		 void CrearContrato(int idEmpresa);
		 void EliminarContrato(int idContrato);
		 string ListarContrato();
	}
}
