<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FichaRoles.aspx.cs" Inherits="clinicaMedica.Pages.FichaRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../Css/ficha.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center">ABM Roles</h1>
    <div class="container formFicha my-2">
        <div class="imagen-user">
            <img src="./../Assets/images/Roles.png" alt="Alternate Text" /></div>
        <div class="formulario">
            <div class="mb-2">
                <label for="Rol_codigo" class="form-label">Id</label>
                <asp:TextBox runat="server" CssClass="form-control" id="Rol_codigo"/>
            </div>
            <div class="mb-2">
                <label for="Rol_rol" class="form-label">Codigo</label>
                <asp:TextBox runat="server" CssClass="form-control" id="Rol_rol"/>
            </div>
            <div class="mb-2">
                <asp:Button Text="AGREGAR" CssClass="btn btn-primary mb-3" ID="AltaRoles_agregar" runat="server" OnClick="AltaRoles_agregar_Click" />
            </div>
            <div class="mb-2">
                <asp:Button Text="CANCELAR" CssClass="btn btn-danger mb-3" ID="AltaRol_cancelar" runat="server" OnClick="AltaRoles_cancelar_Click" />
            </div>
        </div>
    </div>
</asp:Content>