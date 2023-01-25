using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Reflection;
using ChkListCursos.Models;
using System.Threading;
using System.Data.Common;
using System.Drawing;

namespace ChkListCursos.Secciones_trabajador
{
    public partial class cursosdisponibles : System.Web.UI.Page
    {

        public static string bus = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"] == null)
            {
                Response.Redirect("../AccesoTrabajador/Login.aspx");
            }

            if (!IsPostBack) {

                if (Buscador.busqueda != "") {
                    bus = Buscador.busqueda;
                    Buscador.busqueda = "";

                    using (SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "busquedaCursos";
                        cmd.Parameters.AddWithValue("@search", bus);
                        cmd.Connection = cone;
                        cone.Open();
                        gvdcurso.DataSource = cmd.ExecuteReader();
                        gvdcurso.DataBind();
                        cone.Close();
                    }
                }
                else {
                    using (SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SelectCurDiponibles";
                        cmd.Connection = cone;
                        cone.Open();
                        gvdcurso.DataSource = cmd.ExecuteReader();
                        gvdcurso.DataBind();
                        cone.Close();
                    }
                }
            }

        }

         protected void VolverMenuTra_Click(object sender, EventArgs e)
        {
            if (bus == ""){
                Response.Redirect("Menu.aspx");
            }
            else{
                bus = "";
                Response.Redirect("Buscador.aspx");
            }
            
        }


        public static int id_global = 0;
        public static int id_global_bus = 0;
        public static int id_previa;
        //System.Web.UI.WebControls.GridViewCommandEventArgs e
        protected void Vermas_Click(object sender, GridViewCommandEventArgs e)
        {
            int row = int.Parse(e.CommandArgument.ToString());
            //string id = gvdcurso.Rows[row-1].Cells[1].Text;

            if (e.CommandName == "Mostrar") {

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
                {
                    cn.Open();

                    string sql = "SELECT NombreCurso, DirigidoA, UuidInstructor, Capacidad, FechaInicio, Hora, Duracion FROM Cursos_dispo WHERE idCurso_dis =@id";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@id", row);

                    id_previa = row;

                    SqlDataReader reader = cmd.ExecuteReader();


                    if (reader.Read())
                    {
                        String nombre_instructor = get_nom_instructor(Convert.ToString(reader["UuidInstructor"]));

                        lbcurso.Text = Convert.ToString(reader["NombreCurso"]);
                        lbinstructor.Text = nombre_instructor;
                        lbdirigidoa.Text = Convert.ToString(reader["DirigidoA"]);
                        lblugaresdisp.Text = Convert.ToString(reader["Capacidad"]);
                        lbfecha.Text = Convert.ToString(reader["FechaInicio"]);
                        lbhora.Text = Convert.ToString(reader["Hora"]);
                        lbduracion.Text = Convert.ToString(reader["Duracion"]);
                    }

                }

                string JavaScript = "java();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", JavaScript, true);

            }

        }

        protected String get_nom_instructor(String id)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                cn.Open();

                string sql = "SELECT NombreInstructor FROM Instructor WHERE UuidInstructor =@id";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    String nombre = Convert.ToString(reader["NombreInstructor"]);
                    return nombre;
                }else {
                    return "no existe";
                }
                
            }
        }

        protected void Registrar(object sender, EventArgs e) 
        {
            if (bus == "") {
                id_global = id_previa;
            }else {
                id_global_bus = id_previa;
            }
            
            Response.Redirect("Registrar.aspx");
        }


     
    }
}