using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChkListCursos.Models;
using WebGrease.Activities;

namespace ChkListCursos.Secciones_trabajador
{
    public partial class Registrar : System.Web.UI.Page
    {
        public static string reg_nom;
        public static string reg_fecha;
        public static string reg_hora;

        public static string id_curso = "";
        public static string nom_curso = "";
        public static string nom_user = "";

        public static int page = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"] == null)
            {
                Response.Redirect("../AccesoTrabajador/Login.aspx");
            }

            if (!IsPostBack){
                string id="";

                if (cursosdisponibles.id_global.ToString() != "0"){
                    id = cursosdisponibles.id_global.ToString();
                    cursosdisponibles.id_global = 0;
                    page = 1;
                }
                else {
                    if (cursosdisponibles.id_global_bus.ToString() != "0") {
                        id = cursosdisponibles.id_global_bus.ToString();
                        cursosdisponibles.id_global_bus = 0;
                        page = 2;
                    }
                    else {
                        if (RegistroAcurso.id_global.ToString()!="0") {
                            id = RegistroAcurso.id_global.ToString();
                            RegistroAcurso.id_global = 0;
                            page = 3;
                        }
                    }
                }

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
                {
                    cn.Open();

                    string sql = "SELECT UuidCursod, NombreCurso, DirigidoA, UuidInstructor, Capacidad, FechaInicio, Hora, Duracion FROM Cursos_dispo WHERE idCurso_dis =@id";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();


                    if (reader.Read())
                    {
                        string usuariologueado = Session["UsuarioLogueado"].ToString();
                        string nombre_usuario = get_nom_usuario(usuariologueado);
                        string nombre_instructor = get_nom_instructor(Convert.ToString(reader["UuidInstructor"]));

                        id_curso = Convert.ToString(reader["UuidCursod"]);
                        nom_curso = Convert.ToString(reader["NombreCurso"]);
                        nom_user = nombre_usuario;

                        reg_nom = nombre_usuario;
                        reg_fecha = Convert.ToString(reader["FechaInicio"]);
                        reg_hora = Convert.ToString(reader["Hora"]);

                        lbname.Text = nombre_usuario;
                        lbcurso.Text = Convert.ToString(reader["NombreCurso"]);
                        lbinstructor.Text = nombre_instructor;
                        lbdirigidoa.Text = Convert.ToString(reader["DirigidoA"]);
                        lblugaresdisp.Text = Convert.ToString(reader["Capacidad"]);
                        lbfecha.Text = Convert.ToString(reader["FechaInicio"]);
                        lbhora.Text = Convert.ToString(reader["Hora"]);
                        lbduracion.Text = Convert.ToString(reader["Duracion"]);
                    }

                }

            }
            
        }

        protected string get_nom_instructor(string id)
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
                    string nombre = Convert.ToString(reader["NombreInstructor"]);
                    return nombre;
                }
                else
                {
                    return "no existe";
                }

            }
        }

        public static string id_empleado ="";
        protected string get_nom_usuario(string correo)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                cn.Open();

                string sql = "SELECT UuidEmpleado, NombreEmpleado FROM Empleado WHERE Email =@email";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@email", correo);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    id_empleado = Convert.ToString(reader["UuidEmpleado"]);
                    string nombre = Convert.ToString(reader["NombreEmpleado"]);
                    return nombre;
                }
                else
                {
                    return "no existe";
                }

            }
        }

        protected void confirmar_registro(object sender, EventArgs e)
        {

            Guid curso = new Guid(id_curso);
            Guid empleado = new Guid(id_empleado);

            string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection sqlConectar = new SqlConnection(conectar);
            SqlCommand cmd = new SqlCommand("Comprobar_no_registro", sqlConectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Connection.Open();
            cmd.Parameters.Add("@UuidCursod", SqlDbType.UniqueIdentifier).Value = curso;
            cmd.Parameters.Add("@UuidEmpleado", SqlDbType.UniqueIdentifier).Value = empleado;
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read()){
                //Registro permitido
                if (Restar_lugar_disponible()){
                    //Capacidad a curso disminuida
                    if (Realizar_registro_a_curso()){
                        //Registro correcto
                        Response.Redirect("registroCorrecto.aspx");
                    }
                    else {
                        string JavaScript = "msj_error_registrar_a_curso();";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", JavaScript, true);
                    }
                }else {
                    string JavaScript = "msj_error_disminuir_capacidad();";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", JavaScript, true);
                }
            }
            else{
                string JavaScript = "msj_error_registro_a_curso();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", JavaScript, true);
            }
            cmd.Connection.Close();
        }

        protected bool Restar_lugar_disponible()
        {
            Guid curso = new Guid(id_curso);

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Actualizar_lugares_disponibles_curso";
                cmd.Parameters.Add("@UuidCursod", SqlDbType.UniqueIdentifier).Value = curso;
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }

        }

        protected bool Realizar_registro_a_curso()
        {
            Guid curso = new Guid(id_curso);
            Guid empleado = new Guid(id_empleado);

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Registrar_empleado_a_curso";
                cmd.Parameters.Add("@UuidCursod", SqlDbType.UniqueIdentifier).Value = curso;
                cmd.Parameters.Add("@UuidEmpleado", SqlDbType.UniqueIdentifier).Value = empleado;
                cmd.Parameters.Add("@NombreCurso", SqlDbType.VarChar).Value = nom_curso;
                cmd.Parameters.Add("@NombreEmpleado", SqlDbType.VarChar).Value = nom_user;
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
        }

        protected void Cancelar(object sender, EventArgs e)
        {
            if (page == 1){
                Response.Redirect("cursosdisponibles.aspx");
            }
            else{
                if (page == 2){
                    Response.Redirect("Buscador.aspx");
                }
                else{
                    if (page == 3){
                        Response.Redirect("RegistroAcurso.aspx");
                    }
                }
            }
            
        }
    }
}