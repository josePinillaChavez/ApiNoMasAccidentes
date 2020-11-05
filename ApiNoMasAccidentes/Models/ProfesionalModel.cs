using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
    public class ProfesionalModel
    {


        public void CrearProfesional(string nombre, string apellidoPaterno, string apellidoMaterno, string rut, string dvRut, int telefono, string email, string vigente)
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
                    cmd.CommandText = "SP_CREAR_PROFESIONAL";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("IN_NOMBRE", OracleDbType.NVarchar2).Value = nombre;
                    cmd.Parameters.Add("IN_APELLIDO_PATERNO", OracleDbType.NVarchar2).Value = apellidoPaterno;
                    cmd.Parameters.Add("IN_APELLIDO_MATERNO", OracleDbType.NVarchar2).Value = apellidoMaterno;
                    cmd.Parameters.Add("IN_RUT", OracleDbType.NVarchar2).Value = rut;
                    cmd.Parameters.Add("IN_DV_RUT", OracleDbType.NVarchar2).Value = dvRut;
                    cmd.Parameters.Add("IN_TELEFONO", OracleDbType.Int32).Value = telefono;
                    cmd.Parameters.Add("IN_EMAIL", OracleDbType.NVarchar2).Value = email;
                    cmd.Parameters.Add("IN_VIGENTE", OracleDbType.NVarchar2).Value = vigente;
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

        public void EliminarProfesional(int idProfesional)
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
                    cmd.CommandText = "SP_DEL_PROFESIONAL";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("IN_ID_PROFESIONAL", OracleDbType.Int32).Value = idProfesional;
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




        public void ActualizarProfesional(int idProfesional, string nombre, string apellidoPaterno, string apellidoMaterno, string rut, string dvRut, int telefono, string email)
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
                    cmd.CommandText = "SP_UPDATE_PROFESIONAL";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("IN_ID_PROFESIONAL", OracleDbType.Int32).Value = idProfesional;
                    cmd.Parameters.Add("IN_NOMBRE", OracleDbType.NVarchar2).Value = nombre;
                    cmd.Parameters.Add("IN_APELLIDO_PATERNO", OracleDbType.Varchar2).Value = apellidoPaterno;
                    cmd.Parameters.Add("IN_APELLIDO_MATERNO", OracleDbType.NVarchar2).Value = apellidoMaterno;
                    cmd.Parameters.Add("IN_RUT", OracleDbType.NVarchar2).Value = rut;
                    cmd.Parameters.Add("IN_DV_RUT", OracleDbType.NVarchar2).Value = dvRut;
                    cmd.Parameters.Add("IN_TELEFONO", OracleDbType.Int32).Value = telefono;
                    cmd.Parameters.Add("IN_EMAIL", OracleDbType.NVarchar2).Value = email;
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



        public string ListarProfesional()
        {
            DataSet dti = new DataSet();
            string JSONString = string.Empty;

            List<ProfesionalResponse> profesionallist = new List<ProfesionalResponse>();

            try
            {
                using (OracleConnection conn = new OracleConnection("DATA SOURCE=localhost:1521;PASSWORD=DUOCNMA;USER ID=DUOCNMA;"))
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.InitialLONGFetchSize = 1000;
                    cmd.CommandText = "DUOCNMA.SP_LISTAR_PROFESIONAL";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("T_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        ProfesionalResponse profesional = new ProfesionalResponse();
                        profesional.idProfesional = int.Parse(row["ID_PROFESIONAL"].ToString());
                        profesional.nombre = row["NOMBRE"].ToString();
                        profesional.apellidoPaterno = row["APELLIDO_PATERNO"].ToString();
                        profesional.apellidoMaterno = row["APELLIDO_MATERNO"].ToString();
                        profesional.rut = row["RUT"].ToString();
                        profesional.dvRu = row["DV_RUT"].ToString();
                        profesional.telefono = int.Parse(row["TELEFONO"].ToString());
                        profesional.email = row["EMAIL"].ToString();
                        profesional.vigente = row["VIGENTE"].ToString();


                        profesionallist.Add(profesional);
                    }

                    JSONString = JsonConvert.SerializeObject(profesionallist);



                }
            }
            catch (Exception ex)
            {

            }
            return (JSONString);
        }
    }
}
