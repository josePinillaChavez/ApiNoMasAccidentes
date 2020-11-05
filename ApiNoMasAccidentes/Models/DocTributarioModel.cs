using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoMasAccidentes.Models
{
	public class DocTributarioModel
	{

		public string ListarContrato()
		{
			DataSet dti = new DataSet();
			string JSONString = string.Empty;

			List<DocTributarioResponse> list = new List<DocTributarioResponse>();

			try
			{
				using (OracleConnection conn = new OracleConnection("DATA SOURCE=localhost:1521;PASSWORD=DUOCNMA;USER ID=DUOCNMA;"))
				{
					OracleDataAdapter da = new OracleDataAdapter();
					OracleCommand cmd = new OracleCommand();
					cmd.Connection = conn;
					cmd.InitialLONGFetchSize = 1000;
					cmd.CommandText = "SP_LISTAR_DOC_TRIBUTARIO";
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("T_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

					da.SelectCommand = cmd;
					DataTable dt = new DataTable();
					da.Fill(dt);

					foreach (DataRow row in dt.Rows)
					{
						DocTributarioResponse docTributario = new DocTributarioResponse();
						docTributario.id_doc_tributarios = int.Parse(row["id_doc_tributarios"].ToString());
						docTributario.id_contrato = Convert.ToInt32(row["id_contrato"].ToString());
						docTributario.detalle = row["detalle"].ToString();
						docTributario.pagado = row["pagado"].ToString();
						docTributario.fecha_vencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString());
						docTributario.nombre = row["nombre"].ToString();
						list.Add(docTributario);
					}

					JSONString = JsonConvert.SerializeObject(list);




	}
			}
			catch (Exception ex)
			{

			}
			return (JSONString);
		}
	}
}
