<%@ Page Title="Registro a curso correcto" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="registroCorrecto.aspx.cs" Inherits="ChkListCursos.Secciones_trabajador.registroCorrecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div alingn="center">
        <asp:Label ID="nombre_user_registrado" runat="server" Text="" CssClass="h5"><Strong></Strong></asp:Label><br>
        <asp:Label ID="exitoso" runat="server" Text="" CssClass="h5"><Strong>Tu registro ha sido exitoso</Strong></asp:Label><br>
        <asp:Label ID="titleAsistencia" runat="server" Text="" style="font-weight:100; font-size:xx-large; color:dimgray;" CssClass="a">Deberas asistir el</asp:Label><br>
        <asp:Label ID="fechaAsistencia" runat="server" Text="" CssClass="h5"><Strong></Strong></asp:Label><br>
        <asp:Label ID="titleHoraAsistencia" runat="server" Text="" style="font-weight:100; font-size:xx-large; color:dimgray;" CssClass="a">a las</asp:Label><br>
        <asp:Label ID="horaAsistencia" runat="server" Text="" CssClass="h5"><Strong></Strong></asp:Label><br><br><br>
        <img src="https://esoft-ibm.gevents.co/images/check.png" height="300" width="300"/><br><br><br>
        <button type="button" class="btn btn-primary" runat="server" onServerClick="Volver_menu" >Volver a menu</button>
    </div>
</asp:Content>
