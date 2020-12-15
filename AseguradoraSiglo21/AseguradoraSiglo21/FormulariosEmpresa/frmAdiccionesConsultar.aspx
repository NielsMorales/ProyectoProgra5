<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAseguradora.Master" AutoEventWireup="true" CodeBehind="frmAdiccionesConsultar.aspx.cs" Inherits="AseguradoraSiglo21.FormulariosEmpresa.frmAdiccionesConsultar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPrincipal" runat="server">

        <h1 class="text-center"><strong>Busqueda de Adicciones</strong></h1>

    <br/>

    <form id="form1" runat="server" class="form-group">

    <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Nombre: "></asp:Label>

    <asp:TextBox ID="txtNombre" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>

    <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="Código: "></asp:Label>

    <asp:TextBox ID="txtCodigo" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>

    <br/>

    <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary mb-2" Text="Buscar" OnClick="btnBuscar_Click1" />


        <br />
        <br />
        <asp:GridView ID="grdAdicciones" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="161px" OnPageIndexChanging="grdAdicciones_PageIndexChanging" Width="875px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Código" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Codigo" HeaderText="Código de Adicción" />
                <asp:HyperLinkField HeaderText="Modifica Adicción" DataNavigateUrlFields="Codigo" DataNavigateUrlFormatString="frmAdiccionesModificar.aspx?codigo={0}" Text="Modificar" />
                <asp:HyperLinkField HeaderText="Elimina Adicción" DataNavigateUrlFields="Codigo" DataNavigateUrlFormatString="frmAdiccionesEliminar.aspx?codigo={0}" Text="Eliminar" />
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


    </form>



</asp:Content>
