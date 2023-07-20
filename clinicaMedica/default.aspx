<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="clinicaMedica._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center;" class="mb-5">SISTEMA CLINICA MEDICA</h1>
    <%if (Session["usuario"] == null)
            {%>
            <h2 style="text-align:center;" class="my-5">Para utilizar el sistema debe iniciar sesion</h2>

            <!-- Modal -->
            <div class="modal fade" id="modalLogin" tabindex="-1" aria-labelledby="modalLoginLabel" aria-hidden="true"  data-backdrop="static">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h1 class="modal-title fs-5" id="modalLoginLabel">Iniciar Sesion</h1>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <div class="mb-3">
                                <label for="codigoUser" class="form-label">Codigo usuario</label>
                                <asp:TextBox ID="codigoUser" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="pass" class="form-label">Contraseña</label>
                                <asp:TextBox ID="pass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                            <asp:Button Text="Iniciar Sesion" runat="server" id="login" CssClass="btn btn-primary" OnClick="login_Click"/>
                        </div>
                    </div>
                </div>
            </div>
    <%} else
            {%>

            <h2 style="text-align:center;" class="my-5">Bienvenido...!</h2>

           <%} %>
</asp:Content>
