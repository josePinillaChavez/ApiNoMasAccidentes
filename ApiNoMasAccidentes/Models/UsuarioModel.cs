using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
    public class UsuarioModel
    {

        public void CrearUsuario(int idPerfil, string usuario, string contrasena, string estado, string rutUsuario, string dvRut)
        {




            DataSet dti = new DataSet();

            try
            {
                using (OracleConnection conn = new OracleConnection("DATA SOURCE=localhost:1521;PASSWORD=DUOCNMA;USER ID=DUOCNMA;"))
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.InitialLONGFetchSize = 1000;
                    cmd.CommandText = "SP_CREAR_USUARIO";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("IN_ID_PERFIL", OracleDbType.Int32).Value = idPerfil;
                    cmd.Parameters.Add("IN_USUARIO", OracleDbType.NVarchar2).Value = usuario;
                    cmd.Parameters.Add("IN_CONTRASENA", OracleDbType.NVarchar2).Value = contrasena;
                    cmd.Parameters.Add("IN_ESTADO", OracleDbType.Char).Value = estado;
                    cmd.Parameters.Add("IN_RUT_USUARIO", OracleDbType.NVarchar2).Value = rutUsuario;
                    cmd.Parameters.Add("IN_DV_RUT", OracleDbType.NVarchar2).Value = dvRut;
                    cmd.Parameters.Add("OUT_ESTADO", OracleDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("OUT_ID_SALIDA", OracleDbType.Int32).Direction = ParameterDirection.Output;

                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    var a = dt;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void EliminarUsuario(int idUsuario)
        {

            DataSet dti = new DataSet();

            try
            {
                using (OracleConnection conn = new OracleConnection("DATA SOURCE=localhost:1521;PASSWORD=DUOCNMA;USER ID=DUOCNMA;"))
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.InitialLONGFetchSize = 1000;
                    cmd.CommandText = "SP_DEL_USUARIO";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("IN_ID_USUARIO", OracleDbType.Int32).Value = idUsuario;
                    cmd.Parameters.Add("OUT_ESTADO", OracleDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("OUT_ID_SALIDA", OracleDbType.Int32).Direction = ParameterDirection.Output;

                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    var a = dt;
                }
            }
            catch (Exception ex)
            {

            }
        }




        public void ActualizarUsuario(int idUsuario, string usuario, string contrasena, string rutUsuario, string dvRut)
        {

            DataSet dti = new DataSet();

            try
            {
                using (OracleConnection conn = new OracleConnection("DATA SOURCE=localhost:1521;PASSWORD=DUOCNMA;USER ID=DUOCNMA;"))
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.InitialLONGFetchSize = 1000;
                    cmd.CommandText = "SP_UPDATE_USUARIO";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("IN_ID_USUARIO", OracleDbType.Int32).Value = idUsuario;
                    cmd.Parameters.Add("IN_USUARIO", OracleDbType.NVarchar2).Value = usuario;
                    cmd.Parameters.Add("IN_CONTRASENA", OracleDbType.Varchar2).Value = contrasena;
                    cmd.Parameters.Add("IN_RUT_USUARIO", OracleDbType.NVarchar2).Value = rutUsuario;
                    cmd.Parameters.Add("IN_DV_RUT", OracleDbType.NVarchar2).Value = dvRut;
                    cmd.Parameters.Add("OUT_ESTADO", OracleDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("OUT_ID_SALIDA", OracleDbType.Int32).Direction = ParameterDirection.Output;


                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    var a = dt;
                }
            }
            catch (Exception ex)
            {

            }
        }



        public string ListarUsuario()
        {
            DataSet dti = new DataSet();
            string JSONString = string.Empty;

            List<UsuarioResponse> usuariolist = new List<UsuarioResponse>();

            try
            {
                using (OracleConnection conn = new OracleConnection("DATA SOURCE=localhost:1521;PASSWORD=DUOCNMA;USER ID=DUOCNMA;"))
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.InitialLONGFetchSize = 1000;
                    cmd.CommandText = "DUOCNMA.SP_LISTAR_USUARIO";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("T_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        UsuarioResponse usuario = new UsuarioResponse();
                        usuario.idUsuario = int.Parse(row["ID_USUARIO"].ToString());
                        usuario.descripcion = row["descripcion"].ToString();
                        usuario.usuario = row["USUARIO"].ToString();
                        usuario.contrasena = row["CONTRASENA"].ToString();
                        usuario.estado = row["ESTADO"].ToString();
                        usuario.rutUsuario = row["RUT_USUARIO"].ToString();
                        usuario.dvRut = row["DV_RUT"].ToString();

                        usuariolist.Add(usuario);
                    }

                    JSONString = JsonConvert.SerializeObject(usuariolist);



                }
            }
            catch (Exception ex)
            {

            }
            return (JSONString);
        }
    }
}
