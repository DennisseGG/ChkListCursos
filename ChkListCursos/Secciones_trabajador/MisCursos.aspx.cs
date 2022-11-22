using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using ChkListCursos.Models;
using System.ComponentModel;

namespace ChkListCursos.Secciones_trabajador
{
    public partial class MisCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                using (SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
                {

                    Guid myGuid = new Guid("7fa7c1e5-d9b5-44b0-8556-5aa5b0701e4f");
                    string myGuidString = "7fa7c1e5-d9b5-44b0-8556-5aa5b0701e4f";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "EstatusCursos";
                    cmd.Connection = cone;
                    cone.Open();
                    cmd.Parameters.Add("@UuidEmpleado", SqlDbType.UniqueIdentifier).Value = myGuid;
                    GVMisCursos.DataSource = cmd.ExecuteReader();
                    GVMisCursos.DataBind();
                    
                }
            }

        }

        protected void VolverMenuTra_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }
}