using System;
using System.Collections.Generic;
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
            Response.Redirect("../AccesoTrabajador/Login.aspx");
        }
    }
}