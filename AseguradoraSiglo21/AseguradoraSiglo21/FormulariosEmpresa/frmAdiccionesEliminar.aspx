<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAseguradora.Master" AutoEventWireup="true" CodeBehind="frmAdiccionesEliminar.aspx.cs" Inherits="AseguradoraSiglo21.FormulariosEmpresa.frmAdiccionesEliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPrincipal" runat="server">

        <form id="form1" runat="server" class="form-group">

        <h1 class="text-center"><strong>Formulario de Eliminación de Adicciones</strong></h1>

        <br/>

        <h5><strong>Ingrese el código que deseé buscar</strong></h5>

        <br/>

        <div class="form-inline">

        <asp:Label ID="Label4" runat="server" style="font-weight: 700" Text="Código: "></asp:Label>

        <asp:TextBox ID="txtCodigoBuscar" runat="server" class="form-control mb-2 mr-sm-2" Width="166px"></asp:TextBox>

        <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary mb-2" Text="Buscar" OnClick="btnBuscar_Click1" />

        </div>

        <br/>

    <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Nombre: "></asp:Label>

    <asp:TextBox ID="txtNombre" runat="server" class="form-control mb-2 mr-sm-2" Width="300px" ReadOnly="True"></asp:TextBox>

    <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="Código: "></asp:Label>

    <asp:TextBox ID="txtCodigo" runat="server" class="form-control mb-2 mr-sm-2" Width="300px" ReadOnly="True"></asp:TextBox>

    <br/>

    <asp:Button ID="btnEliminar" runat="server" class="btn btn-primary mb-2" Text="Eliminar" OnClick="btnEliminar_Click" />

    <br />
    <br />

    <asp:HiddenField ID="hdID" runat="server" />

    </form>



</asp:Content>
