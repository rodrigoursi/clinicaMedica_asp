<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="clinicaMedica.Pages.usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/usuario.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        string rolId = Request.QueryString["rolId"].ToString();
    %>
    <div class="container contenedor-grid my-4">
        <asp:GridView ID="GridAbmUser" runat="server" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table">
        <HeaderStyle CssClass="cabecera"/>
        <Columns>
            <asp:BoundField HeaderText="codigo" DataField="codigoUsuario" />
            <asp:BoundField HeaderText="nombre" DataField="nombreYApellido" />
            <asp:BoundField HeaderText="email" DataField="emailUsuario" />
            <asp:BoundField HeaderText="tipo de documento" DataField="tipoDeDocumento" />
            <asp:BoundField HeaderText="numero de documento" DataField="numeroDeDocumento" />
            <asp:BoundField HeaderText="Rol" DataField="rol.rol" />
            <asp:BoundField HeaderText="Especialidad" DataField="especialidad.especialidad" />
            <asp:BoundField HeaderText="Localidad" DataField="localidad.localidad" />
            <asp:BoundField HeaderText="Provincia" DataField="localidad.provincia.provincia" />

            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# "/pages/ficha.aspx?id=" + Eval("id") + "&idEditar=" + Eval("id") %>'>
                       <i class="fa-solid fa-eye" title="ver"></i>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# "ficha.aspx?idEditar=" + Eval("id") %>'>
                       <i class="fa-solid fa-file-pen" title="editar"></i>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# "/pages/usuario.aspx?id=" + Eval("id") + "&mod=3&rolId=" +  Eval("rol.id") %>'
                     onclick="return confirm('¿Estás seguro de que deseas eliminar este registro?')">
                        <i class="fa-solid fa-trash" title="borrar"></i>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
        <div><a href='<%="/pages/ficha.aspx?rolId=" + rolId%>' class="btn btn-success">AGREGAR</a></div>
    </div>
</asp:Content>
