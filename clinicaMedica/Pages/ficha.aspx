<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ficha.aspx.cs" Inherits="clinicaMedica.Pages.ficha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/ficha.css" rel="stylesheet" />
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
                <label for="AltaUsuario_fecNac" class="form-label">Fecha de nacimiento</label>
                <asp:TextBox runat="server" CssClass="form-control" id="AltaUsuario_fecNac"/>
            </div>
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Direccion</label>
                <asp:TextBox runat="server" CssClass="form-control" id="AltaUsuario_dire"/>
            </div>
            <div class="mb-3">
                <label for="AltaUsuario_loc" class="form-label">Localidad</label>
                <asp:TextBox runat="server" CssClass="form-control" id="AltaUsuario_loc"/>
            </div>
            <select class="form-select mb-3" aria-label="Default select example">
                <option selected>Elige un rol</option>
                <option value="1">Paciente</option>
                <option value="2">Medico</option>
                <option value="3">Operador</option>
            </select>
            <select class="form-select mb-3" aria-label="Default select example">
                <option selected>Elige una Especialidad</option>
                <option value="1">Clinico</option>
                <option value="2">Odontologo</option>
                <option value="3">Terapeuta</option>
            </select>
            <button class="btn btn-primary mb-3">ACEPTAR</button>
        </div>
    </div>
</asp:Content>
