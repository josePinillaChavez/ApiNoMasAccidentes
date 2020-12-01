using ApiNoMasAccidentes.Models;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.DAL
{
	public class UsuarioRepository : IusuarioRepository
	{
		private string conexion = Startup.ConnectionString;

		public void CrearUsuario(int idPerfil, string usuario, string contrasena, string estado, string rutUsuario, string dvRut)
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
				using (OracleConnection conn = new OracleConnection(conexion))
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
				using (OracleConnection conn = new OracleConnection(conexion))
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
		 

		public UsuarioModel Autenticar(string usuario, string contrasena, int perf)
		{
			DataSet dti = new DataSet();
			string JSONString = string.Empty;
			UsuarioModel usuarioModel = new UsuarioModel();



			try
			{
				using (OracleConnection conn = new OracleConnection(conexion))
				{
					OracleDataAdapter da = new OracleDataAdapter();
					OracleCommand cmd = new OracleCommand();
					cmd.Connection = conn;
					cmd.InitialLONGFetchSize = 1000;
					cmd.CommandText = "DUOCNMA.SP_AUTENTICAR_USUARIO";
					cmd.Parameters.Add("IN_ID_USUARIO", OracleDbType.NVarchar2).Value = usuario;
					cmd.Parameters.Add("IN_CONTRASENA", OracleDbType.NVarchar2).Value = contrasena;
					cmd.Parameters.Add("IN_ID_PERFIL", OracleDbType.Int32).Value = perf;		
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("T_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

					da.SelectCommand = cmd;
					DataTable dt = new DataTable();
					da.Fill(dt);


					if (dt != null)
					{
						foreach (DataRow item in dt.Rows)
						{
							usuarioModel.usuario = item["USUARIO"].ToString();
							usuarioModel.contrasena = item["CONTRASENA"].ToString();
							usuarioModel.id_perfil = Convert.ToInt32(item["ID_PERFIL"].ToString());
						}
					}

					else{
						return null;
					}



				}
			}
			catch (Exception ex)
			{
				return null;
			}
			return (usuarioModel);
		}



		public string ListarUsuario()
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
					cmd.CommandText = "DUOCNMA.SP_LISTAR_USUARIO";
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
