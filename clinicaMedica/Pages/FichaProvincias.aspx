<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FichaProvincias.aspx.cs" Inherits="clinicaMedica.Pages.FichaProvincias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../Css/ficha.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center">ABM Provincias</h1>
    <div class="container formFicha my-2">
        <div class="imagen-user">
            <img src="./../Assets/images/geografia_Provincias.png" alt="Alternate Text" /></div>
        <div class="formulario">
            <div class="mb-2">
                <label for="Provincias_provincia" class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" id="Provincias_provincia"/>
            </div>
            <div>

            </div>
            <div class="mb-2">
                <asp:Button Text="AGREGAR" CssClass="btn btn-primary mb-3" ID="Provincia_agregar" runat="server" OnClick="Provincia_agregar_Click" />
            </div>
            <div class="mb-2">
                <asp:Button Text="CANCELAR" CssClass="btn btn-danger mb-3" ID="Provincia_cancelar" runat="server" OnClick="Provincia_cancelar_Click" />
            </div>
        </div>
    </div>
</asp:Content>