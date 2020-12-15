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
    public partial class frmAdiccionesConsultar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        void cargaGastoCategoriaGrid()
        {

            /// crea una instacia de BLGastoCategoriaLista

            BLAdicciones cargaLista = new BLAdicciones();

            ///crear la variable que contiene los datos para el grid

            List<sp_AdiccionesBusquedas_Result> datosPoliza = cargaLista.RetornAdiccionesBusqueda(this.txtNombre.Text, this.txtCodigo.Text);

            ///Agrega al grid la información

            this.grdAdicciones.DataSource = datosPoliza;

            this.grdAdicciones.DataBind();


        }

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            this.cargaGastoCategoriaGrid();
        }

        protected void grdAdicciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ///se indica al grid la nueva página utilizando el parámetro e

            this.grdAdicciones.PageIndex = e.NewPageIndex;

            ///Cargar de nuevo el drid para que se muestre

            this.cargaGastoCategoriaGrid();
        }
    }
}