<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="Buscador.aspx.cs" Inherits="ChkListCursos.Secciones_trabajador.Buscador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js" integrity="sha256-xLD7nhI62fcsEZK2/v8LsBcb4lG7dgULkuXoXB/j91c=" crossorigin="anonymous"></script>
    <link rel="Stylesheet" href="https://releases.jquery.com/git/ui/jquery-ui-git.css" />

    

      <asp:Label ID="Label1" runat="server" Text="Escribe el curso a buscar:"></asp:Label><br />
    
    <div id="palat" style="display:none;">
        <input type="text" id="palabra" runat="server"/>
    </div>
    
    <div class="row">
        <div class="col-lg-10 offset-md-1">
             <input type="text" class="form-control" onkeyup="nameSearch()" id="searchBox" placeholder="Buscar..." autocomplete="off" spellcheck="false" style="border-radius: 25px;">
        </div>
        <div id="button" class="col-lg-1" style="display:">
            <p><button type="submit" class="btn btn-primary" runat="server" onserverclick="busqueda_Click" >Buscar</button></p><br />
        </div>

    </div><br />

    <div id="noresult" style="display:none;">
        <img src="https://cdn-icons-png.flaticon.com/512/6195/6195678.png" height="300" width="300"/><br><br><br>
        <h1>No hay resultados</h1>
    </div>

     <asp:Label ID="salida" runat="server" Text=""></asp:Label><br />
     

    
    

    
    <p><button href="https://asp.net" heigth="1000 " class="btn btn-primary col-4" ID="Volver" runat="server" Text="Volver" onserverclick="VolverMenubus_Click"> <img src="https://cdn-icons-png.flaticon.com/512/17/17699.png" height="40" width="50"/> <br /> Volver atras &raquo;</button></p>
 
    <script type="text/javascript">

        function nameSearch() {
            $(function () {
                $('#<%=palabra.ClientID%>').val($('#searchBox').val());
                $("#searchBox").autocomplete({
                    source: function (request, response) {
                        var param = { empdetails: $('#searchBox').val() };
                        $.ajax({
                            url: "Buscador.aspx/GetEmp",
                            data: JSON.stringify(param),
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                if (JSON.stringify(data) == '{"d":[]}') {
                                    mostrar();
                                } else {
                                    ocultar();
                                }
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item
                                     }
                                }))
                            },
                        });
                    },
                    select: function (event, ui) {
                        $('#<%=palabra.ClientID%>').val(ui.item.value);
                        //palabra = ui.item.value;
                        // $('#searchBox').val(ui.item.value);
                        //alert('Valor seleccionado: ' + ui.item.value);
                    },
                    minLength: 1
                });
            });
        }

        function mostrar() {
            div = document.getElementById('noresult');
            div.style.display = '';
            boton = document.getElementById('button');
            boton.style.display = 'none';
        }

        function ocultar() {
            div = document.getElementById('noresult');
            div.style.display = 'none';
            boton = document.getElementById('button');
            boton.style.display = '';
        }

    </script>
</asp:Content>
