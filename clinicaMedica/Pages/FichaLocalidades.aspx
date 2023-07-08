<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FichaLocalidades.aspx.cs" Inherits="clinicaMedica.Pages.FichaLocalidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../Css/ficha.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center">ABM Localidades</h1>
    <div class="container formFicha my-2">
        <div class="imagen-user">
            <img src="./../Assets/images/geografia_Localidades.png" alt="Alternate Text" /></div>
        <div class="formulario">
            <div class="mb-2">
                <label for="Localidad_localidad" class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" id="Localidad_localidad"/>
            </div>
            <div class="mb-2">
                <label for="Localidad_provincia" class="form-label">Provincia</label>
                <asp:TextBox runat="server" CssClass="form-control" id="Localidad_provincia"/>
            </div>
            <div class="mb-2">
                <asp:Button Text="AGREGAR" CssClass="btn btn-primary mb-3" ID="Localidad_agregar" runat="server" OnClick="Localidad_agregar_Click" />
            </div>
            <div class="mb-2">
                <asp:Button Text="CANCELAR" CssClass="btn btn-danger mb-3" ID="Localidad_cancelar" runat="server" OnClick="Localidad_cancelar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
