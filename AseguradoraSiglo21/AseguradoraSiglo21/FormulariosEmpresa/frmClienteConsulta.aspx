<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAseguradora.Master" AutoEventWireup="true" CodeBehind="frmClienteConsulta.aspx.cs" Inherits="AseguradoraSiglo21.FormulariosEmpresa.frmClienteConsulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPrincipal" runat="server">

    <form id="form1" runat="server">

    <h1 class="text-center"><strong>Busqueda de Clientes</strong></h1>

        <asp:Label ID="Label1" runat="server" Text="Realizar busqueda por: " style="font-weight: 700"></asp:Label>

        <br />

        <br />

        <div>

        <asp:Label ID="Label2" runat="server" Text="Nombre" style="font-weight: 700"></asp:Label>

        <asp:TextBox ID="txtNombre" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>

        <asp:Label ID="Label3" runat="server" Text="Primer Apellido" style="font-weight: 700"></asp:Label>

        <asp:TextBox ID="txtApellido1" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>

        <asp:Label ID="Label4" runat="server" Text="Segundo Apellido" style="font-weight: 700"></asp:Label>

        <asp:TextBox ID="txtApellido2" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>

        </div>

        <asp:Label ID="Label5" runat="server" Text="Cédula" style="font-weight: 700"></asp:Label>

        <asp:TextBox ID="txtcedula" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>

        <br />

        <asp:Button ID="btn" runat="server" Text="Buscar" class="btn btn-primary mb-2" OnClick="btn_Click" />




        <br />
        <br />
        <asp:GridView ID="grdClientes" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="173px" OnPageIndexChanging="grdClientes_PageIndexChanging" PageSize="16" Width="1343px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Código" />
                <asp:BoundField HeaderText="Cédula" DataField="Cedula" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Primer Apellido" DataField="Apellido1" />
                <asp:BoundField HeaderText="Segundo Apellido" DataField="Apellido2" />
                <asp:BoundField HeaderText="Provincia" DataField="Provincia" />
                <asp:BoundField HeaderText="Canton" DataField="Canton" />
                <asp:BoundField HeaderText="Distrito" DataField="Distrito" />
                <asp:HyperLinkField DataNavigateUrlFields="Cedula" DataNavigateUrlFormatString="frmClienteModificar.aspx?Cedula={0}" HeaderText="Modificar Cliente" Text="Modificar" />
                <asp:HyperLinkField DataNavigateUrlFields="Cedula" DataNavigateUrlFormatString="frmClienteEliminar.aspx?Cedula={0}" HeaderText="Eliminar Cliente" Text="Eliminar" />
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
        <br />
        <br />
        <br />




    </form>




</asp:Content>
