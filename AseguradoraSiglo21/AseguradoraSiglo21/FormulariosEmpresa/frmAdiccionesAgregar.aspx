<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAseguradora.Master" AutoEventWireup="true" CodeBehind="frmAdiccionesAgregar.aspx.cs" Inherits="AseguradoraSiglo21.FormulariosEmpresa.frmAdiccionesIngresar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPrincipal" runat="server">

    <h1 class="text-center"><strong>Formulario de Ingreso de Adicciones</strong></h1>

    <br/>

    <form id="form1" runat="server" class="form-group">

    <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Nombre: "></asp:Label>

    <asp:TextBox ID="txtNombre" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>
       
        <asp:RequiredFieldValidator ID="rqvNombre" runat="server" ErrorMessage="Debe agregar el nombre" Display="None"
                
                                        ControlToVAlidate="txtNombre"></asp:RequiredFieldValidator>
        <br/>
    <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="Código: "></asp:Label>
        
    <asp:TextBox ID="txtCodigo" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>

   
        <asp:RequiredFieldValidator ID="rqvCodigo" runat="server" ErrorMessage="Agregar codigo" Display="None"
                
                                        ControlToVAlidate="txtCodigo"></asp:RequiredFieldValidator>
        <br/>
    <asp:Button ID="btnAgregar" runat="server" class="btn btn-primary mb-2" Text="Agregar" OnClick="btnAgregar_Click1" />

        <br/>
          <br/>
           <asp:ValidationSummary ID="vsAdiccionesAgregar" runat="server" ShowMessageBox="True" ShowSummary="False" />

    </form>

</asp:Content>
