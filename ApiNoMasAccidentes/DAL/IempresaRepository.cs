using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.DAL
{
	interface IempresaRepository
	{
		void CrearEmpresa(int idRubro, string rut, string dv, string nombre, int telefono, string email);

		void EliminarEmpresa(int ID_EMPRESA);

		void ActualizarEmpresa(int idempresa, int idRubro, string rut, string dv, string nombre, int telefono, string email);

		string ListarEmpresa();

	}
}
