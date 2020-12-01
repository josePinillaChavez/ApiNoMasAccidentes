using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ApiNoMasAccidentes.DAL
{
	public class  ProfesionalRepository : IprofesionalRepository
	{
		private string conexion = Startup.ConnectionString;

		public void CrearProfesional(string nombre, string apellidoPaterno, string apellidoMaterno, string rut, string dvRut, int telefono, string email, string vigente)
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
				using (OracleConnection conn = new OracleConnection(conexion))
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
				using (OracleConnection conn = new OracleConnection(conexion))
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
			try
			{
				using (OracleConnection conn = new OracleConnection(conexion))
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
