<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAseguradora.Master" AutoEventWireup="true" CodeBehind="frmCoberturaPolizaEliminar.aspx.cs" Inherits="AseguradoraSiglo21.FormulariosEmpresa.frmCoberturaPolizaEliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPrincipal" runat="server">

        <form class=" form-group" id="form1" runat="server">

        <h1 class="text-center"><strong>Formulario de Eliminación de Polizas</strong></h1>
    
        <br />

        <div class="form-inline">

        <asp:Label ID="Label4" runat="server" style="font-weight: 700" Text="Busqueda de Poliza:"></asp:Label>

        <asp:TextBox ID="txtBuscar" runat="server" class="form-control mb-2 mr-sm-2" Width="200px"></asp:TextBox>

        <asp:Button ID="btnBuscar" runat="server" Text="Buscar"  class="btn btn-primary mb-2" OnClick="btnBuscar_Click"/>

        </div>

         <br />

        <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="Nombre de Poliza:"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtNombrePoliza" runat="server" class="form-control mb-2 mr-sm-2"  Width="300px" ReadOnly="True"></asp:TextBox>

        <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Descripción:"></asp:Label>

        <asp:TextBox ID="txtDescripcion" runat="server" class="form-control mb-2 mr-sm-2"  Width="300px" ReadOnly="True"></asp:TextBox>

        <asp:Label ID="Label3" runat="server" style="font-weight: 700" Text="Porcentaje:"></asp:Label>

        <asp:TextBox ID="txtPorcentaje" runat="server" class="form-control mb-2 mr-sm-2" Width="150px" ReadOnly="True"></asp:TextBox>

        <br />

        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"  class="btn btn-primary mb-2" OnClick="btnEliminar_Click" />

        <br />
        <br />
        <asp:HiddenField ID="hfID" runat="server" />

    
    </form>



</asp:Content>
