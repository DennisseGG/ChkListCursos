using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursos.Secciones_trabajador
{
    public partial class Opciones_busqueda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"] == null)
            {
                Response.Redirect("../AccesoTrabajador/Login.aspx");
            }
        }

        protected void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroAcurso.aspx");
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void BtnBuscador_Click(object sender, EventArgs e)
        {
            Response.Redirect("Buscador.aspx");
        }
    }
}