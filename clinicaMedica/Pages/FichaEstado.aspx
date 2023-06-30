<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FichaEstado.aspx.cs" Inherits="clinicaMedica.Pages.FichaEstado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../Css/ficha.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center">ABM Estados</h1>
    <div class="container formFicha my-2">
        <div class="imagen-user">
            <img src="./../Assets/images/Estados.png" alt="Alternate Text" /></div>
        <div class="formulario">
            <div class="mb-2">
                <label for="Estados_codigo" class="form-label">Codigo</label>
                <asp:TextBox runat="server" CssClass="form-control" id="Estados_codigo"/>
            </div>
            <div class="mb-2">
                <label for="Estados_estado" class="form-label">Id</label>
                <asp:TextBox runat="server" CssClass="form-control" id="Estados_estado"/>
            </div>
            <div class="mb-2">
                <asp:Button Text="AGREGAR" CssClass="btn btn-primary mb-3" ID="Estado_agregar" runat="server" OnClick="Estado_agregar_Click" />
            </div>
            <div class="mb-2">
                <asp:Button Text="CANCELAR" CssClass="btn btn-danger mb-3" ID="Estado_cancelar" runat="server" OnClick="Estado_cancelar_Click" />
            </div>
        </div>
    </div>
</asp:Content>