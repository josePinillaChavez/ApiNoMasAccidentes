using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
    public class UsuarioResponse
    {
                       
        public int idUsuario { get; set; }
        public string descripcion { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string estado { get; set; }
        public string rutUsuario { get; set; }
        public string dvRut { get; set; }
     }

    public class UsuarioCrearRequest
    {

        public int idPerfil { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string estado { get; set; }
        public string rutUsuario { get; set; }
        public string dvRut { get; set; }

    }


    public class UsuarioActualizarRequest
    {

        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string rutUsuario { get; set; }
        public string dvRut { get; set; }

    }


    public class UsuarioEliminarRequest
    {

        public int idUsuario { get; set; }
    }
}
