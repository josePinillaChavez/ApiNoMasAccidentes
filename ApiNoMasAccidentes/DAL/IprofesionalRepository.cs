using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.DAL
{
	public interface  IprofesionalRepository
	{

		void CrearProfesional(string nombre, string apellidoPaterno, string apellidoMaterno, string rut, string dvRut, int telefono, string email, string vigente);
		void EliminarProfesional(int idProfesional);
		void ActualizarProfesional(int idProfesional, string nombre, string apellidoPaterno, string apellidoMaterno, string rut, string dvRut, int telefono, string email);
		 string ListarProfesional();
	}
}
