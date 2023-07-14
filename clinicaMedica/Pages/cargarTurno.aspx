<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cargarTurno.aspx.cs" Inherits="clinicaMedica.Pages.cargarTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/cargarTurno.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <i class="fa-regular fa-calendar-days"></i>
        <h3 style="display:inline-block">Turnos</h3>
    </div>
    <p>Completa el siguiente formulario para reservar el turno</p>
    <hr />
    <h4>Datos del paciente</h4>
    <div class="formulario-turno mt-4">
        <div class="mb-3 subcontenedor">
            <div>
                <label for="cargarTurno_documento" class="form-label">Documento</label>
                <asp:TextBox runat="server" type="number" CssClass="form-control" id="cargarTurno_documento" />
            </div>
            <asp:Button Text="buscar" runat="server" class="btn btn-success" ID="buscarDoc" OnClick="buscarDoc_Click" />
        </div>
        <div class="mb-3">
            <label for="cargarTurno_documento" class="form-label">Paciente</label>
            <asp:TextBox runat="server" CssClass="form-control" id="cargarTurno_paciente" />
        </div>
        <div class="mb-3 subcontenedor">
            <div>
                <label for="cargaTurno_esp" class="form-label">Especialidad</label>
                <asp:DropDownList ID="cargaTurno_Esp" CssClass="form-select mb-3" runat="server" OnSelectedIndexChanged="cargaTurno_Esp_Changed" AutoPostBack="true" ></asp:DropDownList>
            </div>
            <div>
                <label for="cargaTurno_prof" class="form-label">Profesional</label>
                <asp:DropDownList ID="cargaTurno_prof" CssClass="form-select mb-3" runat="server" OnSelectedIndexChanged="cargaTurno_prof_Changed" AutoPostBack="true"></asp:DropDownList>
            </div>
        </div>
        <div class="mb-3">
            <div>
                <label for="cargaTurno_fecha" class="form-label">Fecha</label>
                <asp:DropDownList ID="cargaTurno_fecha" CssClass="form-select mb-3" runat="server" OnSelectedIndexChanged="cargaTurno_fecha_changed" AutoPostBack="true" ></asp:DropDownList>
            </div>
            <div>
                <label for="cargaTurno_hora" class="form-label">Hora</label>
                <asp:DropDownList ID="cargaTurno_hora" CssClass="form-select mb-3" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="mb-3">
            <label for="cargarTurno_mot" class="form-label">Motivo/s de la Consulta</label>
            <asp:TextBox runat="server" TextMode="MultiLine" id="cargarTurno_mot" CssClass="form-control" rows="3" />
        </div>
    </div>
</asp:Content>
