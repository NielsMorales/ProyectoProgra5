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
    public partial class frmAdiccionesClienteConsultar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void cargaGastoCategoriaGrid()
        {

            /// crea una instacia de BLGastoCategoriaLista

            BLAdicciones_Cliente cargaLista = new BLAdicciones_Cliente();

            ///crear la variable que contiene los datos para el grid

            List<sp_ClienteBusquedaAdicciones_Result> datosAdiccionesCliente = cargaLista.RetornAdiccionesClienteBusqueda(this.txtCedula.Text, this.txtCodigoAdiccion.Text,this.txtNombre.Text,
                                
                                                                                                                         this.txtApellido1.Text, this.txtApellido2.Text);

            ///Agrega al grid la información

            this.grdAdiccionesCliente.DataSource = datosAdiccionesCliente;

            this.grdAdiccionesCliente.DataBind();


        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.cargaGastoCategoriaGrid();
        }

        protected void grdAdiccionesCliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ///se indica al grid la nueva página utilizando el parámetro e

            this.grdAdiccionesCliente.PageIndex = e.NewPageIndex;

            ///Cargar de nuevo el drid para que se muestre

            this.cargaGastoCategoriaGrid();
        }
    }
}