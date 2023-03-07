using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRGFE.Models
{
    /// <summary>
    /// Modelo para Campo Facturama de acuerdo a la Base de Datos
    /// </summary>
    public class CampoFacturama
    {
        /// <summary>
        /// Atributo Id de un Campo Facturama 
        /// </summary>
        public string CamposFaId { get; set; }

        /// <summary>
        /// Atributo Campo de un Campo Facturama
        /// </summary>
        public string CamposFaCampo { get; set; }

        /// <summary>
        /// Atributo Etiqueta de un Campo Facturama
        /// </summary>
        public string CamposFaEtiqueta { get; set; }

        /// <summary>
        /// Atributo Tipo de Dato de un Campo Facturama
        /// </summary>
        public string CamposFaTipoDato { get; set; }

        /// <summary>
        /// Atributo Arreglo de un Campo Facturama
        /// </summary>
        public byte CamposFaArreglo1 { get; set; }

        /// <summary>
        /// Atributo Version de un Campo Facturama
        /// </summary>
        public string CamposFaVersion { get; set; }

        /// <summary>
        /// Atributo Obligatorio de un Campo Facturama
        /// </summary>
        public byte CamposFaObliga1 { get; set; }
    }
}