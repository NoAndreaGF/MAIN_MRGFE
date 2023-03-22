using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRGFE.Models
{
    /// <summary>
    /// Modelo para Usuario de acuerdo a la Base de Datos
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Atributo Nombre del Usuario
        /// </summary>
        [Required]
        [StringLength(30)]
        public string UsuarioNombre { get; set; }

        /// <summary>
        /// Atributo Password del Usuario
        /// </summary>
        [Required]
        [StringLength(30)]
        public string UsuarioPassword { get; set; }

        /// <summary>
        /// Atributo Correo del Usuario
        /// </summary>
        [Required]
        [StringLength(50)]
        public string UsuarioCorreo { get; set; }

        /// <summary>
        /// Atributo Correo Nuevo del Usuario
        /// </summary>
        [StringLength(50)]
        public string UsuarioCorreoNvo { get; set; }

        /// <summary>
        /// Atributo Rol del Usuario
        /// </summary>
        [Required]
        [StringLength(20)]
        public string UsuarioRol { get; set; }
    }
}