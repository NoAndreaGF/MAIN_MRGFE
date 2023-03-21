using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRGFE.Models
{
    /// <summary>
    /// Modelo para CFDI de acuerdo a la Base de Datos
    /// </summary>
    public class CFDI
    {
        /// <summary>
        /// Atributo Id del CFDI.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CfdiId { get; set; }

        /// <summary>
        /// Atributo Folio Fiscal del CFDI.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CfdiFolioFiscal { get; set; }

        /// <summary>
        /// Atributo Serie del CFDI.
        /// </summary>
        [StringLength(10)]
        public string CfdiSerie { get; set; }

        /// <summary>
        /// Atributo Folio del CFDI.
        /// </summary>
        [Required]
        [StringLength(40)]
        public string CfdiFolio { get; set; }

        /// <summary>
        /// Atributo Tipo del CFDI.
        /// </summary>
        [Required]
        [StringLength(30)]
        public string CfdiTipo { get; set; }

        /// <summary>
        /// Atributo Razón Social de Emisor del CFDI.
        /// </summary>
        [Required]
        [StringLength(500)]
        public string CfdiRSocEmisor { get; set; }

        /// <summary>
        /// Atributo RFC de Emisor del CFDI.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CfdiRfcEmisor { get; set; }

        /// <summary>
        /// Atributo Razón Social de Receptor del CFDI.
        /// </summary>
        [Required]
        [StringLength(500)]
        public string CfdiRSocReceptor { get; set; }

        /// <summary>
        /// Atributo RFC de Receptor del CFDI.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CfdiRfcReceptor { get; set; }

        /// <summary>
        /// Atributo Fecha del CFDI.
        /// </summary>
        [Required]
        public DateTime CfdiFecha { get; set; }

        /// <summary>
        /// Atributo Total del CFDI.
        /// </summary>
        [Required]
        public double CfdiTotal { get; set; }

        /// <summary>
        /// Atributo Email de Emisor del CFDI.
        /// </summary>
        [StringLength(50)]
        public string CfdiEmail { get; set; }

        /// <summary>
        /// Atributo de Estado Activo del CFDI.
        /// </summary>
        [StringLength(50)]
        public string CfdiEsActivo { get; set; }

        /// <summary>
        /// Atributo Email enviado del CFDI.
        /// </summary>
        public byte CfdiEmailEnviado { get; set; }

        /// <summary>
        /// Atributo PDF del CFDI.
        /// </summary>
        public byte[] CfdiIPdf { get; set; }

        /// <summary>
        /// Atributo XML del CFDI.
        /// </summary>
        public byte[] CfdiIXml { get; set; }

        /// <summary>
        /// Atributo Estado de Procesado de PDF del CFDI.
        /// </summary>
        public byte CfdiProcesado1Pdf { get; set; }

        /// <summary>
        /// Atributo Estado de Procesado de XML del CFDI.
        /// </summary>
        public byte CfdiProcesado1Xml { get; set; }

        /// <summary>
        /// Atributo URL de PDF del CFDI.
        /// </summary>
        [StringLength(8000)]
        public string CfdiUrlPdf { get; set; }

        /// <summary>
        /// Atributo URL de XML del CFDI.
        /// </summary>
        [StringLength(8000)]
        public string CfdiUrlXml { get; set; }

        /// <summary>
        /// Atributo Fecha de Procesado de PDF del CFDI.
        /// </summary>
        public DateTime CfdiFechaProcesadoPdf { get; set; }

        /// <summary>
        /// Atributo Fecha de Procesado de XML del CFDI.
        /// </summary>
        public DateTime CfdiFechaProcesadoXml { get; set; }
    }
}