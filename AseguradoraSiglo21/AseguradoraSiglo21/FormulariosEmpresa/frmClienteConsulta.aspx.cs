using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AseguradoraSiglo21.BL;
using AseguradoraSiglo21.Modelos;

namespace AseguradoraSiglo21.FormulariosEmpresa
{
    public partial class frmClienteConsulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void cargaGastoCategoriaGrid()
        {

            /// crea una instacia de BLGastoCategoriaLista

            BLCliente cargaLista = new BLCliente();

            ///crear la variable que contiene los datos para el grid

            List<sp_ClientesBusquedas_Result> datosClientes = cargaLista.RetornaClienteBusqueda(this.txtNombre.Text,this.txtApellido1.Text,
                                                                                                        this.txtApellido2.Text,this.txtcedula.Text);

            ///Agrega al grid la información

            this.grdClientes.DataSource = datosClientes;

            this.grdClientes.DataBind();


        }

        protected void btn_Click(object sender, EventArgs e)
        {
            this.cargaGastoCategoriaGrid();
        }

        protected void grdClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            ///se indica al grid la nueva página utilizando el parámetro e

            this.grdClientes.PageIndex = e.NewPageIndex;

            ///Cargar de nuevo el drid para que se muestre

            this.cargaGastoCategoriaGrid();


        }
    }
}