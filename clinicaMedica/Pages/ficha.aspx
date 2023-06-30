﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ficha.aspx.cs" Inherits="clinicaMedica.Pages.ficha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/ficha.css" rel="stylesheet" />
    <script defer src="ficha.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center">ALTA DE USUARIO</h1>
    <div class="container formFicha my-2">
        <div class="imagen-user">
            <img src="./../Assets/images/usermas.png" alt="Alternate Text" /></div>
        <div class="formulario">
            <div class="mb-3">
                <label for="AltaUsuario_id" class="form-label">Id</label>
                <asp:TextBox runat="server" CssClass="form-control" id="AltaUsuario_id"/>
            </div>
            <div class="mb-3">
                <label for="AltaUsuario_codigo" class="form-label">Codigo</label>
                <asp:TextBox runat="server" CssClass="form-control" id="AltaUsuario_codigo"/>
            </div>
            <div class="mb-3">
                <label for="AltaUsuario_contra" class="form-label">Contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" id="AltaUsuario_contra"/>
            </div>
            <div class="mb-3">
                <label for="AltaUsuario_repeat" class="form-label">Repetir contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" id="AltaUsuario_repeat"/>
            </div>
            <div class="mb-3">
                <label for="AltaUsuario_nombre" class="form-label">Nombre y apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" id="AltaUsuario_nombre"/>
            </div>
            <div class="mb-3">
                <label for="AltaUsuario_correo" class="form-label">Correo electronico</label>
                <asp:TextBox runat="server" CssClass="form-control" id="AltaUsuario_correo"/>
            </div>
            <div class="mb-3">
                <label for="AltaUsuario_tipoDoc" class="form-label">Tipo de documento</label>
                <asp:TextBox runat="server" CssClass="form-control" id="AltaUsuario_tipoDoc"/>
            </div>
            <div class="mb-3">
                <label for="AltaUsuario_doc" class="form-label">Documento</label>
                <asp:TextBox runat="server" CssClass="form-control" id="AltaUsuario_doc"/>
            </div>
            <div class="mb-3">
                <label for="AltaUsuario_dire" class="form-label">Direccion</label>
                <asp:TextBox runat="server" CssClass="form-control" id="AltaUsuario_dire"/>
            </div>
            <div class="mb-3">
                <label for="AltaUsuario_loc" class="form-label">Localidad</label>
                <asp:DropDownList ID="AltaUsuario_loc" CssClass="form-select mb-3" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3 text-center">
                <label for="AltaUsuario_fecNac" class="form-label">Fecha de nacimiento</label>
                <asp:Calendar runat="server" ID="AltaUsuario_fecNac" />
            </div>
            <asp:DropDownList ID="ficha_rol" CssClass="form-select mb-3" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="ficha_esp" CssClass="form-select mb-3" runat="server"></asp:DropDownList>
            <asp:Button Text="AGREGAR" CssClass="btn btn-primary mb-3" ID="AltaUsuario_agregar" runat="server" OnClick="AltaUsuario_agregar_Click" />
        </div>
    </div>

    <!-- Modal -->
    <div class="modal modal_cargarLoc_user" id="modal_cargarLoc_user" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Agregar localidad</h5>
                    <button type="button" class="btn-close" id="modal_cargarLoc_X" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <label for="AltaUsuario_altaLoc" class="form-label">Ingrese nombre de localidad:</label>
                        <asp:TextBox runat="server" CssClass="form-control" id="AltaUsuario_altaLoc"/>
                    </div>
                    <asp:DropDownList ID="AltaUsuario_prov" CssClass="form-select mb-3" runat="server"></asp:DropDownList>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" id="modal_cargarLoc_cerrar">Cerrar</button>
                    <asp:Button Text="AGREGAR" CssClass="btn btn-primary" ID="AltaUsuario_btnAgregar_loc" OnClick="AltaUsuario_btnAgregar_loc_Click" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
