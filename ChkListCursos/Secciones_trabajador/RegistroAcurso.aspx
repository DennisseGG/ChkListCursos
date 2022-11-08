<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="RegistroAcurso.aspx.cs" Inherits="ChkListCursos.Secciones_trabajador.RegistroAcurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form>
  
  <div class="form-group">
    <label for="exampleFormControlSelect1">Selecciona el curso deseado</label>
    <select class="form-control" id="exampleFormControlSelect1">
      <option>Curso 1</option>
      <option>Curso 2</option>
      <option>Curso 3</option>
      <option>Curso 4</option>
      <option>Curso 5</option>
    </select>
  </div><br/>

  <button type="submit" class="btn btn-primary">Registrarme en curso</button>
</form><br/><br/>
</asp:Content>
