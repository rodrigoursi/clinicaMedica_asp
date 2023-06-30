﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="abmEspecialidades.aspx.cs" Inherits="clinicaMedica.Pages.abmEspecialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../Css/usuario.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container contenedor-grid my-4">
        <asp:GridView ID="GridAbmEspecialidades" runat="server" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table">
        <HeaderStyle CssClass="cabecera"/>
        <Columns>
            <asp:BoundField HeaderText="codigo" DataField="codigo" />
            <asp:BoundField HeaderText="especialidad" DataField="especialidad" />
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# "/pages/FichaEspecialidades.aspx?id=" + Eval("id") %>'>
                       <i class="fa-solid fa-eye" title="ver"></i>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# "/pages/FichaEspecialidades.aspx?id=" + Eval("id") %>'>
                       <i class="fa-solid fa-file-pen" title="editar"></i>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# "/pages/FichaEspecialidades.aspx?id=" + Eval("id") %>'>
                       <i class="fa-solid fa-trash" title="borrar"></i>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
        <div><a href="/pages/ficha.aspx" class="btn btn-success">AGREGAR</a></div>
    </div>
</asp:Content>