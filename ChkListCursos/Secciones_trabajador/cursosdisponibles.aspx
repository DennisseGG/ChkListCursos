<%@ Page Title="cursos disponibles" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="cursosdisponibles.aspx.cs" Inherits="ChkListCursos.Secciones_trabajador.cursosdisponibles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="modal fade" ID="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
      <div id="Modal_mas" class="modal-dialog" > 
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="staticBackdropLabel">Informacion de curso</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <a id="prueba"></a>
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
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Registarme en curso</button>
          </div>
        </div>
      </div>
    </div>

    <h1>Cursos Diponibles</h1>

    <div class="jumbotron" align="center">
        <asp:GridView ID="gvdcurso" runat="server" cellpadding="3" OnRowCommand="Vermas_Click" >
            <Columns>
                <asp:TemplateField  HeaderText="Mas informacion" >
                    <ItemTemplate >
                        <asp:Button type="button" ID="Vermas" Text="Ver mas" HeaderText="Mas informacion" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop" runat="server" CommandName="Mostrar"  CommandArgument='<%# Bind("ID") %>' autopostback="true"/> 
                    </ItemTemplate>
                </asp:TemplateField>  
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
            
        </asp:GridView>
    </div></br>

    <p><button href="https://asp.net" heigth="1000 " class="btn btn-primary col-4" ID="Volver" runat="server" Text="Cerrar sesion" onserverclick="VolverMenuTra_Click"> <img src="https://cdn-icons-png.flaticon.com/512/17/17699.png" height="40" width="50"/> <br /> Volver a menu &raquo;</button></p>
    
    <script src="JavaTrabajador.js"></script>
   
    
</asp:Content>
