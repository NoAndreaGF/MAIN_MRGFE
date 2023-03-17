using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRGFE.Models
{
    /// <summary>
    /// Modelo para Campo Proveedor de acuerdo a la Base de Datos
    /// </summary>
    public class CampoProveedor
    {
        /// <summary>
        /// Atributo Id de un Campo Proveedor 
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CamposPrId { get; set; }

        /// <summary>
        /// Atributo Proveedor de un Campo Proveedor
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CamposPrProveedor { get; set; }

        /// <summary>
        /// Atributo Campo de un Campo Proveedor
        /// </summary>
        [Required]
        [StringLength(100)]
        public string CamposPrCampo { get; set; }

        /// <summary>
        /// Atributo Etiqueta de un Campo Proveedor
        /// </summary>
        [Required]
        [StringLength(500)]
        public string CamposPrEtiqueta { get; set; }

        /// <summary>
        /// Atributo Tipo de Dato de un Campo Proveedor
        /// </summary>
        [Required]
        [StringLength(100)]
        public string CamposPrTipoDato { get; set; }

        /// <summary>
        /// Atributo Arreglo de un Campo Proveedor
        /// </summary>
        [Required]
        [Range(0, 1, ErrorMessage = "El campo debe ser un bit")]
        public byte CamposPrArreglo1 { get; set; }

        /// <summary>
        /// Atributo Version de un Campo Proveedor
        /// </summary>
        [Required]
        [StringLength(100)]
        public string CamposPrVersion { get; set; }

        /// <summary>
        /// Atributo Obligatorio de un Campo Proveedor
        /// </summary>
        [Required]
        [Range(0, 1, ErrorMessage = "El campo debe ser un bit")]
        public byte CamposPrObliga1 { get; set; }
    }
}