﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AseguradoraSiglo21.BL;
using AseguradoraSiglo21.Modelos;

namespace AseguradoraSiglo21.FormulariosEmpresa
{
    public partial class frmRegistroPolizaConsultar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void cargaInformacionGrid()
        {

            /// crea una instacia de BLGastoCategoriaLista

            BLRegistro_Poliza cargaLista = new BLRegistro_Poliza();

            ///crear la variable que contiene los datos para el grid

            List<sp_PolizaBusqueda_Result> datosAdiccionesCliente = cargaLista.RetornaBusquedaPoliza(this.txtCedula.Text, this.txtNombre.Text,this.txtApellido1.Text, this.txtApellido2.Text);

            ///Agrega al grid la información

            this.grdPolizaCliente.DataSource = datosAdiccionesCliente;

            this.grdPolizaCliente.DataBind();


        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.cargaInformacionGrid();
        }

        protected void grdPolizaCliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ///se indica al grid la nueva página utilizando el parámetro e

            this.grdPolizaCliente.PageIndex = e.NewPageIndex;

            ///Cargar de nuevo el drid para que se muestre

            this.cargaInformacionGrid();
        }
    }
}