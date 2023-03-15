using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRGFE.Models
{
    /// <summary>
    /// Modelo para Emisor de acuerdo a la Base de Datos
    /// </summary>
    public class Emisor
    {
        /// <summary>
        /// Atributo RFC del Emisor
        /// </summary>
        [Required]
        [StringLength(50)]
        public string EmisorRfc { get; set; }

        /// <summary>
        /// Atributo Razón Socail del Emisor
        /// </summary>
        [Required]
        [StringLength(500)]
        public string EmisorRazSocial { get; set; }

        /// <summary>
        /// Atributo Estatus del Emisor
        /// </summary>
        [Required]
        [StringLength(50)]
        public string EmisorEstatus { get; set; }

        /// <summary>
        /// Atributo Regimen Fiscal del Emisor
        /// </summary>
        [Required]
        [StringLength(50)]
        public string EmisorRegFiscal { get; set; }

        /// <summary>
        /// Atributo ID Externo 1 del Emisor
        /// </summary>
        [StringLength(50)]
        public string EmisorIdExterno1 { get; set; }

        /// <summary>
        /// Atributo ID Externo 2 del Emisor
        /// </summary>
        [StringLength(50)]
        public string EmisorIdExterno2 { get; set; }

        /// <summary>
        /// Atributo ID Externo 3 del Emisor
        /// </summary>
        [StringLength(50)]
        public string EmisorIdExterno3 { get; set; }

        /// <summary>
        /// Atributo Correo del Emisor
        /// </summary>
        [Required]
        [StringLength(100)]
        public string EmisorCorreo { get; set; }

        /// <summary>
        /// Atributo de Logo URL del Emisor
        /// </summary>
        [StringLength(500)]
        public string EmisorLogoUrl { get; set; }

        /// <summary>
        /// Atributo de Código Postal del Emisor
        /// </summary>
        [Required]
        [StringLength(20)]
        public string EmisorCodPostal { get; set; }

        /// <summary>
        /// Atributo de Municipio del Emisor
        /// </summary>
        [Required]
        [StringLength(100)]
        public string EmisorMunicipio { get; set; }

        /// <summary>
        /// Atributo de Estado del Emisor
        /// </summary>
        [Required]
        [StringLength(50)]
        public string EmisorEstado { get; set; }

        /// <summary>
        /// Atributo de Colonia del Emisor
        /// </summary>
        [Required]
        [StringLength(100)]
        public string EmisorColonia { get; set; }

        /// <summary>
        /// Atributo de Calle del Emisor
        /// </summary>
        [Required]
        [StringLength(100)]
        public string EmisorCalle { get; set; }

        /// <summary>
        /// Atributo de Número Exterior del Emisor
        /// </summary>
        [StringLength(30)]
        public string EmisorNoExterior { get; set; }

        /// <summary>
        /// Atributo de Número Interior del Emisor
        /// </summary>
        [StringLength(30)]
        public string EmisorNoInterior { get; set; }

        /// <summary>
        /// Atributo de Folio Inicial del Emisor
        /// </summary>
        [StringLength(50)]
        public string EmisorFolioInic { get; set; }
    }
}