<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAseguradora.Master" AutoEventWireup="true" CodeBehind="frmCoberturaPolizaConsulta.aspx.cs" Inherits="AseguradoraSiglo21.FormulariosEmpresa.frmCoberturaPilizaConsulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPrincipal" runat="server">

        <form class=" form-group" id="form1" runat="server">

        <h1 class="text-center"><strong>Consultas de Polizas</strong></h1>
    
        <br />

        <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="Nombre de Poliza:"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtNombrePoliza" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>

        <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Descripción:"></asp:Label>

        <asp:TextBox ID="txtDescripcion" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>

        <br />

        <asp:Button ID="btnBuscar" runat="server" Text="Buscar"  class="btn btn-primary mb-2" OnClick="btnBuscar_Click" />
            <br />

            <br />
            <asp:GridView ID="grdPolizas" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="20" Width="1242px" OnPageIndexChanging="grdPolizas_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="ID" />
                    <asp:BoundField HeaderText="Nombre de Poliza" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Porcentage" DataField="Porcentaje" />
                    <asp:HyperLinkField HeaderText="Modifica Poliza" DataNavigateUrlFields="Nombre" DataNavigateUrlFormatString="frmCoberturaPolizaModificar.aspx?nombre={0}" Text="Modificar" />
                    <asp:HyperLinkField HeaderText="Elimina Poliza" DataNavigateUrlFields="Nombre" DataNavigateUrlFormatString="frmCoberturaPolizaEliminar.aspx?nombre={0}" Text="Eliminar" />
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
