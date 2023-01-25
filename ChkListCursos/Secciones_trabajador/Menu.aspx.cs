using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursos.Secciones_trabajador
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"] != null)
            {
                String usuariologueado = Session["UsuarioLogueado"].ToString();
                lblBienvenida.Text = "Bienvenido " + usuariologueado;
            }
            else {
                Response.Redirect("../AccesoTrabajador/Login.aspx");
            }
        }

        protected void BtnCerrar_Click(object sender, EventArgs e) {
            Session.Remove("UsuarioLogueado");

            var page = HttpContext.Current.Handler as Page;

            Response.Redirect(page.GetRouteUrl("Default", new { Controller = "Home", Action = "Index" }), false);
        }

        protected void Disponbles_Click(object sender, EventArgs e) {
            Response.Redirect("cursosdisponibles.aspx");
        }
        
        protected void BtnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Opciones_busqueda.aspx");
        }

        protected void BtnMisCursos_Click(object sender, EventArgs e)
        {
            Response.Redirect("MisCursos.aspx");
        }
    }
}