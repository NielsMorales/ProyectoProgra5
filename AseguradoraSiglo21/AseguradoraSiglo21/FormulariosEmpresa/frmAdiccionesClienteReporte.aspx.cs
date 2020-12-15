using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using AseguradoraSiglo21.Modelos;
using Microsoft.Reporting.WebForms;


namespace AseguradoraSiglo21.FormulariosEmpresa
{
    public partial class frmAdiccionesClienteReporte : System.Web.UI.Page
    {
        /// <summary>
        /// Variable del modelo de EF
        /// </summary>
        
        siglo21Entities1 modeloBD = new siglo21Entities1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void contruirReporte()
        {

            ///indicar la ruta del reporte
            string rutaReporte = "~/Informes/RptAdiccionesCliente.rdlc";
            ///construir la ruta física
            string rutaServidor = Server.MapPath(rutaReporte);
            ///Validar que la ruta física exista
            if (!File.Exists(rutaServidor))
            {
                this.lblResultado.Text =
                    "El reporte seleccionado no existe";
                return;
            }
            else
            {
                rpvClientesAdicciones.LocalReport.ReportPath = rutaServidor;

                var infoFuenteDatos = this.rpvClientesAdicciones.LocalReport.GetDataSourceNames();

                ///limpiar los datos de la fuente de datos

                rpvClientesAdicciones.LocalReport.DataSources.Clear();

                ///obtener los datos del reporte

                List<sp_AdiccionesClienteReporte_Result> datosReporte = this.retornaDatosReporte(txtCedula.Text,txtNombre.Text,txtApellido1.Text,txtApellido2.Text,txtCodigoAdiccion.Text,txtNombreAdiccion.Text);

                ///crear la fuente de datos

                ReportDataSource fuenteDatos = new ReportDataSource();

                fuenteDatos.Name = infoFuenteDatos[0];

                fuenteDatos.Value = datosReporte;

                /// agregar la fuente de datos al reporte

                this.rpvClientesAdicciones.LocalReport.DataSources.Add(fuenteDatos);

                /// mostrar los datos en el reporte

                this.rpvClientesAdicciones.LocalReport.Refresh();
            }
        }

        List<sp_AdiccionesClienteReporte_Result> retornaDatosReporte(string pCedula, string pNombre, string pApellido1, string pApellido2, string pCodigo, string pNombreAdiccion)
        {
            return this.modeloBD.sp_AdiccionesClienteReporte(pCedula,pNombre,pApellido1,pApellido2,pCodigo,pNombreAdiccion).ToList();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            this.contruirReporte();

        }
    }
}