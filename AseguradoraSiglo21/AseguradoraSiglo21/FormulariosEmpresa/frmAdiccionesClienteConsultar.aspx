<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAseguradora.Master" AutoEventWireup="true" CodeBehind="frmAdiccionesClienteConsultar.aspx.cs" Inherits="AseguradoraSiglo21.FormulariosEmpresa.frmAdiccionesClienteConsultar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPrincipal" runat="server">

    <form id="form1" runat="server">

    <h1 class="text-center"><strong>Busqueda Adicciones de Clientes</strong></h1>

    <br/>

    <div class="form-inline">
    <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Cédula: "></asp:Label>

    <asp:TextBox ID="txtCedula" runat="server" class="form-control mb-2 mr-sm-2" Width="160px"></asp:TextBox>

    <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="Código Adicción: "></asp:Label>

    <asp:TextBox ID="txtCodigoAdiccion" runat="server" class="form-control mb-2 mr-sm-2" Width="100px"></asp:TextBox>

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

    <br/>
    <br/>
        <asp:GridView ID="grdAdiccionesCliente" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="151px" Width="1254px" OnPageIndexChanging="grdAdiccionesCliente_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Código" />
                <asp:BoundField HeaderText="Cédula Cliente" DataField="ID_Cliente" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido1" HeaderText="Primer Apellido" />
                <asp:BoundField DataField="Apellido2" HeaderText="Segundo Apellido" />
                <asp:BoundField HeaderText="Código Adicción" DataField="Codigo" />
                <asp:BoundField DataField="NombreAdiccion" HeaderText="Nombre Adicción" />
                <asp:HyperLinkField HeaderText="Modificar" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="frmAdiccionesClienteModificar.aspx?id={0}" Text="Modificar" />
                <asp:HyperLinkField HeaderText="Eliminar" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="frmAdiccionesClienteEliminar.aspx?id={0}" Text="Eliminar" />
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

    </form>





</asp:Content>
