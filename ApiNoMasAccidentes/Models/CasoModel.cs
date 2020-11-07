using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
	public class CasoModel
	{

		public void CrearCaso(int IN_ID_CONTRATO, int IN_ID_TIPO_CASO, DateTime IN_FECHA_CASO, string IN_RESUELTO)
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
				using (OracleConnection conn = new OracleConnection("DATA SOURCE=localhost:1521;PASSWORD=DUOCNMA;USER ID=DUOCNMA;"))
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
				using (OracleConnection conn = new OracleConnection("DATA SOURCE=localhost:1521;PASSWORD=DUOCNMA;USER ID=DUOCNMA;"))
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
					cmd.Parameters.Add("IN_FECHA_CASO", OracleDbType.Date).Value =  IN_FECHA_CASO; 
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

			List<CasoResponse> casolist = new List<CasoResponse>();

			try
			{
				using (OracleConnection conn = new OracleConnection("DATA SOURCE=localhost:1521;PASSWORD=DUOCNMA;USER ID=DUOCNMA;"))
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

					foreach (DataRow row in dt.Rows)
					{

						CasoResponse caso = new CasoResponse();
						caso.ID_CASO = Convert.ToInt32(row["ID_CASO"].ToString());
						caso.ID_CONTRATO = Convert.ToInt32(row["ID_CONTRATO"].ToString());
						caso.descripcion = row["descripcion"].ToString();
						caso.nombre = row["nombre"].ToString();
						caso.fecha_caso = Convert.ToDateTime(row["fecha_caso"].ToString());
						caso.resuelto = row["resuelto"].ToString();





		              casolist.Add(caso);


					}

					JSONString = JsonConvert.SerializeObject(casolist);




				}
			}
			catch (Exception ex)
			{

			}
			return (JSONString);
		}
	}
}
