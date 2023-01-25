using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Razor.Parser.SyntaxTree;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursos.Secciones_trabajador
{
    public partial class Buscador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"] == null){
                Response.Redirect("../AccesoTrabajador/Login.aspx");
            }
        }

        [WebMethod]
        public static List<string> GetEmp(string empdetails) {
            /*
            List<string> emp = new List<string>();
            string con = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection sqlcon= new SqlConnection(con);
           // string sqlquery = string.Format("SELECT NombreCurso FROM Cursos_dispo where NombreCurso LIKE '%(0)%'", empdetails);
            string sqlquery = string.Format("SELECT NombreCurso FROM Cursos_dispo where NombreCurso LIKE '%@search%'");
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            sqlcom.Parameters.AddWithValue("@search", empdetails);
            SqlDataReader sdr = sqlcom.ExecuteReader();
            while (sdr.Read()) {
                emp.Add(sdr.GetString(0));
            }
            sqlcon.Close();
            return emp;
            */

            List<string> emp = new List<string>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            con.Open();

            string sql = "SELECT NombreCurso FROM Cursos_dispo where NombreCurso LIKE '%' + @search +'%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@search", empdetails);

            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                emp.Add(sdr.GetString(0));
            }
            con.Close();

            return emp;

        }

        public static string busqueda = "";
        protected void busqueda_Click(object sender, EventArgs e)
        {
            busqueda = palabra.Value;
            Response.Redirect("cursosdisponibles.aspx");
        }

        protected void VolverMenubus_Click(object sender, EventArgs e)
        {
            Response.Redirect("Opciones_busqueda.aspx");
        }
    }
}