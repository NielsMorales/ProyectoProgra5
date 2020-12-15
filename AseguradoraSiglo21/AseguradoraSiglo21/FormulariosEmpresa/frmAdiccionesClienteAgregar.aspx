<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAseguradora.Master" AutoEventWireup="true" CodeBehind="frmAdiccionesClienteAgregar.aspx.cs" Inherits="AseguradoraSiglo21.FormulariosEmpresa.frmAdiccionesClienteAgregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPrincipal" runat="server">

    <h1 class="text-center"><strong>Formulario de Ingreso de Adicciones a Clientes</strong></h1>

    <br>

    <form id="form1" runat="server" class="form-group">

    <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Código de Adicción: "></asp:Label>

        <br />
        <br />
        <asp:DropDownList ID="ddAdicciones" runat="server" class="form-control mb-2 mr-sm-2" style="font-weight: 700" Width="300px" DataTextField="Nombre" AutoPostBack="True" DataValueField="ID" OnSelectedIndexChanged="ddAdicciones_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rqvAdcciones" runat="server" ErrorMessage="Debe seleccionar uno" Display="None"
                
                                         ControlToVAlidate="ddAdicciones"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtCodigo" runat="server" class="form-control mb-2 mr-sm-2" Width="150px" ReadOnly="True">Código Adicción</asp:TextBox>
        <br />

    <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="Cédula: "></asp:Label>

    <asp:TextBox ID="txtCedula" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>
        
         <asp:RequiredFieldValidator ID="rqvCedula" runat="server" ErrorMessage="Agregar cédula jurídica" Display="None"
                
                                         ControlToVAlidate="txtCedula"></asp:RequiredFieldValidator>
        <br />
        <br />
        
  <br />
        

    <asp:Button ID="btnAgregar" runat="server" class="btn btn-primary mb-2" Text="Agregar" OnClick="btnAgregar_Click1" />
         <br />
         <br />
     <asp:ValidationSummary ID="vsAdiccionesClienteAgregar" runat="server" ShowMessageBox="True" ShowSummary="False" />
        <br />
        <br />
        <br />
        
    </form>




</asp:Content>
