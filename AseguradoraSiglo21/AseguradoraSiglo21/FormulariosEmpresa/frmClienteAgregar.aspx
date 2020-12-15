<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAseguradora.Master" AutoEventWireup="true" CodeBehind="frmClienteAgregar.aspx.cs" Inherits="AseguradoraSiglo21.FormulariosEmpresa.frmClienteAgregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPrincipal" runat="server">

    <form id="form1" runat="server">

        <h1 class="text-center">Formulario Nuevo Ingreso Cliente</h1>

        <asp:Label ID="Label4" runat="server" style="font-weight: 700" Text="Nombre: "></asp:Label>

        <asp:TextBox ID="txtNombre" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>

        <asp:Label ID="Label5" runat="server" style="font-weight: 700" Text="Primer Apellido: "></asp:Label>

        <asp:TextBox ID="txtApellido1" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>

        <asp:Label ID="Label6" runat="server" style="font-weight: 700" Text="Segundo Apellido: "></asp:Label>

        <asp:TextBox ID="txtApellido2" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>

        <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="Cédula:       "></asp:Label>

        <asp:TextBox ID="txtCedula" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>

        <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Género: "></asp:Label>

        <asp:DropDownList ID="ddGenero" runat="server" class="form-control mb-2 mr-sm-2" style="font-weight: 700" Width="300px">
            <asp:ListItem>Hombre</asp:ListItem>
            <asp:ListItem>Mujer</asp:ListItem>
        </asp:DropDownList>

        <asp:Label ID="Label3" runat="server" style="font-weight: 700" Text="Fecha de Nacimiento: "></asp:Label>

        <asp:TextBox ID="txtFechanacimiento" runat="server" class="form-control mb-2 mr-sm-2" Width="300px" TextMode="Date"></asp:TextBox>

         <br />

        <div class="form-inline">

        <asp:Label ID="Label11" runat="server" style="font-weight: 700" Text="Provincia: "></asp:Label>

        <asp:DropDownList ID="ddProvincia" runat="server" class="form-control mb-2 mr-sm-2" style="font-weight: 700" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="ddProvincia_SelectedIndexChanged">
          
            <asp:ListItem Value="1">San José</asp:ListItem>
            <asp:ListItem Value="2">Alajuela</asp:ListItem>
            <asp:ListItem Value="3">Heredia</asp:ListItem>
            <asp:ListItem Value="4">Cartago</asp:ListItem>
            <asp:ListItem Value="5">Puntarenas</asp:ListItem>
            <asp:ListItem Value="6">Guanacaste</asp:ListItem>
            <asp:ListItem Value="7">Limón</asp:ListItem>

        </asp:DropDownList>


        <asp:Label ID="Label12" runat="server" style="font-weight: 700" Text="Canton: "></asp:Label>

        <asp:DropDownList ID="ddCanton" runat="server" class="form-control mb-2 mr-sm-2" style="font-weight: 700" Width="300px" AutoPostBack="True" DataTextField="Nombre" DataValueField="ID" OnSelectedIndexChanged="ddCanton_SelectedIndexChanged"></asp:DropDownList>

        <asp:Label ID="Label13" runat="server" style="font-weight: 700" Text="Distrito: "></asp:Label>
       
        <asp:DropDownList ID="ddDistrito" runat="server" class="form-control mb-2 mr-sm-2" style="font-weight: 700" Width="300px" DataTextField="Nombre" DataValueField="ID"></asp:DropDownList>

        </div>

        <br />

        <div class="form-inline">

        <asp:Label ID="Label7" runat="server" style="font-weight: 700" Text="Dirección: "></asp:Label>

        <asp:TextBox ID="txtDireccion" runat="server" class="form-control mb-2 mr-sm-2" Width="73.5%"></asp:TextBox>

        </div>

        <br />

        <asp:Label ID="Label8" runat="server" style="font-weight: 700" Text="Primer Teléfono: "></asp:Label>

        <asp:TextBox ID="txtTelefono1" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>

        <asp:Label ID="Label9" runat="server" style="font-weight: 700" Text="Segundo Teléfono: "></asp:Label>

        <asp:TextBox ID="txtTelefono2" runat="server" class="form-control mb-2 mr-sm-2" Width="300px"></asp:TextBox>

        <asp:Label ID="Label10" runat="server" style="font-weight: 700" Text="Correo Eléctronico: "></asp:Label>

        <asp:TextBox ID="txtCorreo" runat="server" class="form-control mb-2 mr-sm-2" Width="300px" TextMode="Email"></asp:TextBox>

        <br />

        <asp:Button ID="btnAgregar" runat="server" class="btn btn-primary mb-2" Text="Agregar" OnClick="btnAgregar_Click" />

    </form>




</asp:Content>
