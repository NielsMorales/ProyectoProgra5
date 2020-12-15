<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAseguradora.Master" AutoEventWireup="true" CodeBehind="frmPolizaClienteReporte.aspx.cs" Inherits="AseguradoraSiglo21.FormulariosEmpresa.frmPolizaClienteReporte" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPrincipal" runat="server">


    <form id="form1" runat="server">

    <asp:scriptmanager id="ScriptManager2" runat="server" enablepagemethods="true"/>

    <h1 class="text-center"><strong>Reporte Adicciones de Clientes</strong></h1>

    <br/>

        <div class="form-inline">

                 <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Cédula: "></asp:Label>

                <asp:TextBox ID="txtCedula" runat="server" class="form-control mb-2 mr-sm-2" Width="160px"></asp:TextBox>

        </div>

    <br/>

    <div class="form-inline">

    <asp:Label ID="Label3" runat="server" Text="Nombre:" style="font-weight: 700"></asp:Label>

    <asp:TextBox ID="txtNombre" runat="server" class="form-control mb-2 mr-sm-2" Width="160px"></asp:TextBox>
       
    <asp:Label ID="Label4" runat="server" Text="Primer Apellido:" style="font-weight: 700"></asp:Label>

    <asp:TextBox ID="txtApellido1" runat="server" class="form-control mb-2 mr-sm-2" Width="160px"></asp:TextBox>
        
    <asp:Label ID="Label5" runat="server" Text="Segundo Apellido:" style="font-weight: 700"></asp:Label>

    <asp:TextBox ID="txtApellido2" runat="server" class="form-control mb-2 mr-sm-2" Width="160px"></asp:TextBox>
       
    </div>
         <br/>
            <div class="form-inline">

    <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="Nombre de Póliza: "></asp:Label>

    <asp:TextBox ID="txtnombrePoliza" runat="server" class="form-control mb-2 mr-sm-2" Width="100px"></asp:TextBox>

    <asp:Label ID="Label6" runat="server" style="font-weight: 700" Text="Descripción de Póliza: "></asp:Label>

    <asp:TextBox ID="txtDescripcionPoliza" runat="server" class="form-control mb-2 mr-sm-2" Width="100px"></asp:TextBox>

   </div>

       

    <br/>

    <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary mb-2" Text="Buscar" OnClick="btnBuscar_Click"/>

              <br/>

            <asp:Label ID="lblResultado" runat="server" style="font-weight: 700"></asp:Label>

    <br/>
    <br/>
        

    <rsweb:reportviewer ID="rpvClientesPoliza" runat="server" Width="100%">
    </rsweb:reportviewer>

    </form>


</asp:Content>
