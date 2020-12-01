using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.DAL
{


	public class CursoRepository : IcursoRepository
	{
		private string conexion = Startup.ConnectionString;

		public void CrearCurso(int IN_ID_CONTRATO, string IN_NOMBRE_CURSO, DateTime IN_FECHA_INICIO, DateTime IN_FECHA_TERMINMO, string IN_MATERIALES, int IN_USUARIO)
		{

			DataSet dti = new DataSet();

			try
			{
				using (OracleConnection conn = new OracleConnection(conexion))
				{
					OracleDataAdapter da = new OracleDataAdapter();
					OracleCommand cmd = new OracleCommand();
					cmd.Connection = conn;
					cmd.InitialLONGFetchSize = 1000;
					cmd.CommandText = "SP_CREAR_CURSO";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("IN_ID_CONTRATO", OracleDbType.Int32).Value = IN_ID_CONTRATO;
					cmd.Parameters.Add("IN_NOMBRE_CURSO", OracleDbType.NVarchar2).Value = IN_NOMBRE_CURSO;
					cmd.Parameters.Add("IN_FECHA_INICIO", OracleDbType.Date).Value = IN_FECHA_INICIO;
					cmd.Parameters.Add("IN_FECHA_TERMINMO", OracleDbType.Date).Value = IN_FECHA_TERMINMO;
					cmd.Parameters.Add("IN_MATERIALES", OracleDbType.NVarchar2).Value = IN_MATERIALES;
					cmd.Parameters.Add("IN_USUARIO", OracleDbType.Int32).Value = IN_USUARIO;

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

		public void EliminarCurso(int IN_ID_CURSO)
		{

			DataSet dti = new DataSet();

			try
			{
				using (OracleConnection conn = new OracleConnection(conexion))
				{
					OracleDataAdapter da = new OracleDataAdapter();
					OracleCommand cmd = new OracleCommand();
					cmd.Connection = conn;
					cmd.InitialLONGFetchSize = 1000;
					cmd.CommandText = "SP_DEL_CURSO";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("IN_ID_CURSO", OracleDbType.Int32).Value = IN_ID_CURSO;
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




		public void ActualizarCurso(int IN_ID_CURSO, int IN_ID_DETALLE_CONTRATO, string IN_NOMBRE_CURSO, DateTime IN_FECHA_INICIO, DateTime IN_FECHA_TERMINMO,
			string IN_MATERIALES, int IN_USUARIO)
		{

			DataSet dti = new DataSet();

			try
			{
				using (OracleConnection conn = new OracleConnection(conexion))
				{
					OracleDataAdapter da = new OracleDataAdapter();
					OracleCommand cmd = new OracleCommand();
					cmd.Connection = conn;
					cmd.InitialLONGFetchSize = 1000;
					cmd.CommandText = "SP_UPDATE_CURSO";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("IN_ID_CURSO", OracleDbType.Int32).Value = IN_ID_CURSO;
					cmd.Parameters.Add("IN_ID_DETALLE_CONTRATO", OracleDbType.Int32).Value = IN_ID_DETALLE_CONTRATO;
					cmd.Parameters.Add("IN_NOMBRE_CURSO", OracleDbType.NVarchar2).Value = IN_NOMBRE_CURSO;
					cmd.Parameters.Add("IN_FECHA_INICIO", OracleDbType.Date).Value = IN_FECHA_INICIO;
					cmd.Parameters.Add("IN_FECHA_TERMINMO", OracleDbType.Date).Value = IN_FECHA_TERMINMO;
					cmd.Parameters.Add("IN_MATERIALES", OracleDbType.NVarchar2).Value = IN_MATERIALES;
					cmd.Parameters.Add("IN_USUARIO", OracleDbType.Int32).Value = IN_USUARIO;
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



		public string ListarCurso()
		{
			DataSet dti = new DataSet();
			string JSONString = string.Empty;

			try
			{
				using (OracleConnection conn = new OracleConnection(conexion))
				{
					OracleDataAdapter da = new OracleDataAdapter();
					OracleCommand cmd = new OracleCommand();
					cmd.Connection = conn;
					cmd.InitialLONGFetchSize = 1000;
					cmd.CommandText = "DUOCNMA.SP_LISTAR_CURSO";
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("T_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

					da.SelectCommand = cmd;
					DataTable dt = new DataTable();
					da.Fill(dt);
					JSONString = JsonConvert.SerializeObject(dt);




				}
			}
			catch (Exception ex)
			{

			}
			return (JSONString);
		}
	}
}
