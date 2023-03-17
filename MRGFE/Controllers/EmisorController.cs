using Facturama;
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
    /// Controlador para Emisor
    /// </summary>
    public class II_EmisorController : ApiController
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);

        /// <summary>
        /// Esta función recibe los datos de Emisor y los guarda
        /// </summary>
        /// <param name="emisor">Json representativo de un Emisor a registrar</param>
        /// <returns>Datos del Emisor registrado</returns>
        [HttpPost, Route("api/emisor")]
        public HttpResponseMessage PostEmisor([FromBody] Emisor emisor)
        {
            if (ModelState.IsValid)
            {
                SqlCommand command = new SqlCommand("procMRGFEEmisor", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@accion", 1);
                command.Parameters.AddWithValue("@EMISORRFC", SqlDbType.VarChar).Value = emisor.EmisorRfc;
                command.Parameters.AddWithValue("@EMISORRAZSOCIAL", SqlDbType.VarChar).Value = emisor.EmisorRazSocial;
                command.Parameters.AddWithValue("@EMISORIDEXTERNO1", SqlDbType.VarChar).Value = emisor.EmisorIdExterno1;
                command.Parameters.AddWithValue("@EMISORIDEXTERNO2", SqlDbType.VarChar).Value = emisor.EmisorIdExterno2;
                command.Parameters.AddWithValue("@EMISORIDEXTERNO3", SqlDbType.VarChar).Value = emisor.EmisorIdExterno3;
                command.Parameters.AddWithValue("@EMISORESTATUS", SqlDbType.VarChar).Value = emisor.EmisorEstatus;
                command.Parameters.AddWithValue("@EMISORREGFISCAL", SqlDbType.VarChar).Value = emisor.EmisorRegFiscal;
                command.Parameters.AddWithValue("@EMISORCORREO", SqlDbType.VarChar).Value = emisor.EmisorCorreo;
                command.Parameters.AddWithValue("@EMISORCODPOSTAL", SqlDbType.VarChar).Value = emisor.EmisorCodPostal;
                command.Parameters.AddWithValue("@EMISORMUNICIPIO", SqlDbType.VarChar).Value = emisor.EmisorMunicipio;
                command.Parameters.AddWithValue("@EMISORESTADO", SqlDbType.VarChar).Value = emisor.EmisorEstado;
                command.Parameters.AddWithValue("@EMISORCOLONIA", SqlDbType.VarChar).Value = emisor.EmisorColonia;
                command.Parameters.AddWithValue("@EMISORCALLE", SqlDbType.VarChar).Value = emisor.EmisorCalle;
                command.Parameters.AddWithValue("@EMISORNOEXTERIOR", SqlDbType.VarChar).Value = emisor.EmisorNoExterior;
                command.Parameters.AddWithValue("@EMISORNOINTERIOR", SqlDbType.VarChar).Value = emisor.EmisorNoInterior;
                command.Parameters.AddWithValue("@EMISORFOLIOINIC", SqlDbType.VarChar).Value = emisor.EmisorFolioInic;

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            return Request.CreateResponse(HttpStatusCode.Created, emisor);
        }

        /// <summary>
        /// Esta función recibe los datos de Emisor para actualizar el objeto según su RFC
        /// </summary>
        /// <param name="emisor">Json representativo de un Emisor a actualizar</param>
        /// <returns>Datos del Emisor actualizado</returns>
        [HttpPut, Route("api/emisor")]
        public dynamic PutEmisor([FromBody] Emisor emisor)
        {
            if (ModelState.IsValid)
            {
                SqlCommand command = new SqlCommand("procMRGFEEmisor", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@accion", 2);
                command.Parameters.AddWithValue("@EMISORRFC", SqlDbType.VarChar).Value = emisor.EmisorRfc;
                command.Parameters.AddWithValue("@EMISORRAZSOCIAL", SqlDbType.VarChar).Value = emisor.EmisorRazSocial;
                command.Parameters.AddWithValue("@EMISORESTATUS", SqlDbType.VarChar).Value = emisor.EmisorEstatus;
                command.Parameters.AddWithValue("@EMISORREGFISCAL", SqlDbType.VarChar).Value = emisor.EmisorRegFiscal;
                command.Parameters.AddWithValue("@EMISORCORREO", SqlDbType.VarChar).Value = emisor.EmisorCorreo;
                command.Parameters.AddWithValue("@EMISORCODPOSTAL", SqlDbType.VarChar).Value = emisor.EmisorCodPostal;
                command.Parameters.AddWithValue("@EMISORMUNICIPIO", SqlDbType.VarChar).Value = emisor.EmisorMunicipio;
                command.Parameters.AddWithValue("@EMISORESTADO", SqlDbType.VarChar).Value = emisor.EmisorEstado;
                command.Parameters.AddWithValue("@EMISORCOLONIA", SqlDbType.VarChar).Value = emisor.EmisorColonia;
                command.Parameters.AddWithValue("@EMISORCALLE", SqlDbType.VarChar).Value = emisor.EmisorCalle;
                command.Parameters.AddWithValue("@EMISORNOEXTERIOR", SqlDbType.VarChar).Value = emisor.EmisorNoExterior;
                command.Parameters.AddWithValue("@EMISORNOINTERIOR", SqlDbType.VarChar).Value = emisor.EmisorNoInterior;
                command.Parameters.AddWithValue("@EMISORFOLIOINIC", SqlDbType.VarChar).Value = emisor.EmisorFolioInic;

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            return Request.CreateResponse(HttpStatusCode.OK, emisor);
        }

        /// <summary>
        /// Esta función elimina el Emisor correspondinete al RFC
        /// </summary>
        /// <param name="rfc">RFC del Emisor a eliminar</param>
        [HttpDelete, Route("api/emisor/{rfc}")]
        public void DeleteEmisor(string rfc)
        {
            SqlCommand command = new SqlCommand("procMRGFEEmisor", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@accion", 3);
            command.Parameters.AddWithValue("@EMISORRFC", SqlDbType.VarChar).Value = rfc;

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Esta función obtiene los Emisores
        /// </summary>
        /// <returns>Lista de los Emisores</returns>
        [HttpGet, Route("api/emisor")]
        public HttpResponseMessage GetEmisores()
        {
            SqlDataAdapter da = new SqlDataAdapter("procMRGFEEmisor", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@accion", 5);
            
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Emisor> lstEmisor = new List<Emisor>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Emisor emisor = new Emisor();
                    emisor.EmisorRfc = dt.Rows[i]["EMISORRFC"].ToString();
                    emisor.EmisorRazSocial = dt.Rows[i]["EMISORRAZSOCIAL"].ToString();
                    emisor.EmisorIdExterno1 = dt.Rows[i]["EMISORIDEXTERNO1"].ToString();
                    emisor.EmisorIdExterno2 = dt.Rows[i]["EMISORIDEXTERNO2"].ToString();
                    emisor.EmisorIdExterno3 = dt.Rows[i]["EMISORIDEXTERNO3"].ToString();
                    emisor.EmisorEstatus = dt.Rows[i]["EMISORESTATUS"].ToString();
                    emisor.EmisorRegFiscal = dt.Rows[i]["EMISORREGFISCAL"].ToString();
                    emisor.EmisorCorreo = dt.Rows[i]["EMISORCORREO"].ToString();
                    emisor.EmisorLogoUrl = dt.Rows[i]["EMISORLOGOURL"].ToString();
                    emisor.EmisorCodPostal = dt.Rows[i]["EMISORCODPOSTAL"].ToString();
                    emisor.EmisorMunicipio = dt.Rows[i]["EMISORMUNICIPIO"].ToString();
                    emisor.EmisorEstado = dt.Rows[i]["EMISORESTADO"].ToString();
                    emisor.EmisorColonia = dt.Rows[i]["EMISORCOLONIA"].ToString();
                    emisor.EmisorCalle = dt.Rows[i]["EMISORCALLE"].ToString();
                    emisor.EmisorNoExterior = dt.Rows[i]["EMISORNOEXTERIOR"].ToString();
                    emisor.EmisorNoInterior = dt.Rows[i]["EMISORNOINTERIOR"].ToString();
                    emisor.EmisorFolioInic = dt.Rows[i]["EMISORFOLIOINIC"].ToString();

                    lstEmisor.Add(emisor);
                }
            }
            if (lstEmisor.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, lstEmisor);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No hay registros en este momento.");
        }

        /// <summary>
        /// Esta función obtiene un Emisor por Rfc
        /// </summary>
        /// <param name="rfc">RFC del Emisor a recuperar</param>
        /// <returns>Datos del Emisor recuperado</returns>
        [HttpGet, Route("api/emisor/{rfc}")]
        public dynamic GetPorRfc(string rfc)
        {
            SqlDataAdapter da = new SqlDataAdapter("procMRGFEEmisor", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@accion", 6);
            da.SelectCommand.Parameters.AddWithValue("@EMISORRFC", SqlDbType.VarChar).Value = rfc;

            DataTable dt = new DataTable();
            da.Fill(dt);
            Emisor emisor = new Emisor();
            if (dt.Rows.Count > 0)
            {
                emisor.EmisorRfc = dt.Rows[0]["EMISORRFC"].ToString();
                emisor.EmisorRazSocial = dt.Rows[0]["EMISORRAZSOCIAL"].ToString();
                emisor.EmisorIdExterno1 = dt.Rows[0]["EMISORIDEXTERNO1"].ToString();
                emisor.EmisorIdExterno2 = dt.Rows[0]["EMISORIDEXTERNO2"].ToString();
                emisor.EmisorIdExterno3 = dt.Rows[0]["EMISORIDEXTERNO3"].ToString();
                emisor.EmisorEstatus = dt.Rows[0]["EMISORESTATUS"].ToString();
                emisor.EmisorRegFiscal = dt.Rows[0]["EMISORREGFISCAL"].ToString();
                emisor.EmisorCorreo = dt.Rows[0]["EMISORCORREO"].ToString();
                emisor.EmisorLogoUrl = dt.Rows[0]["EMISORLOGOURL"].ToString();
                emisor.EmisorCodPostal = dt.Rows[0]["EMISORCODPOSTAL"].ToString();
                emisor.EmisorMunicipio = dt.Rows[0]["EMISORMUNICIPIO"].ToString();
                emisor.EmisorEstado = dt.Rows[0]["EMISORESTADO"].ToString();
                emisor.EmisorColonia = dt.Rows[0]["EMISORCOLONIA"].ToString();
                emisor.EmisorCalle = dt.Rows[0]["EMISORCALLE"].ToString();
                emisor.EmisorNoExterior = dt.Rows[0]["EMISORNOEXTERIOR"].ToString();
                emisor.EmisorNoInterior = dt.Rows[0]["EMISORNOINTERIOR"].ToString();
                emisor.EmisorFolioInic = dt.Rows[0]["EMISORFOLIOINIC"].ToString();
            }
            if (emisor.EmisorRfc != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, emisor);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No hay emisor con el RFC especificado.");
        }
    }
}
