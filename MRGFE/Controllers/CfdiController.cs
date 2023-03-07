using MRGFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Facturama.Models.Request;
using Facturama.Services;
using Facturama;
using Facturama.Models.Complements.Payroll;
using Facturama.Models.Response;

namespace MRGFE.Controllers
{
    /// <summary>
    /// Controlador para CFDI
    /// </summary>
    public class CfdiController : ApiController
    {
        FacturamaApiMultiemisor facturama = new FacturamaApiMultiemisor("pruebas", "pruebas2011");
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);

        /// <summary>
        /// Esta función obtiene todos los Cfdis
        /// </summary>
        /// <returns>Lista de Cfdis</returns>
        [HttpGet, Route("api/cfdi")]
        public List<CFDI> GetFacturas()
        {
            SqlDataAdapter da = new SqlDataAdapter("procMRGFECFDIsRecuperacionCFDIs", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@accion", 1);

            DataTable dt = new DataTable();
            da.Fill(dt);
            List<CFDI> lstCfdi = new List<CFDI>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CFDI cfdi = new CFDI();
                    cfdi.CfdiId = dt.Rows[i]["CFDIID"].ToString();
                    cfdi.CfdiFolioFiscal = dt.Rows[i]["CFDIFOLIOFISCAL"].ToString();
                    cfdi.CfdiSerie = dt.Rows[i]["CFDISERIE"].ToString();
                    cfdi.CfdiRSocEmisor = dt.Rows[i]["CFDIRSOCEMISOR"].ToString();
                    cfdi.CfdiRfcEmisor = dt.Rows[i]["CFDIRFCEMISOR"].ToString();
                    cfdi.CfdiRSocReceptor = dt.Rows[i]["CFDIRSOCRECEPTOR"].ToString();
                    cfdi.CfdiRfcReceptor = dt.Rows[i]["CFDIRFCRECEPTOR"].ToString();
                    cfdi.CfdiFecha = Convert.ToDateTime(dt.Rows[i]["CFDIFECHA"]);
                    cfdi.CfdiTotal = Convert.ToDouble(dt.Rows[i]["CFDITOTAL"]);
                    cfdi.CfdiEmail = dt.Rows[i]["CFDIEMAIL"].ToString();
                    cfdi.CfdiEsActivo = dt.Rows[i]["CFDIESACTIVO"].ToString();
                    cfdi.CfdiEmailEnviado = Convert.ToByte(dt.Rows[i]["CFDIEMAILENVIADO"]);
                    cfdi.CfdiIPdf = (byte[])dt.Rows[i]["CFDIPDF"];
                    cfdi.CfdiIXml = (byte[])dt.Rows[i]["CFDIXML"];
                    cfdi.CfdiProcesado1Pdf = Convert.ToByte(dt.Rows[i]["CFDIPROCESADO1PDF"]);
                    cfdi.CfdiProcesado1Xml = Convert.ToByte(dt.Rows[i]["CFDIPROCESADO1XML"]);
                    cfdi.CfdiUrlPdf = dt.Rows[i]["CFDIURLPDF"].ToString();
                    cfdi.CfdiUrlXml = dt.Rows[i]["CFDIURLXML"].ToString();
                    cfdi.CfdiFechaProcesadoPdf = Convert.ToDateTime(dt.Rows[i]["CFDIFECHAPROCESADOPDF"]);
                    cfdi.CfdiFechaProcesadoXml = Convert.ToDateTime(dt.Rows[i]["CFDIFECHAPROCESADOXML"]);

                    lstCfdi.Add(cfdi);
                }
            }
            if (lstCfdi.Count > 0)
            {
                return lstCfdi;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Esta función obtiene un Cfdi por Id
        /// </summary>
        /// <param name="id">Id del Cfdi</param>
        /// <returns>Cfdi que coincide con el Id</returns>
        [HttpGet, Route("api/cfdi/{id}")]
        public dynamic GetPorId(string id)
        {
            SqlDataAdapter da = new SqlDataAdapter("procMRGFECFDIsRecuperacionCFDIs", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@accion", 2);
            da.SelectCommand.Parameters.AddWithValue("@CFDIID", SqlDbType.VarChar).Value = id;

            DataTable dt = new DataTable();
            da.Fill(dt);
            CFDI cfdi = new CFDI();
            if (dt.Rows.Count > 0)
            {
                cfdi.CfdiId = dt.Rows[0]["CFDIID"].ToString();
                cfdi.CfdiFolioFiscal = dt.Rows[0]["CFDIFOLIOFISCAL"].ToString();
                cfdi.CfdiSerie = dt.Rows[0]["CFDISERIE"].ToString();
                cfdi.CfdiRSocEmisor = dt.Rows[0]["CFDIRSOCEMISOR"].ToString();
                cfdi.CfdiRfcEmisor = dt.Rows[0]["CFDIRFCEMISOR"].ToString();
                cfdi.CfdiRSocReceptor = dt.Rows[0]["CFDIRSOCRECEPTOR"].ToString();
                cfdi.CfdiRfcReceptor = dt.Rows[0]["CFDIRFCRECEPTOR"].ToString();
                cfdi.CfdiFecha = Convert.ToDateTime(dt.Rows[0]["CFDIFECHA"]);
                cfdi.CfdiTotal = Convert.ToDouble(dt.Rows[0]["CFDITOTAL"]);
                cfdi.CfdiEmail = dt.Rows[0]["CFDIEMAIL"].ToString();
                cfdi.CfdiEsActivo = dt.Rows[0]["CFDIESACTIVO"].ToString();
                cfdi.CfdiEmailEnviado = Convert.ToByte(dt.Rows[0]["CFDIEMAILENVIADO"]);
                cfdi.CfdiIPdf = (byte[])dt.Rows[0]["CFDIPDF"];
                cfdi.CfdiIXml = (byte[])dt.Rows[0]["CFDIXML"];
                cfdi.CfdiProcesado1Pdf = Convert.ToByte(dt.Rows[0]["CFDIPROCESADO1PDF"]);
                cfdi.CfdiProcesado1Xml = Convert.ToByte(dt.Rows[0]["CFDIPROCESADO1XML"]);
                cfdi.CfdiUrlPdf = dt.Rows[0]["CFDIURLPDF"].ToString();
                cfdi.CfdiUrlXml = dt.Rows[0]["CFDIURLXML"].ToString();
                cfdi.CfdiFechaProcesadoPdf = Convert.ToDateTime(dt.Rows[0]["CFDIFECHAPROCESADOPDF"]);
                cfdi.CfdiFechaProcesadoXml = Convert.ToDateTime(dt.Rows[0]["CFDIFECHAPROCESADOXML"]);
            }
            if (cfdi != null)
            {
                return cfdi;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Esta función obtiene un Cfdi por folio fiscal
        /// </summary>
        /// <param name="foliofiscal">Folio fiscal del Cfdi</param>
        /// <returns>Cfdi que coincide con el folio fiscal</returns>
        [HttpGet, Route("api/cfdi/folio={foliofiscal}")]
        public dynamic GetPorFolio(string foliofiscal)
        {
            SqlDataAdapter da = new SqlDataAdapter("procMRGFECFDIsRecuperacionCFDIs", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@accion", 3);
            da.SelectCommand.Parameters.AddWithValue("@CFDIFOLIOFISCAL", SqlDbType.VarChar).Value = foliofiscal;

            DataTable dt = new DataTable();
            da.Fill(dt);
            CFDI cfdi = new CFDI();
            if (dt.Rows.Count > 0)
            {
                cfdi.CfdiId = dt.Rows[0]["CFDIID"].ToString();
                cfdi.CfdiFolioFiscal = dt.Rows[0]["CFDIFOLIOFISCAL"].ToString();
                cfdi.CfdiSerie = dt.Rows[0]["CFDISERIE"].ToString();
                cfdi.CfdiRSocEmisor = dt.Rows[0]["CFDIRSOCEMISOR"].ToString();
                cfdi.CfdiRfcEmisor = dt.Rows[0]["CFDIRFCEMISOR"].ToString();
                cfdi.CfdiRSocReceptor = dt.Rows[0]["CFDIRSOCRECEPTOR"].ToString();
                cfdi.CfdiRfcReceptor = dt.Rows[0]["CFDIRFCRECEPTOR"].ToString();
                cfdi.CfdiFecha = Convert.ToDateTime(dt.Rows[0]["CFDIFECHA"]);
                cfdi.CfdiTotal = Convert.ToDouble(dt.Rows[0]["CFDITOTAL"]);
                cfdi.CfdiEmail = dt.Rows[0]["CFDIEMAIL"].ToString();
                cfdi.CfdiEsActivo = dt.Rows[0]["CFDIESACTIVO"].ToString();
                cfdi.CfdiEmailEnviado = Convert.ToByte(dt.Rows[0]["CFDIEMAILENVIADO"]);
                cfdi.CfdiIPdf = (byte[])dt.Rows[0]["CFDIPDF"];
                cfdi.CfdiIXml = (byte[])dt.Rows[0]["CFDIXML"];
                cfdi.CfdiProcesado1Pdf = Convert.ToByte(dt.Rows[0]["CFDIPROCESADO1PDF"]);
                cfdi.CfdiProcesado1Xml = Convert.ToByte(dt.Rows[0]["CFDIPROCESADO1XML"]);
                cfdi.CfdiUrlPdf = dt.Rows[0]["CFDIURLPDF"].ToString();
                cfdi.CfdiUrlXml = dt.Rows[0]["CFDIURLXML"].ToString();
                cfdi.CfdiFechaProcesadoPdf = Convert.ToDateTime(dt.Rows[0]["CFDIFECHAPROCESADOPDF"]);
                cfdi.CfdiFechaProcesadoXml = Convert.ToDateTime(dt.Rows[0]["CFDIFECHAPROCESADOXML"]);
            }
            if (cfdi != null)
            {
                return cfdi;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Esta función obtiene los Cfdi por filtros de fecha inicio y fecha final y/o RFC de emisor y/o RFC de receptor
        /// </summary>
        /// <param name="rfcemisor">RFC del Emisor del Cfdi</param>
        /// <param name="rfcreceptor">RFC del Receptor del Cfdi</param>
        /// <param name="fechainicio">Fecha a tomar de inicio para la creación del Cfdi</param>
        /// <param name="fechafin">Fecha a tomar de fin para la creación del Cfdi</param>
        /// <returns></returns>
        [HttpGet, Route("api/cfdi/filtrar")]
        public List<CFDI> GetPorRfc([FromUri] string fechainicio, [FromUri] string fechafin, 
            [FromUri] string rfcemisor = "", [FromUri] string rfcreceptor = "")
        {
            SqlDataAdapter da = new SqlDataAdapter("procMRGFECFDIsRecuperacionCFDIs", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@accion", 4);
            da.SelectCommand.Parameters.AddWithValue("@CFDIRFCEMISOR", SqlDbType.VarChar).Value = rfcemisor;
            da.SelectCommand.Parameters.AddWithValue("@CFDIRFCRECEPTOR", SqlDbType.VarChar).Value = rfcreceptor;
            da.SelectCommand.Parameters.AddWithValue("@CFDIFECHAINICIO", SqlDbType.DateTime).Value = fechainicio;
            da.SelectCommand.Parameters.AddWithValue("@CFDIFECHAFIN", SqlDbType.DateTime).Value = fechafin;

            DataTable dt = new DataTable();
            da.Fill(dt);
            List<CFDI> lstCfdi = new List<CFDI>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CFDI cfdi = new CFDI();
                    cfdi.CfdiId = dt.Rows[i]["CFDIID"].ToString();
                    cfdi.CfdiFolioFiscal = dt.Rows[i]["CFDIFOLIOFISCAL"].ToString();
                    cfdi.CfdiSerie = dt.Rows[i]["CFDISERIE"].ToString();
                    cfdi.CfdiRSocEmisor = dt.Rows[i]["CFDIRSOCEMISOR"].ToString();
                    cfdi.CfdiRfcEmisor = dt.Rows[i]["CFDIRFCEMISOR"].ToString();
                    cfdi.CfdiRSocReceptor = dt.Rows[i]["CFDIRSOCRECEPTOR"].ToString();
                    cfdi.CfdiRfcReceptor = dt.Rows[i]["CFDIRFCRECEPTOR"].ToString();
                    cfdi.CfdiFecha = Convert.ToDateTime(dt.Rows[i]["CFDIFECHA"]);
                    cfdi.CfdiTotal = Convert.ToDouble(dt.Rows[i]["CFDITOTAL"]);
                    cfdi.CfdiEmail = dt.Rows[i]["CFDIEMAIL"].ToString();
                    cfdi.CfdiEsActivo = dt.Rows[i]["CFDIESACTIVO"].ToString();
                    cfdi.CfdiEmailEnviado = Convert.ToByte(dt.Rows[i]["CFDIEMAILENVIADO"]);
                    cfdi.CfdiIPdf = (byte[])dt.Rows[i]["CFDIPDF"];
                    cfdi.CfdiIXml = (byte[])dt.Rows[i]["CFDIXML"];
                    cfdi.CfdiProcesado1Pdf = Convert.ToByte(dt.Rows[i]["CFDIPROCESADO1PDF"]);
                    cfdi.CfdiProcesado1Xml = Convert.ToByte(dt.Rows[i]["CFDIPROCESADO1XML"]);
                    cfdi.CfdiUrlPdf = dt.Rows[i]["CFDIURLPDF"].ToString();
                    cfdi.CfdiUrlXml = dt.Rows[i]["CFDIURLXML"].ToString();
                    cfdi.CfdiFechaProcesadoPdf = Convert.ToDateTime(dt.Rows[i]["CFDIFECHAPROCESADOPDF"]);
                    cfdi.CfdiFechaProcesadoXml = Convert.ToDateTime(dt.Rows[i]["CFDIFECHAPROCESADOXML"]);

                    lstCfdi.Add(cfdi);
                }
            }
            if (lstCfdi.Count > 0)
            {
                return lstCfdi;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Esta función recibe el Cfdi y lo guarda.
        /// </summary>
        /// <param name="factura">Json representativo de un Cfdi a registrar</param>
        /// <returns>Datos del Cfdi registrado</returns>
        public dynamic Post([FromBody] CfdiMulti factura)
        {
            try
            {
                var cfdi = facturama.Cfdis.Create(factura);

                var pdf = facturama.Cfdis.GetFile(cfdi.Id, CfdiLiteService.FileFormat.Pdf);
                var xml = facturama.Cfdis.GetFile(cfdi.Id, CfdiLiteService.FileFormat.Xml);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "procMRGFECFDIsCrear";
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue("@CFDIID", SqlDbType.VarChar).Value = cfdi.Id;
                cmd.Parameters.AddWithValue("@CFDIFOLIOFISCAL", SqlDbType.VarChar).Value = cfdi.Complement.TaxStamp.Uuid;
                cmd.Parameters.AddWithValue("@CFDISERIE", SqlDbType.VarChar).Value = cfdi.Serie;
                cmd.Parameters.AddWithValue("@CFDIRSOCEMISOR", SqlDbType.VarChar).Value = cfdi.Issuer.TaxName;
                cmd.Parameters.AddWithValue("@CFDIRFCEMISOR", SqlDbType.VarChar).Value = cfdi.Issuer.Rfc;
                cmd.Parameters.AddWithValue("@CFDIRSOCRECEPTOR", SqlDbType.VarChar).Value = cfdi.Receiver.Name;
                cmd.Parameters.AddWithValue("@CFDIRFCRECEPTOR", SqlDbType.VarChar).Value = cfdi.Receiver.Rfc;
                cmd.Parameters.AddWithValue("@CFDIFECHA", SqlDbType.DateTime).Value = cfdi.Date;
                cmd.Parameters.AddWithValue("@CFDITOTAL", SqlDbType.Money).Value = cfdi.Total;
                cmd.Parameters.AddWithValue("@CFDIEMAIL", SqlDbType.VarChar).Value = cfdi.Issuer.Email;
                cmd.Parameters.AddWithValue("@CFDIESACTIVO", SqlDbType.VarChar).Value = cfdi.Status;
                cmd.Parameters.AddWithValue("@CFDIEMAILENVIADO", SqlDbType.Bit).Value = cfdi.SendMail;
                cmd.Parameters.AddWithValue("@CFDIPDF", SqlDbType.VarBinary).Value = Convert.FromBase64String(pdf.Content);
                cmd.Parameters.AddWithValue("@CFDIXML", SqlDbType.VarBinary).Value = Convert.FromBase64String(xml.Content);
                cmd.Parameters.AddWithValue("@CFDIPROCESADO1PDF", SqlDbType.Bit).Value = 1;
                cmd.Parameters.AddWithValue("@CFDIPROCESADO1XML", SqlDbType.Bit).Value = 1;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return cfdi;
            }
            catch (FacturamaException ex)
            {
                return ($"Error: ", ex.Message);
            }
            catch (Exception ex)
            {
                return ($"Error inesperado: ", ex.Message);
            }
        }

    }
}
