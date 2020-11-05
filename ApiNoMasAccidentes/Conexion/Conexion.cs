
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Conexion
{
	public class Conexion
	{

		public void CrearCliente(int idRubro, string rut, string dv,string nombre,int telefono,string email)
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





					//using (OracleConnection cn = new OracleConnection(DatabaseHelper.GetConnectionString()))
					//{
					//	OracleDataAdapter da = new OracleDataAdapter();
					//	OracleCommand cmd = new OracleCommand();
					//	cmd.Connection = cn;
					//	cmd.InitialLONGFetchSize = 1000;
					//	cmd.CommandText = DatabaseHelper.GetDBOwner() + "PKG_COLLECTION.CSP_COLLECTION_HDR_SELECT";
					//	cmd.CommandType = CommandType.StoredProcedure;
					//	cmd.Parameters.Add("PUNIT", OracleDbType.Char).Value = unit;
					//	cmd.Parameters.Add("POFFICE", OracleDbType.Char).Value = office;
					//	cmd.Parameters.Add("PRECEIPT_NBR", OracleDbType.Int32).Value = receiptno;
					//	cmd.Parameters.Add("T_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
					//
					//	da.SelectCommand = cmd;
					//	DataTable dt = new DataTable();
					//	da.Fill(dt);
					//	return dt;
					//}


					//OracleCommand com2 = new OracleCommand();
					//com2.Connection = conn;
					//com2.CommandText = "SELECT * FROM DUOC.TBL_CLIENTE ";
					//OracleDataAdapter das = new OracleDataAdapter(com2);
					//das.Fill(dti);

					////DropDownList1.DataSource = dti;
					//try
					//{
					//	dti.Tables[0].Rows[0]["RUT"].ToString();
					//	conn.Close();
					//}
					//catch (Exception)
					//{


					//}






				}
			}
			catch (Exception ex)
			{
				
			}





		}
	
	}
}
