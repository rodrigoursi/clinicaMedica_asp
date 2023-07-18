<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="abmTurnos.aspx.cs" Inherits="clinicaMedica.Pages.abmTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/usuario.css" rel="stylesheet" />
    <link href="../Css/abmTurnos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container contenedor-grid my-4">
    <div class="contenedor-activo">
        <div class="mb-3 ancho">
            <asp:DropDownList ID="ambTurnos_dropListActivo" DataTextField="estado" CssClass="form-select" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="contenedor-buscadores">
        <div class="mb-3 ancho">
            <label for="ambTurnos_dropListMed" class="form-label">Medico</label>
            <asp:DropDownList ID="ambTurnos_dropListMed"  CssClass="form-select" runat="server"></asp:DropDownList>
        </div>
        <div class="mb-3 ancho">
            <label for="ambTurnos_dropListPac" class="form-label">Paciente</label>
            <asp:DropDownList ID="ambTurnos_dropListPac" CssClass="form-select" runat="server"></asp:DropDownList>
        </div>
        <div class="mb-3 ancho">
            <label for="ambTurnos_inputFecha" class="form-label">Fecha</label>
            <asp:TextBox ID="ambTurnos_inputFecha" CssClass="form-control" Placeholder="Ej. formato 23/8/1990" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="contenedor-botonBuscar mb-3">
        <asp:Button Text="BUSCAR" CssClass="btn btn-secondary" ID="ambTurnos_buttonBsc" runat="server" />
    </div>
        <asp:GridView ID="GridAbmLocalidades" runat="server" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table">
        <HeaderStyle CssClass="cabecera"/>
        <Columns>
            <asp:BoundField HeaderText="Paciente" DataField="paciente.nombreYApellido" />
            <asp:BoundField HeaderText="Medico" DataField="medico.nombreYApellido" />
            <asp:BoundField HeaderText="Fecha y Hora" DataField="fechaYHora" />
            <asp:BoundField HeaderText="Estado" DataField="estado.estado" />
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# "/pages/cargarTurno.aspx?id=" + Eval("id") +"&mod=1" %>'>
                       <i class="fa-solid fa-eye" title="ver"></i>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# "/pages/cargarTurno.aspx?id=" + Eval("id") +"&mod=2" %>'>
                       <i class="fa-solid fa-file-pen" title="editar"></i>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# "/pages/ABMTurnos.aspx?id=" + Eval("id") + "&mod=3" %>'
                     onclick="return confirm('¿Estás seguro de que deseas eliminar este registro?')">
                        <i class="fa-solid fa-trash" title="borrar"></i>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
        <div><a href="/pages/FichaLocalidades.aspx?id=0&mod=0" class="btn btn-success">AGREGAR</a></div>
    </div>
</asp:Content>
