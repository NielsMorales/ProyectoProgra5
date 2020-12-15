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
    public partial class frmPolizaClienteReporte : System.Web.UI.Page
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
            string rutaReporte = "~/Informes/RptPolizaClientes.rdlc";
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
                rpvClientesPoliza.LocalReport.ReportPath = rutaServidor;

                var infoFuenteDatos = this.rpvClientesPoliza.LocalReport.GetDataSourceNames();

                ///limpiar los datos de la fuente de datos

                rpvClientesPoliza.LocalReport.DataSources.Clear();

                ///obtener los datos del reporte

                List<sp_ReportePolizaCliente_Result> datosReporte = this.retornaDatosReporte(txtCedula.Text, txtNombre.Text, txtApellido1.Text, txtApellido2.Text,txtnombrePoliza.Text,txtDescripcionPoliza.Text);

                ///crear la fuente de datos

                ReportDataSource fuenteDatos = new ReportDataSource();

                fuenteDatos.Name = infoFuenteDatos[0];

                fuenteDatos.Value = datosReporte;

                /// agregar la fuente de datos al reporte

                this.rpvClientesPoliza.LocalReport.DataSources.Add(fuenteDatos);

                /// mostrar los datos en el reporte

                this.rpvClientesPoliza.LocalReport.Refresh();
            }
        }

        List<sp_ReportePolizaCliente_Result> retornaDatosReporte(string pCedula, string pNombre, string pApellido1, string pApellido2, string pNombrePoliza, string pDescripcion)
        {
            return this.modeloBD.sp_ReportePolizaCliente(pCedula, pNombre, pApellido1, pApellido2, pNombrePoliza, pDescripcion).ToList();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.contruirReporte();
        }
    }
}