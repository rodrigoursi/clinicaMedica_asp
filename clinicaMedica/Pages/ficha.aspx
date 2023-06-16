<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ficha.aspx.cs" Inherits="clinicaMedica.Pages.ficha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/ficha.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container formFicha">
        <div class="mb-3">
            <label for="exampleFormControlInput1" class="form-label">id</label>
            <input type="number" class="form-control" id="exampleFormControlInput1">
        </div>
        <div class="mb-3">
            <label for="exampleFormControlInput1" class="form-label">codigo</label>
            <input type="number" class="form-control" id="exampleFormControlInput2" >
        </div>
        <div class="mb-3">
            <label for="exampleFormControlInput1" class="form-label">contraseña</label>
            <input type="password" class="form-control" id="exampleFormControlInput9" >
        </div>
        <div class="mb-3">
            <label for="exampleFormControlInput1" class="form-label">nombre</label>
            <input type="text" class="form-control" id="exampleFormControlInput3" >
        </div>
        <div class="mb-3">
            <label for="exampleFormControlInput1" class="form-label">Email address</label>
            <input type="email" class="form-control" id="exampleFormControlInput4" >
        </div>
        <div class="mb-3">
            <label for="exampleFormControlInput1" class="form-label">tipo documento</label>
            <input type="text" class="form-control" id="exampleFormControlInput5">
        </div>
        <div class="mb-3">
            <label for="exampleFormControlInput1" class="form-label">documento</label>
            <input type="text" class="form-control" id="exampleFormControlInput6">
        </div>
        <div class="mb-3">
            <label for="exampleFormControlInput1" class="form-label">fecha de nacimiento</label>
            <input type="date" class="form-control" id="exampleFormControlInput10">
        </div>
        <div class="mb-3">
            <label for="exampleFormControlInput1" class="form-label">direccion</label>
            <input type="text" class="form-control" id="exampleFormControlInput7">
        </div>
        <div class="mb-3">
            <label for="exampleFormControlInput1" class="form-label">localidad</label>
            <input type="text" class="form-control" id="exampleFormControlInput8">
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
        <button class="btn btn-primary">ACEPTAR</button>
    </div>
</asp:Content>
