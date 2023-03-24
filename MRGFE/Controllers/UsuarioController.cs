using MRGFE.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MRGFE.Controllers
{
    /// <summary>
    /// Controlador para Usuario
    /// </summary>
    public class V_UsuarioController : ApiController
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);

        /// <summary>
        /// Esta función recibe los datos de Usuario y los guarda
        /// </summary>
        /// <param name="usuario">Json representativo de un Usuario a registrar</param>
        /// <returns>Datos del Usuario registrado</returns>
        [HttpPost, Route("api/usuario")]
        public HttpResponseMessage PostUsuario([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                SqlCommand command = new SqlCommand("procMRGFEUsuario", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@accion", 1);
                command.Parameters.AddWithValue("@USUARIONOMBRE", SqlDbType.VarChar).Value = usuario.UsuarioNombre;
                command.Parameters.AddWithValue("@USUARIOPASSWORD", SqlDbType.VarChar).Value = usuario.UsuarioPassword;
                command.Parameters.AddWithValue("@USUARIOCORREO", SqlDbType.VarChar).Value = usuario.UsuarioCorreo;
                command.Parameters.AddWithValue("@USUARIOROL", SqlDbType.VarChar).Value = usuario.UsuarioRol;

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            return Request.CreateResponse(HttpStatusCode.Created, usuario);
        }

        /// <summary>
        /// Esta función recibe los datos de Usuario para actualizar el objeto según su Correo
        /// </summary>
        /// <param name="usuario">Json representativo de un Usuario a actualizar</param>
        /// <returns>Datos del Usuario actualizado</returns>
        [HttpPut, Route("api/usuario")]
        public HttpResponseMessage PutUsuario([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                SqlCommand command = new SqlCommand("procMRGFEUsuario", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@accion", 2);
                command.Parameters.AddWithValue("@USUARIONOMBRE", SqlDbType.VarChar).Value = usuario.UsuarioNombre;
                command.Parameters.AddWithValue("@USUARIOPASSWORD", SqlDbType.VarChar).Value = usuario.UsuarioPassword;
                command.Parameters.AddWithValue("@USUARIOCORREO", SqlDbType.VarChar).Value = usuario.UsuarioCorreo;
                command.Parameters.AddWithValue("@USUARIOCORREONVO", SqlDbType.VarChar).Value = usuario.UsuarioCorreoNvo;
                command.Parameters.AddWithValue("@USUARIOROL", SqlDbType.VarChar).Value = usuario.UsuarioRol;

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            return Request.CreateResponse(HttpStatusCode.OK, usuario);
        }

        /// <summary>
        /// Esta función elimina el Usuario correspondinete al Correo
        /// </summary>
        /// <param name="correo">Correo del Usuario a eliminar</param>
        [HttpDelete, Route("api/usuario/{correo}")]
        public void DeleteUsuario(string correo)
        {
            SqlCommand command = new SqlCommand("procMRGFEUsuario", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@accion", 3);
            command.Parameters.AddWithValue("@USUARIOCORREO", SqlDbType.VarChar).Value = correo;

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Esta función obtiene los Usuarios
        /// </summary>
        /// <returns>Lista de los Usuarios</returns>
        [HttpGet, Route("api/usuario")]
        public HttpResponseMessage GetUsuarios()
        {
            SqlDataAdapter da = new SqlDataAdapter("procMRGFEUsuario", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@accion", 4);

            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Usuario> lstUsuario = new List<Usuario>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Usuario usuario = new Usuario();
                    usuario.UsuarioNombre = dt.Rows[i]["USUARIONOMBRE"].ToString();
                    usuario.UsuarioCorreo = dt.Rows[i]["USUARIOCORREO"].ToString();
                    usuario.UsuarioRol = dt.Rows[i]["USUARIOROL"].ToString();

                    lstUsuario.Add(usuario);
                }
            }
            if (lstUsuario.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, lstUsuario);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No hay registros en este momento.");
        }

        /// <summary>
        /// Esta función verifica al Usuario
        /// </summary>
        /// <returns>Datos del Usuario</returns>
        [HttpGet, Route("autenticar")]
        public HttpResponseMessage Autenticar([FromUri] string correo, [FromUri] string password)
        {
            SqlDataAdapter da = new SqlDataAdapter("procMRGFEUsuario", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@accion", 5);
            da.SelectCommand.Parameters.AddWithValue("@USUARIOCORREO", SqlDbType.VarChar).Value = correo;
            da.SelectCommand.Parameters.AddWithValue("@USUARIOPASSWORD", SqlDbType.VarChar).Value = password;

            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Usuario> lstUsuario = new List<Usuario>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Usuario usuario = new Usuario();
                    usuario.UsuarioNombre = dt.Rows[i]["USUARIONOMBRE"].ToString();
                    usuario.UsuarioCorreo = dt.Rows[i]["USUARIOCORREO"].ToString();
                    usuario.UsuarioRol = dt.Rows[i]["USUARIOROL"].ToString();

                    lstUsuario.Add(usuario);
                }
            }
            if (lstUsuario.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, lstUsuario);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No hay registros en este momento.");
        }
    }
}
