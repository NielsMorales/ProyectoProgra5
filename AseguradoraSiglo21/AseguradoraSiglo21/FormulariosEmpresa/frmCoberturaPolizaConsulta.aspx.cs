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
    public partial class frmCoberturaPilizaConsulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void cargaGastoCategoriaGrid()
        {

            /// crea una instacia de BLGastoCategoriaLista

            BLCobertura_Poliza cargaLista = new BLCobertura_Poliza();

            ///crear la variable que contiene los datos para el grid

            List<sp_CoberturaPolizaBusqueda_Result> datosPoliza = cargaLista.RetornaCoberturaPolizaBusqueda(this.txtNombrePoliza.Text, this.txtDescripcion.Text);

            ///Agrega al grid la información

            this.grdPolizas.DataSource = datosPoliza;

            this.grdPolizas.DataBind();


        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.cargaGastoCategoriaGrid();
        }

        protected void grdPolizas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            ///se indica al grid la nueva página utilizando el parámetro e

            this.grdPolizas.PageIndex = e.NewPageIndex;

            ///Cargar de nuevo el drid para que se muestre

            this.cargaGastoCategoriaGrid();


        }




    }
}