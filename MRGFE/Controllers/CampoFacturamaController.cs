using Facturama.Models.Retentions;
using MRGFE.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MRGFE.Controllers
{
    /// <summary>
    /// Controlador para Campo Facturama
    /// </summary>
    public class III_CampoFacturamaController : ApiController
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);

        /// <summary>
        /// Esta función obtiene los Campos de Facturama
        /// </summary>
        /// <returns>Lista de los Campos de Facturama</returns>
        [HttpGet, Route("api/campofacturama")]
        public List<CampoFacturama> GetCamposFacturama()
        {
            SqlDataAdapter da = new SqlDataAdapter("procMRGFECamposFacturamaRecuperar", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@accion", 1);

            DataTable dt = new DataTable();
            da.Fill(dt);
            List<CampoFacturama> lstCampoFacturama = new List<CampoFacturama>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CampoFacturama campoFacturama = new CampoFacturama();
                    campoFacturama.CamposFaId = dt.Rows[i]["CAMPOSFAID"].ToString();
                    campoFacturama.CamposFaCampo = dt.Rows[i]["CAMPOSFACAMPO"].ToString();
                    campoFacturama.CamposFaEtiqueta = dt.Rows[i]["CAMPOSFAETIQUETA"].ToString();
                    campoFacturama.CamposFaTipoDato = dt.Rows[i]["CAMPOSFATIPODATO"].ToString();
                    campoFacturama.CamposFaArreglo1 = Convert.ToByte(dt.Rows[i]["CAMPOSFAARREGLO1"]);
                    campoFacturama.CamposFaVersion = dt.Rows[i]["CAMPOSFAVERSION"].ToString();
                    campoFacturama.CamposFaObliga1 = Convert.ToByte(dt.Rows[i]["CAMPOSFAOBLIGA1"]);

                    lstCampoFacturama.Add(campoFacturama);
                }
            }
            if (lstCampoFacturama.Count > 0)
            {
                return lstCampoFacturama;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Esta función obtiene un Campo de Facturama por Id
        /// </summary>
        /// <param name="id">Id del Campo de Facturama a recuperar</param>
        /// <returns>Datos del Campo Facturama recuperado</returns>
        [HttpGet, Route("api/campofacturama/{id}")]
        public dynamic GetPorId(string id)
        {
            SqlDataAdapter da = new SqlDataAdapter("procMRGFECamposFacturamaRecuperar", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@accion", 2);
            da.SelectCommand.Parameters.AddWithValue("@CAMPOSFAID", SqlDbType.VarChar).Value = id;

            DataTable dt = new DataTable();
            da.Fill(dt);
            CampoFacturama campoFacturama = new CampoFacturama();
            if (dt.Rows.Count > 0)
            {
                campoFacturama.CamposFaId = dt.Rows[0]["CAMPOSFAID"].ToString();
                campoFacturama.CamposFaCampo = dt.Rows[0]["CAMPOSFACAMPO"].ToString();
                campoFacturama.CamposFaEtiqueta = dt.Rows[0]["CAMPOSFAETIQUETA"].ToString();
                campoFacturama.CamposFaTipoDato = dt.Rows[0]["CAMPOSFATIPODATO"].ToString();
                campoFacturama.CamposFaArreglo1 = Convert.ToByte(dt.Rows[0]["CAMPOSFAARREGLO1"]);
                campoFacturama.CamposFaVersion = dt.Rows[0]["CAMPOSFAVERSION"].ToString();
                campoFacturama.CamposFaObliga1 = Convert.ToByte(dt.Rows[0]["CAMPOSFAOBLIGA1"]);
            }
            if (campoFacturama != null)
            {
                return campoFacturama;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Esta función recibe los datos del Campo Facturama y los guarda
        /// </summary>
        /// <param name="campoFacturama">Json representativo de un Campo Facturama a registrar</param>
        /// <returns>Datos del Campo Facturama registrado</returns>
        [HttpPost, Route("api/campofacturama")]
        public dynamic PostCampoFacturama([FromBody] CampoFacturama campoFacturama)
        {
            SqlCommand command = new SqlCommand("procMRGFECamposFacturamaCrear", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CAMPOSFAID", SqlDbType.VarChar).Value = campoFacturama.CamposFaId;
            command.Parameters.AddWithValue("@CAMPOSFACAMPO", SqlDbType.VarChar).Value = campoFacturama.CamposFaCampo;
            command.Parameters.AddWithValue("@CAMPOSFAETIQUETA", SqlDbType.VarChar).Value = campoFacturama.CamposFaEtiqueta;
            command.Parameters.AddWithValue("@CAMPOSFATIPODATO", SqlDbType.VarChar).Value = campoFacturama.CamposFaTipoDato;
            command.Parameters.AddWithValue("@CAMPOSFAARREGLO1", SqlDbType.Bit).Value = campoFacturama.CamposFaArreglo1;
            command.Parameters.AddWithValue("@CAMPOSFAVERSION", SqlDbType.VarChar).Value = campoFacturama.CamposFaVersion;
            command.Parameters.AddWithValue("@CAMPOSFAOBLIGA1", SqlDbType.Bit).Value = campoFacturama.CamposFaObliga1;

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();

            return campoFacturama;
        }

        /// <summary>
        /// Esta función recibe los datos de Campo Facturama para actualizar el objeto según su Id
        /// </summary>
        /// <param name="campoFacturama">Json representativo de un Campo Facturama a actualizar</param>
        /// <returns>Datos del Camp Facturama actualizado</returns>
        [HttpPut, Route("api/campofacturama")]
        public dynamic PutCampoFacturama([FromBody] CampoFacturama campoFacturama)
        {
            SqlCommand command = new SqlCommand("procMRGFECamposFacturamaActualizar", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CAMPOSFAID", SqlDbType.VarChar).Value = campoFacturama.CamposFaId;
            command.Parameters.AddWithValue("@CAMPOSFACAMPO", SqlDbType.VarChar).Value = campoFacturama.CamposFaCampo;
            command.Parameters.AddWithValue("@CAMPOSFAETIQUETA", SqlDbType.VarChar).Value = campoFacturama.CamposFaEtiqueta;
            command.Parameters.AddWithValue("@CAMPOSFATIPODATO", SqlDbType.VarChar).Value = campoFacturama.CamposFaTipoDato;
            command.Parameters.AddWithValue("@CAMPOSFAARREGLO1", SqlDbType.Bit).Value = campoFacturama.CamposFaArreglo1;
            command.Parameters.AddWithValue("@CAMPOSFAVERSION", SqlDbType.VarChar).Value = campoFacturama.CamposFaVersion;
            command.Parameters.AddWithValue("@CAMPOSFAOBLIGA1", SqlDbType.Bit).Value = campoFacturama.CamposFaObliga1;

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();

            return campoFacturama;
        }

        /// <summary>
        /// Esta función elimina el Campo Facturama correspondiente al Id
        /// </summary>
        /// <param name="id">Id del Campo Facturama a eliminar</param>
        [HttpDelete, Route("api/campofacturama/{id}")]
        public void DeleteCampoFacturama(string id)
        {
            SqlCommand command = new SqlCommand("procMRGFECamposFacturamaEliminar", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CAMPOSFAID", SqlDbType.VarChar).Value = id;

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
