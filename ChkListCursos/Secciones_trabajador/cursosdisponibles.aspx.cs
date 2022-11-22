using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;



namespace ChkListCursos.Secciones_trabajador
{
    public partial class cursosdisponibles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                using (SqlConnection cone=new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString)) {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SelectCurDiponibles";
                    cmd.Connection = cone;
                    cone.Open();
                    gvdcurso.DataSource = cmd.ExecuteReader();
                    gvdcurso.DataBind();
                }
            }

        }

         protected void VolverMenuTra_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }
}