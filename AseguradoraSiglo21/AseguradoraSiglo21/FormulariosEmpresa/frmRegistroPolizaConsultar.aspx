<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAseguradora.Master" AutoEventWireup="true" CodeBehind="frmRegistroPolizaConsultar.aspx.cs" Inherits="AseguradoraSiglo21.FormulariosEmpresa.frmRegistroPolizaConsultar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <h1 class="text-center"><strong>Busqueda de Pólizas de Clientes</strong></h1>
    <br />

    <form id="form1" runat="server">

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

    <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary mb-2" Text="Buscar" OnClick="btnBuscar_Click"/>

        <br />
        <br />

    <br/>
        <asp:GridView ID="grdPolizaCliente" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1377px" AutoGenerateColumns="False" Height="177px" OnPageIndexChanging="grdPolizaCliente_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Número de Poliza" />
                <asp:BoundField DataField="ID_Cliente" HeaderText="Cédula" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido1" HeaderText="Primer Apellido" />
                <asp:BoundField DataField="Apellido2" HeaderText="Segundo Apellido" />
                <asp:BoundField DataField="NombreCobertura" HeaderText="Nombre de Cobertura" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción de Cobertura" />
                <asp:BoundField DataField="Fecha_Vencimiento" HeaderText="Fecha de Vencimiento " />
                <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="frmRegistroPolizaModificar.aspx?id={0}" HeaderText="Modificar" Text="Modificar" />
                <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="frmRegistroPolizaEliminar.aspx?id={0}" HeaderText="Eliminar" Text="Eliminar" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    <br/>

        </form>

</asp:Content>
