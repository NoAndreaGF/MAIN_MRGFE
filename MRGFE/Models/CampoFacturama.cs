using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [StringLength(50)]
        public string CamposFaId { get; set; }

        /// <summary>
        /// Atributo Campo de un Campo Facturama
        /// </summary>
        [Required]
        [StringLength(100)]
        public string CamposFaCampo { get; set; }

        /// <summary>
        /// Atributo Etiqueta de un Campo Facturama
        /// </summary>
        [Required]
        [StringLength(500)]
        public string CamposFaEtiqueta { get; set; }

        /// <summary>
        /// Atributo Tipo de Dato de un Campo Facturama
        /// </summary>
        [Required]
        [StringLength(100)]
        public string CamposFaTipoDato { get; set; }

        /// <summary>
        /// Atributo Arreglo de un Campo Facturama
        /// </summary>
        [Required]
        [Range(0, 1, ErrorMessage = "El campo debe ser un bit")]
        public byte CamposFaArreglo1 { get; set; }

        /// <summary>
        /// Atributo Version de un Campo Facturama
        /// </summary>
        [Required]
        [StringLength(100)]
        public string CamposFaVersion { get; set; }

        /// <summary>
        /// Atributo Obligatorio de un Campo Facturama
        /// </summary>
        [Required]
        [Range(0, 1, ErrorMessage = "El campo debe ser un bit")]
        public byte CamposFaObliga1 { get; set; }
    }
}