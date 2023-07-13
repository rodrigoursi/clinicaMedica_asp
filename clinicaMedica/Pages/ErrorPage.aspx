<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="clinicaMedica.Pages.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../Css/usuario.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
       <h1 style="text-align:center">ERROR:</h1>
        <h2><%= Session["Error"]%></h2>
    </div>
</asp:Content>

