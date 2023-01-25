using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChkListCursos.Models;

namespace ChkListCursos.Secciones_trabajador
{
    public partial class RegistroAcurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"] == null)
            {
                Response.Redirect("../AccesoTrabajador/Login.aspx");
            }

            if (!IsPostBack) {
                CargaCursos_combo();
            }

        }

        protected void VolverMenubus_Click(object sender, EventArgs e)
        {
            Response.Redirect("Opciones_busqueda.aspx");
        }

        public static int id_global = 0;
        protected void CargaCursos_combo()
        {

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                cn.Open();

                string sql = "SELECT idCurso_dis,NombreCurso FROM Cursos_dispo";
                SqlCommand cmd = new SqlCommand(sql, cn);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DDLCursos.DataSource = ds;
                DDLCursos.DataTextField = "NombreCurso";
                DDLCursos.DataValueField = "idCurso_dis";
                DDLCursos.DataBind();
                DDLCursos.Items.Insert(0, new ListItem("<Selecciona el curso deseado>", "0"));

            }

        }

        protected void Registrar(object sender, EventArgs e)
        {
            if (DDLCursos.Text == "0"){
                string JavaScript = "Selecciona_curso();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", JavaScript, true);
            }
            else {
                id_global = int.Parse(DDLCursos.Text);
                Response.Redirect("Registrar.aspx");
            }
            
        }

    }
}