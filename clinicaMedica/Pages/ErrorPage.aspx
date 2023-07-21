<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="clinicaMedica.Pages.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../Css/usuario.css" rel="stylesheet" />
<title>Error</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Error</h1>
        <p>
            <asp:Literal ID="ErrorMessageLiteral" runat="server"></asp:Literal>
        </p>
    </div>
</asp:Content>

