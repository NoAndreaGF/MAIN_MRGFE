using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [StringLength(50)]
        public string CamposMiId { get; set; }

        /// <summary>
        /// Atributo Campo de un Campo Mirage
        /// </summary>
        [Required]
        [StringLength(100)]
        public string CamposMiCampo { get; set; }

        /// <summary>
        /// Atributo Etiqueta de un Campo Mirage
        /// </summary>
        [Required]
        [StringLength(500)]
        public string CamposMiEtiqueta { get; set; }

        /// <summary>
        /// Atributo Tipo de Dato de un Campo Mirage
        /// </summary>
        [Required]
        [StringLength(100)]
        public string CamposMiTipoDato { get; set; }

        /// <summary>
        /// Atributo Arreglo de un Campo Mirage
        /// </summary>
        [Required]
        [Range(0, 1, ErrorMessage = "El campo debe ser un bit")]
        public byte CamposMiArreglo1 { get; set; }

        /// <summary>
        /// Atributo Version de un Campo Mirage
        /// </summary>
        [Required]
        [StringLength(100)]
        public string CamposMiVersion { get; set; }

        /// <summary>
        /// Atributo Obligatorio de un Campo Mirage
        /// </summary>
        [Required]
        [Range(0, 1, ErrorMessage = "El campo debe ser un bit")]
        public byte CamposMiObliga1 { get; set; }
    }
}