using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
    public class ProfesionalResponse
    {


            public int idProfesional { get; set; }
            public string nombre { get; set; }
            public string apellidoPaterno { get; set; }
            public string apellidoMaterno { get; set; }
            public string rut { get; set; }
            public string dvRu { get; set; }
            public int telefono { get; set; }
            public string email { get; set; }
            public string vigente { get; set; }

        }

        public class ProfesionalCrearRequest
        {

            public string nombre { get; set; }
            public string apellidoPaterno { get; set; }
            public string apellidoMaterno { get; set; }
            public string rut { get; set; }
            public string dvRut { get; set; }
            public int telefono { get; set; }
            public string email { get; set; }
            public string vigente { get; set; }

        }


        public class ProfesionalActualizarRequest
        {

            public int idProfesional { get; set; }
            public string nombre { get; set; }
            public string apellidoPaterno { get; set; }
            public string apellidoMaterno { get; set; }
            public string rut { get; set; }
            public string dvRut { get; set; }
            public int telefono { get; set; }
            public string email { get; set; }

        }


        public class ProfesionalEliminarRequest
        {

            public int idProfesional { get; set; }
        }
    }

