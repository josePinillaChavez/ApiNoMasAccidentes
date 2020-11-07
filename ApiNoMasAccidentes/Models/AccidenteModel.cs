using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
	public class AccidenteModel
	{
		public void CrearAccidente(int IN_ID_DETALLE_CONTRATO, string IN_DETALLE_ACCIDENTE, DateTime IN_FECHA_ACCIDENTE, int IN_USUARIO)
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
					cmd.CommandText = "SP_CREAR_ACCIDENTE";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("IN_ID_DETALLE_CONTRATO", OracleDbType.Int32).Value = IN_ID_DETALLE_CONTRATO;
					cmd.Parameters.Add("IN_DETALLE_ACCIDENTE", OracleDbType.NVarchar2).Value = IN_DETALLE_ACCIDENTE;
					cmd.Parameters.Add("IN_FECHA_ACCIDENTE", OracleDbType.Date).Value = IN_FECHA_ACCIDENTE;
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

		public void EliminarAccidente(int IN_ID_ACCIDENTE)
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
					cmd.CommandText = "SP_DEL_ACCIDENTE";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("IN_ID_ACCIDENTE", OracleDbType.Int32).Value = IN_ID_ACCIDENTE;
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




		public void ActualizarAccidente(int IN_ID_ACCIDENTE, int IN_ID_DETALLE_CONTRATO, string IN_DETALLE_ACCIDENTE, DateTime IN_FECHA_ACCIDENTE, int IN_USUARIO)
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
					cmd.CommandText = "SP_UPDATE_ACCIDENTE";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("IN_ID_ACCIDENTE", OracleDbType.Int32).Value = IN_ID_ACCIDENTE;
					cmd.Parameters.Add("IN_ID_DETALLE_CONTRATO", OracleDbType.Int32).Value = IN_ID_DETALLE_CONTRATO;
					cmd.Parameters.Add("IN_DETALLE_ACCIDENTE", OracleDbType.NVarchar2).Value = IN_DETALLE_ACCIDENTE;
					cmd.Parameters.Add("IN_FECHA_ACCIDENTE", OracleDbType.Date).Value = IN_FECHA_ACCIDENTE;
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



		public string ListarAccidente()
		{
			DataSet dti = new DataSet();
			string JSONString = string.Empty;

			List<AccidenteResponse> accidentelist = new List<AccidenteResponse>();

			try
			{
				using (OracleConnection conn = new OracleConnection("DATA SOURCE=localhost:1521;PASSWORD=DUOCNMA;USER ID=DUOCNMA;"))
				{
					OracleDataAdapter da = new OracleDataAdapter();
					OracleCommand cmd = new OracleCommand();
					cmd.Connection = conn;
					cmd.InitialLONGFetchSize = 1000;
					cmd.CommandText = "DUOCNMA.SP_LISTAR_ACCIDENTE";
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("T_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

					da.SelectCommand = cmd;
					DataTable dt = new DataTable();
					da.Fill(dt);

					foreach (DataRow row in dt.Rows)
					{

						AccidenteResponse accidente = new AccidenteResponse();
						accidente.ID_ACCIDENTE = Convert.ToInt32(row["ID_ACCIDENTE"].ToString());
						accidente.id_contrato = Convert.ToInt32(row["id_contrato"].ToString());
						accidente.DETALLE_ACCIDENTE = row["DETALLE_ACCIDENTE"].ToString();
						accidente.FECHA_ACCIDENTE = Convert.ToDateTime(row["FECHA_ACCIDENTE"].ToString());
						accidente.USUARIO = Convert.ToInt32(row["USUARIO"].ToString());
		

						accidentelist.Add(accidente);


					}

					JSONString = JsonConvert.SerializeObject(accidentelist);




				}
			}
			catch (Exception ex)
			{

			}
			return (JSONString);
		}
	}
}
