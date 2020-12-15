<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAseguradora.Master" AutoEventWireup="true" CodeBehind="frmRegistroPolizaAgregar.aspx.cs" Inherits="AseguradoraSiglo21.FormulariosEmpresa.frmRegistroPolizaAgregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPrincipal" runat="server">



    <form id="form1" runat="server">

    <h1 class="text-center"><strong>Formulario de Ingreso de Nueva Póliza</strong></h1>

        <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="Nombre de Poliza:"></asp:Label>

        <div class="form-inline">
        
        <asp:DropDownList ID="ddNombrePoliza" runat="server" class="form-control mb-2 mr-sm-2" style="font-weight: 700" Width="300px" AutoPostBack="True" DataTextField="Nombre" DataValueField="Nombre" OnSelectedIndexChanged="ddNombrePoliza_SelectedIndexChanged">
        </asp:DropDownList>

        <asp:TextBox ID="txtDescripcionPoliza" runat="server" ReadOnly="True" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>

        </div>
        
        <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Cédula Cliente:"></asp:Label>
        <div class="form-inline">
        <asp:TextBox ID="txtCedula" runat="server" class="form-control mb-2 mr-sm-2" Width="300px" AutoPostBack="True" OnTextChanged="txtCedula_TextChanged"></asp:TextBox>
        <asp:TextBox ID="txtNombreCompleto" runat="server" ReadOnly="True" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>
        
        </div>
            <br />
        <asp:Label ID="Label3" runat="server" style="font-weight: 700" Text="Monto Asegurado:"></asp:Label>
        
        <asp:TextBox ID="txtMontoAsegurado" runat="server" class="form-control mb-2 mr-sm-2" Width="300px" AutoPostBack="True" OnTextChanged="txtMontoAsegurado_TextChanged"></asp:TextBox>
        
        <asp:Label ID="Label4" runat="server" style="font-weight: 700" Text="Porcentaje de Cobertura:"></asp:Label>
        
        <asp:TextBox ID="txtPorcentajeCobertura" runat="server" ReadOnly="True" class="form-control mb-2 mr-sm-2" Width="80px"></asp:TextBox>
        
        <asp:Label ID="Label5" runat="server" style="font-weight: 700" Text="Cantidad de Adicciones:"></asp:Label>
        
        <asp:TextBox ID="txtTotalAdicciones" runat="server" ReadOnly="True" class="form-control mb-2 mr-sm-2" Width="80px"></asp:TextBox>
        
        <asp:Label ID="Label6" runat="server" style="font-weight: 700" Text="Monto de Adicciones:"></asp:Label>
        
        <asp:TextBox ID="txtMontoAdicciones" runat="server" class="form-control mb-2 mr-sm-2" Width="300px" ReadOnly="True"></asp:TextBox>
        
        <asp:Label ID="Label7" runat="server" style="font-weight: 700" Text="Prima antes de Impuestos:"></asp:Label>
        
        <asp:TextBox ID="txtPrimaAntesImpuestos" runat="server" class="form-control mb-2 mr-sm-2" Width="300px" ReadOnly="True"></asp:TextBox>
        
        <asp:Label ID="Label8" runat="server" style="font-weight: 700" Text="Impuestos:"></asp:Label>
        
        <asp:TextBox ID="txtImpuestos" runat="server" class="form-control mb-2 mr-sm-2" Width="300px" ReadOnly="True"></asp:TextBox>
        
        <asp:Label ID="Label9" runat="server" style="font-weight: 700" Text="Prima Final:"></asp:Label>
        
        <asp:TextBox ID="txtPrimaFinal" runat="server" class="form-control mb-2 mr-sm-2" Width="300px" ReadOnly="True"></asp:TextBox>

        <asp:Label ID="Label10" runat="server" style="font-weight: 700" Text="Fecha de Vencimiento:"></asp:Label>

        <asp:TextBox ID="txtFechaVencimiento" runat="server" class="form-control mb-2 mr-sm-2" Width="300px" TextMode="Date"></asp:TextBox>

        <asp:HiddenField ID="hdPorcentajeCobertura" runat="server" />
        <asp:HiddenField ID="hdIDCovertura" runat="server" />

        <br />

        <asp:Button ID="btnAgregar" runat="server" class="btn btn-primary mb-2" Text="Agregar" OnClick="btnAgregar_Click" />

    <br />

    </form>





</asp:Content>
