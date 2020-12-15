<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAseguradora.Master" AutoEventWireup="true" CodeBehind="frmCoberturaPolizaAgregar.aspx.cs" Inherits="AseguradoraSiglo21.FormulariosEmpresa.frmCoberturaPolizaAgregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPrincipal" runat="server">

    <form class=" form-group" id="form1" runat="server">

        <h1 class="text-center"><strong>Formulario de Ingreso de Polizas</strong></h1>
    
        <br />

        <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="Nombre de Poliza:"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtNombrePoliza" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>

        <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Descripción:"></asp:Label>

        <asp:TextBox ID="txtDescripcion" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>

        <asp:Label ID="Label3" runat="server" style="font-weight: 700" Text="Porcentaje:"></asp:Label>

        <asp:TextBox ID="txtPorcentaje" runat="server" class="form-control mb-2 mr-sm-2" Width="150px"></asp:TextBox>

        <br />

        <asp:Button ID="btnAgregar" runat="server" Text="Agregar"  class="btn btn-primary mb-2" OnClick="btnAgregar_Click" />

    </form>

</asp:Content>
