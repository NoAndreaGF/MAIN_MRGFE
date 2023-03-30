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
        [Required(ErrorMessage = "El campo RFC Emisor es obligatorio.")]
        [StringLength(50)]
        [Display(Name = "RFC Emisor")]
        public string EmisorRfc { get; set; }

        /// <summary>
        /// Atributo Razón Socail del Emisor
        /// </summary>
        [Required(ErrorMessage = "El campo Razón Social es obligatorio.")]
        [StringLength(500)]
        [Display(Name = "Razón Social")]
        public string EmisorRazSocial { get; set; }

        /// <summary>
        /// Atributo Estatus del Emisor
        /// </summary>
        [Required(ErrorMessage = "El campo Estatus es obligatorio.")]
        [StringLength(50)]
        [Display(Name = "Estatus")]
        public string EmisorEstatus { get; set; }

        /// <summary>
        /// Atributo Regimen Fiscal del Emisor
        /// </summary>
        [Required(ErrorMessage = "El campo Régimen Fiscal es obligatorio.")]
        [StringLength(50)]
        [Display(Name = "Régimen Fiscal")]
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
        [Required(ErrorMessage = "El campo Correo es obligatorio.")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "El correo electrónico ingresado no es válido.")]
        //[EmailAddress(ErrorMessage = "El correo electrónico ingresado no es válido.")] ALTERNATIVA SIMPLE -> Acepta juan@juan como valida
        [StringLength(100)]
        [Display(Name = "Correo")]
        public string EmisorCorreo { get; set; }

        /// <summary>
        /// Atributo de Logo URL del Emisor
        /// </summary>
        [StringLength(500)]
        public string EmisorLogoUrl { get; set; }

        /// <summary>
        /// Atributo de Código Postal del Emisor
        /// </summary>
        [Required(ErrorMessage = "El campo Código Postal es obligatorio.")]
        [StringLength(20)]
        [Display(Name = "Código Postal")]
        public string EmisorCodPostal { get; set; }

        /// <summary>
        /// Atributo de Municipio del Emisor
        /// </summary>
        [Required(ErrorMessage = "El campo Municipio es obligatorio.")]
        [StringLength(100)]
        [Display(Name = "Municipio")]
        public string EmisorMunicipio { get; set; }

        /// <summary>
        /// Atributo de Estado del Emisor
        /// </summary>
        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        [StringLength(50)]
        [Display(Name = "Estado")]
        public string EmisorEstado { get; set; }

        /// <summary>
        /// Atributo de Colonia del Emisor
        /// </summary>
        [Required(ErrorMessage = "El campo Colonia es obligatorio.")]
        [StringLength(100)]
        [Display(Name = "Colonia")]
        public string EmisorColonia { get; set; }

        /// <summary>
        /// Atributo de Calle del Emisor
        /// </summary>
        [Required(ErrorMessage = "El campo Calle es obligatorio.")]
        [StringLength(100)]
        [Display(Name = "Calle")]
        public string EmisorCalle { get; set; }

        /// <summary>
        /// Atributo de Número Exterior del Emisor
        /// </summary>
        [StringLength(30)]
        [Display(Name = "No. Exterior")]
        public string EmisorNoExterior { get; set; }

        /// <summary>
        /// Atributo de Número Interior del Emisor
        /// </summary>
        [StringLength(30)]
        [Display(Name = "No. Interior")]
        public string EmisorNoInterior { get; set; }

        /// <summary>
        /// Atributo de Folio Inicial del Emisor
        /// </summary>
        [StringLength(50)]
        [Display(Name = "Folio Inicial")]
        public string EmisorFolioInic { get; set; }
    }
}