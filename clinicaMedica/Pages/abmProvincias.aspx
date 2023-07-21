<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="abmProvincias.aspx.cs" Inherits="clinicaMedica.Pages.abmProvincias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../Css/usuario.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container contenedor-grid my-4">
        <asp:GridView ID="GridAbmProvincias" runat="server" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table" AllowSorting="true">
        <HeaderStyle CssClass="cabecera"/>
        <Columns>
            <asp:BoundField HeaderText="provincia" DataField="provincia" />
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# "/pages/FichaProvincias.aspx?id=" + Eval("id") +"&mod=1" %>'>
                       <i class="fa-solid fa-eye" title="ver"></i>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# "/pages/FichaProvincias.aspx?id=" + Eval("id") + "&mod=2" %>'>
                       <i class="fa-solid fa-file-pen" title="editar"></i>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# "/pages/ABMProvincias.aspx?id=" + Eval("id") + "&mod=3" %>'
                     onclick="return confirm('¿Estás seguro de que deseas eliminar este registro?')">
                       <i class="fa-solid fa-trash" title="borrar"></i>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
        <div><a href="/pages/FichaProvincias.aspx?id=0&mod=0" class="btn btn-success">AGREGAR</a></div>
    </div>
</asp:Content>
