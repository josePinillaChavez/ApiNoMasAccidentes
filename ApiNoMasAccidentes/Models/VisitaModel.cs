using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
	public class VisitaModel
	{

		public void CrearVisita(int IN_ID_DETALLE_CONTRATO, DateTime IN_FECHA_INICIO, DateTime IN_FECHA_TERMINMO, int IN_USUARIO)
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
					cmd.CommandText = "SP_CREAR_VISITA";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("IN_ID_DETALLE_CONTRATO", OracleDbType.Int32).Value = IN_ID_DETALLE_CONTRATO;
					cmd.Parameters.Add("IN_FECHA_INICIO", OracleDbType.Date).Value = IN_FECHA_INICIO;
					cmd.Parameters.Add("IN_FECHA_TERMINMO", OracleDbType.Date).Value = IN_FECHA_TERMINMO;
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

		public void EliminarVisita(int IN_ID_VISITA)
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
					cmd.CommandText = "SP_DEL_VISITA";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("IN_ID_VISITA", OracleDbType.Int32).Value = IN_ID_VISITA;
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




		public void ActualizarVisita(int IN_ID_VISITA, int IN_ID_DETALLE_CONTRATO, DateTime IN_FECHA_INICIO, DateTime IN_FECHA_TERMINO, int IN_USUARIO, string IN_RESUELTO)
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
					cmd.CommandText = "SP_UPDATE_VISITA";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("IN_ID_VISITA", OracleDbType.Int32).Value = IN_ID_VISITA;
					cmd.Parameters.Add("IN_ID_DETALLE_CONTRATO", OracleDbType.Int32).Value = IN_ID_DETALLE_CONTRATO;
					cmd.Parameters.Add("IN_FECHA_INICIO", OracleDbType.Date).Value = IN_FECHA_INICIO;
					cmd.Parameters.Add("IN_FECHA_TERMINO", OracleDbType.Date).Value = IN_FECHA_TERMINO;
					cmd.Parameters.Add("IN_USUARIO", OracleDbType.Int32).Value = IN_USUARIO;
					cmd.Parameters.Add("IN_RESUELTO", OracleDbType.NVarchar2).Value = IN_RESUELTO;
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



		public string ListarVisita()
		{
			DataSet dti = new DataSet();
			string JSONString = string.Empty;

			List<VisitaResponse> visitalist = new List<VisitaResponse>();

			try
			{
				using (OracleConnection conn = new OracleConnection("DATA SOURCE=localhost:1521;PASSWORD=DUOCNMA;USER ID=DUOCNMA;"))
				{
					OracleDataAdapter da = new OracleDataAdapter();
					OracleCommand cmd = new OracleCommand();
					cmd.Connection = conn;
					cmd.InitialLONGFetchSize = 1000;
					cmd.CommandText = "SP_LISTAR_VISITA";
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("T_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

					da.SelectCommand = cmd;
					DataTable dt = new DataTable();
					da.Fill(dt);

					foreach (DataRow row in dt.Rows)
					{
						
						VisitaResponse visita = new VisitaResponse();
						visita.id_visita = int.Parse(row["id_visita"].ToString());
						visita.fecha_inicio = Convert.ToDateTime(row["fecha_inicio"].ToString());
						visita.fecha_termino = Convert.ToDateTime(row["fecha_termino"].ToString());
						visita.nombre = row["nombre"].ToString();
						visita.nombreProfesional = row["nombreProfesional"].ToString();
						visita.resuelto = row["resuelto"].ToString();
	
						visitalist.Add(visita);


					}

					JSONString = JsonConvert.SerializeObject(visitalist);




				}
			}
			catch (Exception ex)
			{

			}
			return (JSONString);
		}



	}
}
