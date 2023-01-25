<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="ChkListCursos.Secciones_trabajador.Registrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <asp:Label ID="titlename" runat="server" Text="" CssClass="h5"><Strong>Se esta registrando a: </Strong></asp:Label><br>
        <asp:Label ID="lbname" runat="server" Text="" style="font-weight:100; font-size:xx-large; color:dimgray;" CssClass="a"></asp:Label><br>
        <asp:Label ID="a" runat="server" Text="" CssClass="h5"><Strong>a </Strong></asp:Label><br>
        <asp:Label ID="titleCurso" runat="server" Text="" CssClass="h5"><Strong>Curso: </Strong></asp:Label><br>
        <asp:Label ID="lbcurso" runat="server" Text="" style="font-weight:100; font-size:xx-large; color:dimgray;" CssClass="a"></asp:Label><br>
        <asp:Label ID="titleIntructor" runat="server" Text="" CssClass="h5"><Strong>Instructor: </Strong></asp:Label><br>
        <asp:Label ID="lbinstructor" runat="server" Text="" style="font-weight:100; font-size:xx-large; color:dimgray;" CssClass="a"></asp:Label><br>
        <asp:Label ID="titleDirigidoa" runat="server" Text="" CssClass="h5"><Strong>Dirigido a: </Strong></asp:Label><br>
        <asp:Label ID="lbdirigidoa" runat="server" Text="" style="font-weight:100; font-size:xx-large; color:dimgray;" CssClass="a"></asp:Label><br>
        <asp:Label ID="titleLugares" runat="server" Text="" CssClass="h5"><Strong>Capacidad:</Strong></asp:Label><br>
        <asp:Label ID="lblugaresdisp" runat="server" Text="" style="font-weight:100; font-size:xx-large; color:dimgray;" CssClass="a"></asp:Label><br>
        <asp:Label ID="titleFecha" runat="server" Text="" CssClass="h5"><Strong>Fecha:</Strong></asp:Label><br>
        <asp:Label ID="lbfecha" runat="server" Text="" style="font-weight:100; font-size:xx-large; color:dimgray;" CssClass="a"></asp:Label><br>
        <asp:Label ID="titleHora" runat="server" Text="" CssClass="h5"><Strong>Hora: </Strong></asp:Label><br>
        <asp:Label ID="lbhora" runat="server" Text="" style="font-weight:100; font-size:xx-large; color:dimgray;" CssClass="a"></asp:Label><br>
        <asp:Label ID="titleDuracion" runat="server" Text="" CssClass="h5"><Strong>Duracion: </Strong></asp:Label><br>
        <asp:Label ID="lbduracion" runat="server" Text="" style="font-weight:100; font-size:xx-large; color:dimgray;" CssClass="a"></asp:Label><br>
        <asp:Button type="button" text="Cancelar" class="btn btn-secondary" runat="server" onClick="Cancelar" OnClientClick='return confirm ("¿Estas seguro de cancelar tu registro a este curso?");'></asp:Button>
        <asp:Button type="button" text="Registarme en curso" class="btn btn-primary" runat="server" onClick="confirmar_registro" OnClientClick='return confirm ("¿Estas seguro de registrarte a este curso?");'></asp:Button>
    </div>
    <script src="JavaTrabajador.js"></script>
 </asp:Content>
