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
    /// Controlador para Campo Mirage
    /// </summary>
    public class IV_CampoMirageController : ApiController
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);

        /// <summary>
        /// Esta función recibe los datos del Campo Mirage y los guarda
        /// </summary>
        /// <param name="campoMirage">Json representativo de un Campo Mirage a registrar</param>
        /// <returns>Datos del Campo Mirage registrado</returns>
        [HttpPost, Route("api/campomirage")]
        public dynamic PostCampoMirage([FromBody] CampoMirage campoMirage)
        {
            if (ModelState.IsValid)
            {
                SqlCommand command = new SqlCommand("procMRGFECamposMirage", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@accion", 1);
                command.Parameters.AddWithValue("@CAMPOSMIID", SqlDbType.VarChar).Value = campoMirage.CamposMiId;
                command.Parameters.AddWithValue("@CAMPOSMICAMPO", SqlDbType.VarChar).Value = campoMirage.CamposMiCampo;
                command.Parameters.AddWithValue("@CAMPOSMIETIQUETA", SqlDbType.VarChar).Value = campoMirage.CamposMiEtiqueta;
                command.Parameters.AddWithValue("@CAMPOSMITIPODATO", SqlDbType.VarChar).Value = campoMirage.CamposMiTipoDato;
                command.Parameters.AddWithValue("@CAMPOSMIARREGLO1", SqlDbType.Bit).Value = campoMirage.CamposMiArreglo1;
                command.Parameters.AddWithValue("@CAMPOSMIVERSION", SqlDbType.VarChar).Value = campoMirage.CamposMiVersion;
                command.Parameters.AddWithValue("@CAMPOSMIOBLIGA1", SqlDbType.Bit).Value = campoMirage.CamposMiObliga1;

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            return Request.CreateResponse(HttpStatusCode.Created, campoMirage);
        }

        /// <summary>
        /// Esta función recibe los datos de Campo Mirage para actualizar el objeto según su Id
        /// </summary>
        /// <param name="campoMirage">Json representativo de un Campo Mirage a actualizar</param>
        /// <returns>Datos del Camp Mirage actualizado</returns>
        [HttpPut, Route("api/campomirage")]
        public dynamic PutCampoMirage([FromBody] CampoMirage campoMirage)
        {
            if (ModelState.IsValid)
            {

                SqlCommand command = new SqlCommand("procMRGFECamposMirage", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@accion", 2);
                command.Parameters.AddWithValue("@CAMPOSMIID", SqlDbType.VarChar).Value = campoMirage.CamposMiId;
                command.Parameters.AddWithValue("@CAMPOSMICAMPO", SqlDbType.VarChar).Value = campoMirage.CamposMiCampo;
                command.Parameters.AddWithValue("@CAMPOSMIETIQUETA", SqlDbType.VarChar).Value = campoMirage.CamposMiEtiqueta;
                command.Parameters.AddWithValue("@CAMPOSMITIPODATO", SqlDbType.VarChar).Value = campoMirage.CamposMiTipoDato;
                command.Parameters.AddWithValue("@CAMPOSMIARREGLO1", SqlDbType.Bit).Value = campoMirage.CamposMiArreglo1;
                command.Parameters.AddWithValue("@CAMPOSMIVERSION", SqlDbType.VarChar).Value = campoMirage.CamposMiVersion;
                command.Parameters.AddWithValue("@CAMPOSMIOBLIGA1", SqlDbType.Bit).Value = campoMirage.CamposMiObliga1;

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            return Request.CreateResponse(HttpStatusCode.OK, campoMirage);
        }

        /// <summary>
        /// Esta función elimina el Campo Mirage correspondiente al Id
        /// </summary>
        /// <param name="id">Id del Campo Mirage a eliminar</param>
        [HttpDelete, Route("api/campomirage/{id}")]
        public HttpResponseMessage DeleteCampoMirage(string id)
        {
            SqlCommand command = new SqlCommand("procMRGFECamposMirage", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@accion", 3);
            command.Parameters.AddWithValue("@CAMPOSMIID", SqlDbType.VarChar).Value = id;

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
            return Request.CreateResponse(HttpStatusCode.OK, "Registro eliminado");

        }

        /// <summary>
        /// Esta función obtiene los Campos de Mirage
        /// </summary>
        /// <returns>Lista de los Campos de Mirage</returns>
        [HttpGet, Route("api/campomirage")]
        public HttpResponseMessage GetCamposMirage()
        {
            SqlDataAdapter da = new SqlDataAdapter("procMRGFECamposMirage", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@accion", 4);

            DataTable dt = new DataTable();
            da.Fill(dt);
            List<CampoMirage> lstCampoMirage = new List<CampoMirage>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CampoMirage campoMirage = new CampoMirage();
                    campoMirage.CamposMiId = dt.Rows[i]["CAMPOSMIID"].ToString();
                    campoMirage.CamposMiCampo = dt.Rows[i]["CAMPOSMICAMPO"].ToString();
                    campoMirage.CamposMiEtiqueta = dt.Rows[i]["CAMPOSMIETIQUETA"].ToString();
                    campoMirage.CamposMiTipoDato = dt.Rows[i]["CAMPOSMITIPODATO"].ToString();
                    campoMirage.CamposMiArreglo1 = Convert.ToByte(dt.Rows[i]["CAMPOSMIARREGLO1"]);
                    campoMirage.CamposMiVersion = dt.Rows[i]["CAMPOSMIVERSION"].ToString();
                    campoMirage.CamposMiObliga1 = Convert.ToByte(dt.Rows[i]["CAMPOSMIOBLIGA1"]);

                    lstCampoMirage.Add(campoMirage);
                }
            }
            if (lstCampoMirage.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, lstCampoMirage);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No hay registros en este momento.");

        }

        /// <summary>
        /// Esta función obtiene un Campo de Mirage por Id
        /// </summary>
        /// <param name="id">Id del Campo de Mirage a recuperar</param>
        /// <returns>Datos del Campo Mirage recuperado</returns>
        [HttpGet, Route("api/campomirage/{id}")]
        public dynamic GetPorId(string id)
        {
            SqlDataAdapter da = new SqlDataAdapter("procMRGFECamposMirage", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@accion", 5);
            da.SelectCommand.Parameters.AddWithValue("@CAMPOSMIID", SqlDbType.VarChar).Value = id;

            DataTable dt = new DataTable();
            da.Fill(dt);
            CampoMirage campoMirage = new CampoMirage();
            if (dt.Rows.Count > 0)
            {
                campoMirage.CamposMiId = dt.Rows[0]["CAMPOSMIID"].ToString();
                campoMirage.CamposMiCampo = dt.Rows[0]["CAMPOSMICAMPO"].ToString();
                campoMirage.CamposMiEtiqueta = dt.Rows[0]["CAMPOSMIETIQUETA"].ToString();
                campoMirage.CamposMiTipoDato = dt.Rows[0]["CAMPOSMITIPODATO"].ToString();
                campoMirage.CamposMiArreglo1 = Convert.ToByte(dt.Rows[0]["CAMPOSMIARREGLO1"]);
                campoMirage.CamposMiVersion = dt.Rows[0]["CAMPOSMIVERSION"].ToString();
                campoMirage.CamposMiObliga1 = Convert.ToByte(dt.Rows[0]["CAMPOSMIOBLIGA1"]);
            }
            if (campoMirage != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, campoMirage);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No hay registros en este momento.");
        }
    }
}
