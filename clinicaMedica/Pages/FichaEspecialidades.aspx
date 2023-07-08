<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FichaEspecialidades.aspx.cs" Inherits="clinicaMedica.Pages.FichaEspecialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="../Css/ficha.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center">ABM Especialidades</h1>
    <div class="container formFicha my-2">
        <div class="imagen-user">
            <img src="./../Assets/images/EspecialidadesMedicas.png" alt="Alternate Text" /></div>
        <div class="formulario">
            <div class="mb-2">
                <label for="Especialidad_codigo" class="form-label">Codigo</label>
                <asp:TextBox runat="server" CssClass="form-control" id="Especialidad_codigo"/>
            </div>
            <div class="mb-2">
                <label for="Especialidad_especialidad" class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" id="Especialidad_especialidad"/>
            </div>
            <div class="mb-2">
                <asp:Button Text="AGREGAR" CssClass="btn btn-primary mb-3" ID="AltaEspecialidad_agregar" runat="server" OnClick="AltaEspecialidad_agregar_Click" />
            </div>
            <div class="mb-2">
                <asp:Button Text="CANCELAR" CssClass="btn btn-danger mb-3" ID="AltaEspecialidad_cancelar" runat="server" OnClick="AltaEspecialidad_cancelar_Click" />
            </div>
        </div>
    </div>
</asp:Content>