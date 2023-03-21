using MRGFE.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MRGFE.Controllers
{
    /// <summary>
    /// Controlador para Campo Proveedor
    /// </summary>
    public class III_CampoProveedorController : ApiController
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);

        /// <summary>
        /// Esta función recibe los datos del Campo Proveedor y los guarda
        /// </summary>
        /// <param name="campoProveedor">Json representativo de un Campo Proveedor a registrar</param>
        /// <returns>Datos del Campo Proveedor registrado</returns>
        [HttpPost, Route("api/campoproveedor")]
        public dynamic PostCampoProveedor([FromBody] CampoProveedor campoProveedor)
        {
            if (ModelState.IsValid)
            {
                SqlCommand command = new SqlCommand("procMRGFECamposProveedor", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@accion", 1);
                command.Parameters.AddWithValue("@CAMPOSPRID", SqlDbType.VarChar).Value = campoProveedor.CamposPrId;
                command.Parameters.AddWithValue("@CAMPOSPRPROVEDOR", SqlDbType.VarChar).Value = campoProveedor.CamposPrProveedor;
                command.Parameters.AddWithValue("@CAMPOSPRCAMPO", SqlDbType.VarChar).Value = campoProveedor.CamposPrCampo;
                command.Parameters.AddWithValue("@CAMPOSPRETIQUETA", SqlDbType.VarChar).Value = campoProveedor.CamposPrEtiqueta;
                command.Parameters.AddWithValue("@CAMPOSPRTIPODATO", SqlDbType.VarChar).Value = campoProveedor.CamposPrTipoDato;
                command.Parameters.AddWithValue("@CAMPOSPRARREGLO1", SqlDbType.Bit).Value = campoProveedor.CamposPrArreglo1;
                command.Parameters.AddWithValue("@CAMPOSPRVERSION", SqlDbType.VarChar).Value = campoProveedor.CamposPrVersion;
                command.Parameters.AddWithValue("@CAMPOSPROBLIGA1", SqlDbType.Bit).Value = campoProveedor.CamposPrObliga1;

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            return Request.CreateResponse(HttpStatusCode.Created, campoProveedor);
        }

        /// <summary>
        /// Esta función recibe los datos de Campo Proveedor para actualizar el objeto según su Id
        /// </summary>
        /// <param name="campoProveedor">Json representativo de un Campo Proveedor a actualizar</param>
        /// <returns>Datos del Camp Proveedor actualizado</returns>
        [HttpPut, Route("api/campoproveedor")]
        public dynamic PutCampoProveedor([FromBody] CampoProveedor campoProveedor)
        {
            if (ModelState.IsValid)
            {
                SqlCommand command = new SqlCommand("procMRGFECamposProveedor", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@accion", 2);
                command.Parameters.AddWithValue("@CAMPOSPRID", SqlDbType.VarChar).Value = campoProveedor.CamposPrId;
                command.Parameters.AddWithValue("@CAMPOSPRPROVEDOR", SqlDbType.VarChar).Value = campoProveedor.CamposPrProveedor;
                command.Parameters.AddWithValue("@CAMPOSPRCAMPO", SqlDbType.VarChar).Value = campoProveedor.CamposPrCampo;
                command.Parameters.AddWithValue("@CAMPOSPRETIQUETA", SqlDbType.VarChar).Value = campoProveedor.CamposPrEtiqueta;
                command.Parameters.AddWithValue("@CAMPOSPRTIPODATO", SqlDbType.VarChar).Value = campoProveedor.CamposPrTipoDato;
                command.Parameters.AddWithValue("@CAMPOSPRARREGLO1", SqlDbType.Bit).Value = campoProveedor.CamposPrArreglo1;
                command.Parameters.AddWithValue("@CAMPOSPRVERSION", SqlDbType.VarChar).Value = campoProveedor.CamposPrVersion;
                command.Parameters.AddWithValue("@CAMPOSPROBLIGA1", SqlDbType.Bit).Value = campoProveedor.CamposPrObliga1;

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            return Request.CreateResponse(HttpStatusCode.OK, campoProveedor);
        }

        /// <summary>
        /// Esta función elimina el Campo Proveedor correspondiente al Id
        /// </summary>
        /// <param name="id">Id del Campo Proveedor a eliminar</param>
        [HttpDelete, Route("api/campoproveedor/{id}")]
        public void DeleteCampoProveedor(string id)
        {
            SqlCommand command = new SqlCommand("procMRGFECamposProveedor", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@accion", 3);
            command.Parameters.AddWithValue("@CAMPOSPRID", SqlDbType.VarChar).Value = id;

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Esta función obtiene los Campos de Proveedor
        /// </summary>
        /// <returns>Lista de los Campos de Proveedor</returns>
        [HttpGet, Route("api/campoproveedor")]
        public HttpResponseMessage GetCamposProveedor()
        {
            SqlDataAdapter da = new SqlDataAdapter("procMRGFECamposProveedor", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@accion", 4);

            DataTable dt = new DataTable();
            da.Fill(dt);
            List<CampoProveedor> lstCampoProveedor = new List<CampoProveedor>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CampoProveedor campoProveedor = new CampoProveedor();
                    campoProveedor.CamposPrId = dt.Rows[i]["CAMPOSPRID"].ToString();
                    campoProveedor.CamposPrProveedor = dt.Rows[i]["CAMPOSPRPROVEDOR"].ToString();
                    campoProveedor.CamposPrCampo = dt.Rows[i]["CAMPOSPRCAMPO"].ToString();
                    campoProveedor.CamposPrEtiqueta = dt.Rows[i]["CAMPOSPRETIQUETA"].ToString();
                    campoProveedor.CamposPrTipoDato = dt.Rows[i]["CAMPOSPRTIPODATO"].ToString();
                    campoProveedor.CamposPrArreglo1 = Convert.ToByte(dt.Rows[i]["CAMPOSPRARREGLO1"]);
                    campoProveedor.CamposPrVersion = dt.Rows[i]["CAMPOSPRVERSION"].ToString();
                    campoProveedor.CamposPrObliga1 = Convert.ToByte(dt.Rows[i]["CAMPOSPROBLIGA1"]);

                    lstCampoProveedor.Add(campoProveedor);
                }
            }
            if (lstCampoProveedor.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, lstCampoProveedor);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No hay registros en este momento.");

        }

        /// <summary>
        /// Esta función obtiene un Campo de Proveedor por Id
        /// </summary>
        /// <param name="id">Id del Campo de Proveedor a recuperar</param>
        /// <returns>Datos del Campo Proveedor recuperado</returns>
        [HttpGet, Route("api/campoproveedor/{id}")]
        public dynamic GetPorId(string id)
        {
            SqlDataAdapter da = new SqlDataAdapter("procMRGFECamposProveedor", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@accion", 5);
            da.SelectCommand.Parameters.AddWithValue("@CAMPOSPRID", SqlDbType.VarChar).Value = id;

            DataTable dt = new DataTable();
            da.Fill(dt);
            CampoProveedor campoProveedor = new CampoProveedor();
            if (dt.Rows.Count > 0)
            {
                campoProveedor.CamposPrId = dt.Rows[0]["CAMPOSPRID"].ToString();
                campoProveedor.CamposPrProveedor = dt.Rows[0]["CAMPOSPRPROVEDOR"].ToString();
                campoProveedor.CamposPrCampo = dt.Rows[0]["CAMPOSPRCAMPO"].ToString();
                campoProveedor.CamposPrEtiqueta = dt.Rows[0]["CAMPOSPRETIQUETA"].ToString();
                campoProveedor.CamposPrTipoDato = dt.Rows[0]["CAMPOSPRTIPODATO"].ToString();
                campoProveedor.CamposPrArreglo1 = Convert.ToByte(dt.Rows[0]["CAMPOSPRARREGLO1"]);
                campoProveedor.CamposPrVersion = dt.Rows[0]["CAMPOSPRVERSION"].ToString();
                campoProveedor.CamposPrObliga1 = Convert.ToByte(dt.Rows[0]["CAMPOSPROBLIGA1"]);
            }
            if (campoProveedor != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, campoProveedor);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No hay registros en este momento.");
        }
    }
}
