using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ChkListCursos.Acceso
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        String patron = "CLCURSOSUNIDEH";
        protected void BtnIngresar_Click(object sender, EventArgs e) {
            String conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection sqlConectar = new SqlConnection(conectar);
            SqlCommand cmd = new SqlCommand("ValidarUsuario", sqlConectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Connection.Open();
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 150).Value = tbUsuario.Text;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = tbPassword.Text;
            cmd.Parameters.Add("@Patron", SqlDbType.VarChar, 50).Value = patron;
            SqlDataReader dr=cmd.ExecuteReader();
            if (dr.Read())
            {
                //Agregar sesion de usuario
                Session["UsuarioLogueado"] = tbUsuario.Text;
                Response.Redirect("../Secciones_trabajador/Menu.aspx");
            }
            else {
                lblError.Text = "Usuario o contraseña incorrectos";
            }
            cmd.Connection.Close();

        }
    }
}