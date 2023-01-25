<%@ Page Title="Opciones de busqueda" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="Opciones_busqueda.aspx.cs" Inherits="ChkListCursos.Secciones_trabajador.Opciones_busqueda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <p><button href="" heigth="1000 " class="btn btn-primary col-12" ID="BtnBuscar" runat="server" Text="Cursos Disponibles" onserverclick="BtnBuscador_Click"> <img src="https://cdn-icons-png.flaticon.com/512/971/971108.png" height="80" width="100"/> <br /> Buscar curso &raquo;</button></p>
    <p><button href="" heigth="1000 " class="btn btn-primary col-12" ID="BtnSeleccionar" runat="server" Text="Registro a curso" onserverclick="BtnSeleccionar_Click"> <img src="https://cdn-icons-png.flaticon.com/512/1598/1598638.png" height="80" width="100"/> <br /> Seleccionar curso &raquo;</button></p>
    <p><button href="" heigth="1000 " class="btn btn-primary col-12" ID="BtnVolver" runat="server" Text="Cerrar sesion" onserverclick="BtnVolver_Click"> <img src="https://cdn-icons-png.flaticon.com/512/17/17699.png" height="80" width="100"/> <br /> Volver a menu &raquo;</button></p>
      
</asp:Content>
