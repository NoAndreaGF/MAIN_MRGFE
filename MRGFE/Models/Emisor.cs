using System;
using System.Collections.Generic;
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
        public string EmisorRfc { get; set; }

        /// <summary>
        /// Atributo Razón Socail del Emisor
        /// </summary>
        public string EmisorRazSocial { get; set; }

        /// <summary>
        /// Atributo Estatus del Emisor
        /// </summary>
        public string EmisorEstatus { get; set; }

        /// <summary>
        /// Atributo Regimen Fiscal del Emisor
        /// </summary>
        public string EmisorRegFiscal { get; set; }

        /// <summary>
        /// Atributo Correo del Emisor
        /// </summary>
        public string EmisorCorreo { get; set; }

        /// <summary>
        /// Atributo de Logo URL del Emisor
        /// </summary>
        public string EmisorLogoUrl { get; set; }

        /// <summary>
        /// Atributo de Código Postal del Emisor
        /// </summary>
        public string EmisorCodPostal { get; set; }

        /// <summary>
        /// Atributo de Municipio del Emisor
        /// </summary>
        public string EmisorMunicipio { get; set; }

        /// <summary>
        /// Atributo de Estado del Emisor
        /// </summary>
        public string EmisorEstado { get; set; }

        /// <summary>
        /// Atributo de Colonia del Emisor
        /// </summary>
        public string EmisorColonia { get; set; }

        /// <summary>
        /// Atributo de Calle del Emisor
        /// </summary>
        public string EmisorCalle { get; set; }

        /// <summary>
        /// Atributo de Número Exterior del Emisor
        /// </summary>
        public string EmisorNoExterior { get; set; }

        /// <summary>
        /// Atributo de Número Interior del Emisor
        /// </summary>
        public string EmisorNoInterior { get; set; }

        /// <summary>
        /// Atributo de Folio Inicial del Emisor
        /// </summary>
        public string EmisorFolioInic { get; set; }
    }
}