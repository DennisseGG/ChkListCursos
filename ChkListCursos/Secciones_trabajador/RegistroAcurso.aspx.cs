using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursos.Secciones_trabajador
{
    public partial class RegistroAcurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void VolverMenuTra_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }
}