using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.DAL
{
	public class EmpresaRepository : IempresaRepository
	{

		private string conexion = Startup.ConnectionString;
		public void CrearEmpresa(int idRubro, string rut, string dv, string nombre, int telefono, string email)
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
					cmd.CommandText = "SP_CREAR_EMPRESA";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("IN_TBL_RUBRO_ID_RUBRO", OracleDbType.Int32).Value = idRubro;
					cmd.Parameters.Add("IN_RUT", OracleDbType.NVarchar2).Value = rut;
					cmd.Parameters.Add("IN_DV_RUT", OracleDbType.NVarchar2).Value = dv;
					cmd.Parameters.Add("IN_NOMBRE", OracleDbType.NVarchar2).Value = nombre;
					cmd.Parameters.Add("IN_TELEFONO", OracleDbType.Int32).Value = telefono;
					cmd.Parameters.Add("IN_EMAIL", OracleDbType.NVarchar2).Value = email;
					cmd.Parameters.Add("IN_VIGENTE", OracleDbType.Char).Value = "1";
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

		public void EliminarEmpresa(int ID_EMPRESA)
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
					cmd.CommandText = "SP_DEL_EMPRESA";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("IN_ID_EMPRESA", OracleDbType.Int32).Value = ID_EMPRESA;
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




		public void ActualizarEmpresa(int idempresa, int idRubro, string rut, string dv, string nombre, int telefono, string email)
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
					cmd.CommandText = "SP_UPDATE_EMPRESA";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("IN_ID_EMPRESA", OracleDbType.Int32).Value = idempresa;
					cmd.Parameters.Add("IN_ID_RUBRO", OracleDbType.Int32).Value = idRubro;
					cmd.Parameters.Add("IN_RUT", OracleDbType.NVarchar2).Value = rut;
					cmd.Parameters.Add("IN_DV_RUT", OracleDbType.NVarchar2).Value = dv;
					cmd.Parameters.Add("IN_NOMBRE", OracleDbType.NVarchar2).Value = nombre;
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



		public string ListarEmpresa()
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
					cmd.CommandText = "DUOCNMA.SP_LISTAR_EMPRESA";
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
