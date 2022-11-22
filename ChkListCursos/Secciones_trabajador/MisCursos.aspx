<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="MisCursos.aspx.cs" Inherits="ChkListCursos.Secciones_trabajador.MisCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Mis cursos</h1>

    <div class="jumbotron">
        <asp:GridView ID="GVMisCursos" runat="server" AutoGenerateColumns="true" cellpadding="05"/>

    </div></br>

    <p><button href="https://asp.net" heigth="1000 " class="btn btn-primary col-4" ID="Volver" runat="server" Text="Cerrar sesion" onserverclick="VolverMenuTra_Click"> <img src="https://cdn-icons-png.flaticon.com/512/17/17699.png" height="40" width="50"/> <br /> Volver a menu &raquo;</button></p>
        
</asp:Content>
