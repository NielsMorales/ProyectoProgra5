<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAseguradora.Master" AutoEventWireup="true" CodeBehind="frmAdiccionesClienteModificar.aspx.cs" Inherits="AseguradoraSiglo21.FormulariosEmpresa.frmAdiccionesClienteModificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPrincipal" runat="server">

    <h1 class="text-center"><strong>Formulario de Modificación de Adicciones a Clientes</strong></h1>

    <br>

    <form id="form1" runat="server" class="form-group">

    <div class="form-inline">

    <asp:Label ID="Label3" runat="server" style="font-weight: 700" Text="Cédula: "></asp:Label>

    <asp:TextBox ID="txtcedulaBuscar" runat="server" class="form-control mb-2 mr-sm-2" Width="160px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rqvcedulaBuscar" runat="server" ErrorMessage="Debe colocar la cédula jurídica" Display="None"
                
                                         ControlToVAlidate="txtcedulaBuscar"></asp:RequiredFieldValidator>

    <asp:Label ID="Label4" runat="server" style="font-weight: 700" Text="Código Adicción: "></asp:Label>

        <asp:TextBox ID="txtCodigoBuscar" runat="server" class="form-control mb-2 mr-sm-2" Width="80px" ReadOnly="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rqvCodigo1" runat="server" ErrorMessage="Debe colocar el código" Display="None"
                
                                         ControlToVAlidate="txtCodigoBuscar"></asp:RequiredFieldValidator>

    <asp:DropDownList ID="ddCodigoBurcar" runat="server" class="form-control mb-2 mr-sm-2" style="font-weight: 700" Width="180px" DataTextField="Nombre" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="ddCodigoBurcar_SelectedIndexChanged">
    </asp:DropDownList>
        
        <asp:RequiredFieldValidator ID="rqvCodigoBurcar" runat="server" ErrorMessage="Es requerido" Display="None"
                
                                         ControlToVAlidate="ddCodigoBurcar"></asp:RequiredFieldValidator>

    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-primary mb-2" OnClick="btnBuscar_Click"/>

    </div>

    <br />
        <div class="form-inline">
        <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="Cliente: "></asp:Label>
        <asp:TextBox ID="txtNombreCompleto" runat="server" class="form-control mb-2 mr-sm-2" Width="420px" ReadOnly="True"></asp:TextBox>
            
        </div>
        <br />

    <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Código de Adicción a Cambiar: "></asp:Label>

            <br />
        <br />

        <div class="form-inline">
        <asp:DropDownList ID="ddAdicciones" runat="server" class="form-control mb-2 mr-sm-2" style="font-weight: 700" Width="200px" DataTextField="Nombre" AutoPostBack="True" DataValueField="ID" OnSelectedIndexChanged="ddAdicciones_SelectedIndexChanged">
        </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rqvAdicciones" runat="server" ErrorMessage="Es requerido" Display="None"
                
                                         ControlToVAlidate="ddAdicciones"></asp:RequiredFieldValidator>
         <br />
         <br />
        <asp:TextBox ID="txtCodigo" runat="server" class="form-control mb-2 mr-sm-2" Width="150px" ReadOnly="True">Código Adicción</asp:TextBox>
        </div>
        <br />
        

    <asp:Button ID="btnModificar" runat="server" class="btn btn-primary mb-2" Text="Modificar" OnClick="btnModificar_Click1"/>


        <br />
        <asp:HiddenField ID="hdCedula" runat="server" />
        <asp:HiddenField ID="hdIDAdiccion" runat="server" />
&nbsp;</form>



</asp:Content>
