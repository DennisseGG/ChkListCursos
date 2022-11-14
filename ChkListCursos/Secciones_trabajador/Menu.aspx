<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="ChkListCursos.Secciones_trabajador.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblBienvenida" runat="server" Text="" CssClass="h3"></asp:Label>
    <p><button href="https://asp.net" heigth="1000 "class="btn btn-primary col-12"> <img src="https://static.vecteezy.com/system/resources/previews/001/200/145/non_2x/books-png.png" height="80" width="100"/> <br/> Ver cursos disponibles &raquo;</button></p>
    <p ><button onclick="location.href='RegistroAcurso.aspx';" heigth="1000 " class="btn btn-primary col-12"> <img src="https://cdn-icons-png.flaticon.com/512/3534/3534139.png" height="80" width="90"/> <br /> Registrarme en curso »</button></p>
    <p><button href="https://asp.net" heigth="1000 " class="btn btn-primary col-12"> <img src="https://cdn-icons-png.flaticon.com/512/2912/2912780.png" height="80" width="100"/> <br /> Mis cursos &raquo;</button></p>
    <p><button href="https://asp.net" heigth="1000 " class="btn btn-primary col-12" ID="BtnCerrar3" runat="server" Text="Cerrar sesion" onserverclick="BtnCerrar_Click"> <img src="https://www.pngall.com/wp-content/uploads/10/Power-Off-Logo-PNG.png" height="80" width="100"/> <br /> Cerrar secion &raquo;</button></p>
    
</asp:Content>

