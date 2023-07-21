<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="abmTurnos.aspx.cs" Inherits="clinicaMedica.Pages.abmTurnos" %>
<%@ Import Namespace="Dominio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/usuario.css" rel="stylesheet" />
    <link href="../Css/abmTurnos.css" rel="stylesheet" />
    <script defer src="abmTurnos.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
<div class="container contenedor-grid my-4">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
    <div class="contenedor-activo">
        <div class="mb-3 ancho">
            <asp:DropDownList ID="ambTurnos_dropListEstado" DataTextField="estado" CssClass="form-select" runat="server" OnSelectedIndexChanged="ambTurnos_listEstado_selChanged" AutoPostBack="true" ></asp:DropDownList>
        </div>
    </div>
    
    
    <div class="contenedor-buscadores">
        <%
            Rol rolAux = new Rol();
            rolAux = (Rol)Session["currentRol"] != null ? (Rol)Session["currentRol"] : null;

            if (rolAux != null && rolAux.permisosModificarTurno == true)
            {
        %>
        <div class="mb-3 ancho">
            <asp:Label ID="lblambTurnos_dropListMed" for="ambTurnos_dropListMed" class="form-label" runat="server">Medico</asp:Label>
            <asp:DropDownList ID="ambTurnos_dropListMed"  DataTextField="nombreYApellido" CssClass="form-select" runat="server"></asp:DropDownList>
        </div>
        <div class="mb-3 ancho">
            <label for="ambTurnos_dropListPac" class="form-label">Paciente</label>
            <asp:DropDownList ID="ambTurnos_dropListPac" DataTextField="nombreYApellido" CssClass="form-select" runat="server"></asp:DropDownList>
        </div>
        <%
            }
            %>
        <div class="mb-3 ancho ">
            <label for="ambTurnos_inputFecha" class="form-label">Fecha</label>
            <asp:TextBox ID="ambTurnos_inputFecha" CssClass="form-control" Placeholder="Ej. formato 23/8/1990" runat="server"></asp:TextBox>
            <asp:Button Text="HOY" ID="TurnosHoy" CssClass="btn btn-success" runat="server" OnClick="mostrarTurnosHoy_Click" />
        </div>
    </div>
    <div class="contenedor-botonBuscar mb-3">
        <asp:Button Text="BUSCAR" CssClass="btn btn-secondary" ID="ambTurnos_buttonBsc" runat="server" OnClick="BuscarTurnos" />
    </div>
        <%
            if (rolAux != null && rolAux.permisosModificarTurno == true)
            {
        %>
        <asp:GridView ID="GridAbmTurnos" runat="server" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table" AllowSorting="true">
        <HeaderStyle CssClass="cabecera"/>
        <Columns>
            <asp:BoundField HeaderText="Paciente" DataField="paciente.nombreYApellido" />
            <asp:BoundField HeaderText="Medico" DataField="medico.nombreYApellido" />
            <asp:BoundField HeaderText="Fecha y Hora" DataField="fechaYHora" />
            <asp:BoundField HeaderText="Estado" DataField="estado.estado" />
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# "/pages/cargarTurno.aspx?id=" + Eval("id") +"&idEditar=" + Eval("id") %>'>
                       <i class="fa-solid fa-eye" title="ver"></i>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# "/pages/cargarTurno.aspx?idEditar=" + Eval("id") +"&mod=2" %>'>
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
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# "/pages/ABMTurnos.aspx?id=" + Eval("id")%>'>
                       <i class="fa-solid fa-prescription"></i>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
        <div>
            <a href='<%# "/pages/cargarTurno.aspx?id=" + Eval("id") + "&idEditar=" +  Eval("id")%>' class="btn btn-success">AGREGAR</a></div>

        <%
            }
            else
            {
        %>
        
        <asp:GridView ID="GridAbmTurnos2" runat="server" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table" AllowSorting="true">
        <HeaderStyle CssClass="cabecera"/>
        <Columns>
            <asp:BoundField HeaderText="Paciente" DataField="paciente.nombreYApellido" />
            <asp:BoundField HeaderText="Medico" DataField="medico.nombreYApellido" />
            <asp:BoundField HeaderText="Fecha y Hora" DataField="fechaYHora" />
            <asp:BoundField HeaderText="Estado" DataField="estado.estado" />
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# "/pages/cargarTurno.aspx?id=" + Eval("id") +"&idEditar=" + Eval("id") %>'>
                       <i class="fa-solid fa-eye" title="ver"></i>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# "/pages/ABMTurnos.aspx?id=" + Eval("id")%>'>
                       <i class="fa-solid fa-prescription"></i>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
        <%
            }
            %>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>

    <!-- Modal -->
<div class="modal fade" id="obsMedModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="exampleModalLabel">Observaciones / Diagnostico</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
          <asp:TextBox ID="diagnostico" CssClass="form-control" rows="5" runat="server" TextMode="MultiLine" />
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <asp:Button Text="GRABAR" ID="grabarDiagnostico" CssClass="btn btn-primary" runat="server" OnClick="grabarDiagnostico_Click" />
      </div>
    </div>
  </div>
</div>
</asp:Content>
