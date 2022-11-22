using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ChkListCursos.Models;
using System.Data.SqlClient;
using System.Data;


namespace ChkListCursos.Controllers
{
    public class LoginInstructorController : Controller
    {

        static string cadena = "Data Source=DESKTOP-1BBMTKP;Initial Catalog=ChkListCursos; Integrated Security=true";

        // GET: LoginInstructor
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(IsntructorClase oUsuario)
        {
            bool registrado;
            string mensaje;
            if (oUsuario.clave == oUsuario.ConfirmarClave)
            {
                oUsuario.clave = ConvertirSha256(oUsuario.clave);
            }
            else
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarAdministrador",cn);
                cmd.Parameters.AddWithValue("correo",oUsuario.correo);
                cmd.Parameters.AddWithValue("clave",oUsuario.clave);
                cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();
                registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            ViewData["Mensaje"] = mensaje;
            if (registrado)
            {
                return RedirectToAction("Login", "LoginInstructor");
            }
            else
            {
                return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(IsntructorClase oUsuario)
        {
            oUsuario.clave = ConvertirSha256(oUsuario.clave);
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("validarUsuario", cn);
                cmd.Parameters.AddWithValue("correo", oUsuario.correo);
                cmd.Parameters.AddWithValue("clave", oUsuario.clave);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                oUsuario.IdInstructor = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            if (oUsuario.IdInstructor != 0)
            {
                Session["usuario"] = oUsuario;
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }
        }

        public static string ConvertirSha256(string texto)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create()) 
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));
                foreach (byte b in result)
                {
                    Sb.Append(b.ToString("x2"));
                }
            }
            return Sb.ToString();
        }

    }
}