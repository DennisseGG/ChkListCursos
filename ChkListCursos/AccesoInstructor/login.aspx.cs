using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ChkListCursos.AccesoInstructor
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        String patron = "ChkListCursos";
        protected void btnIniciar_clic(object sender, EventArgs e)
        {
            String conectar = ConfigurationManager.ConnectionStrings["newconexion"].ConnectionString;
            SqlConnection sqlConectar = new SqlConnection(conectar);
            SqlCommand cmd = new SqlCommand("ValidarUsuario", sqlConectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Connection.Open();
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 150).Value = usuario.Text;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = password.Text;
            cmd.Parameters.Add("@Patron", SqlDbType.VarChar, 50).Value = patron;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //Agregar sesion de usuario
                Session["UsuarioLogueado"] = usuario.Text;
                Response.Redirect("../Secciones_trabajador/Menu.aspx");
            }
            else
            {
                //lblError.Text = "Usuario o contraseña incorrectos";
            }
            cmd.Connection.Close();

        }
    }
}