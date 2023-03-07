using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRGFE.Models
{
    /// <summary>
    /// Modelo para Campo Mirage de acuerdo a la Base de Datos
    /// </summary>
    public class CampoMirage
    {
        /// <summary>
        /// Atributo Id de un Campo Mirage 
        /// </summary>
        public string CamposMiId { get; set; }

        /// <summary>
        /// Atributo Campo de un Campo Mirage
        /// </summary>
        public string CamposMiCampo { get; set; }

        /// <summary>
        /// Atributo Etiqueta de un Campo Mirage
        /// </summary>
        public string CamposMiEtiqueta { get; set; }

        /// <summary>
        /// Atributo Tipo de Dato de un Campo Mirage
        /// </summary>
        public string CamposMiTipoDato { get; set; }

        /// <summary>
        /// Atributo Arreglo de un Campo Mirage
        /// </summary>
        public byte CamposMiArreglo1 { get; set; }

        /// <summary>
        /// Atributo Version de un Campo Mirage
        /// </summary>
        public string CamposMiVersion { get; set; }

        /// <summary>
        /// Atributo Obligatorio de un Campo Mirage
        /// </summary>
        public byte CamposMiObliga1 { get; set; }
    }
}