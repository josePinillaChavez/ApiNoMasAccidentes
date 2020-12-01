using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.DAL
{
	public class CasoRepository : IcasoRepository
	{
		private string conexion = Startup.ConnectionString;

		public void CrearCaso(int IN_ID_CONTRATO, int IN_ID_TIPO_CASO, DateTime IN_FECHA_CASO, string IN_RESUELTO)
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
					cmd.CommandText = "SP_CREAR_CASO";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("IN_ID_CONTRATO", OracleDbType.Int32).Value = IN_ID_CONTRATO;
					cmd.Parameters.Add("IN_ID_TIPO_CASO", OracleDbType.Int32).Value = IN_ID_TIPO_CASO;
					cmd.Parameters.Add("IN_RESUELTO", OracleDbType.Char).Value = IN_RESUELTO;
					cmd.Parameters.Add("IN_FECHA_CASO", OracleDbType.Date).Value = IN_FECHA_CASO;
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

		public void EliminarCaso(int IN_ID_CASO)
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
					cmd.CommandText = "SP_DEL_CASO";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("IN_ID_CASO", OracleDbType.Int32).Value = IN_ID_CASO;
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




		public void ActualizarCaso(int IN_ID_CASO, int IN_ID_CONTRATO, int IN_ID_TIPO_CASO, string IN_RESUELTO, DateTime IN_FECHA_CASO)
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
					cmd.CommandText = "SP_UPDATE_CASO";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("IN_ID_CASO", OracleDbType.Int32).Value = IN_ID_CASO;
					cmd.Parameters.Add("IN_ID_CONTRATO", OracleDbType.Int32).Value = IN_ID_CONTRATO;
					cmd.Parameters.Add("IN_ID_TIPO_CASO", OracleDbType.Int32).Value = IN_ID_TIPO_CASO;
					cmd.Parameters.Add("IN_RESUELTO", OracleDbType.Char).Value = IN_RESUELTO;
					cmd.Parameters.Add("IN_FECHA_CASO", OracleDbType.Date).Value = IN_FECHA_CASO;
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



		public string ListarCaso()
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
					cmd.CommandText = "DUOCNMA.SP_LISTAR_CASO";
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
