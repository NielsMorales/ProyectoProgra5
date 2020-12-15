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
    public partial class frmCoberturaPolizaEliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {

                this.cargaDatosRegistroEnviado();
                

            }

        }

        void cargaDatosRegistroEnviado()
        {


            ///Optiene el parámetro enviado del grid

            string parametroID = this.Request.QueryString["nombre"];

            this.txtBuscar.Text = parametroID;

            /// Valida si el parametro es correcto

            if (!string.IsNullOrEmpty(parametroID))
            {

                this.txtBuscar.Text = parametroID;

                this.txtBuscar.ReadOnly = true;

                BLCobertura_Poliza oCoberturaPoliza = new BLCobertura_Poliza();

                sp_SeleccionaUnaCoberturaPoliza_Result datosCoberturaPoliza = new sp_SeleccionaUnaCoberturaPoliza_Result();

                ///se almacena la información brindado por el mentodo almacenado de la clase BLGastoCategoriaModificaR

                datosCoberturaPoliza = oCoberturaPoliza.RetornaCoberturaPoliza(parametroID);

                ///verifica que el objeto retornado no sea nulo

                if (datosCoberturaPoliza == null)
                {

                    Response.Write("<script>alert('El nombre ingresado no fue encontrado en la base de Datos')</script>");

                }

                else
                {

                    ///se asigna los valores correspondientes

                    this.txtNombrePoliza.Text = datosCoberturaPoliza.Nombre_de_Poliza;

                    this.txtDescripcion.Text = datosCoberturaPoliza.Descripcion_de_Poliza;

                    this.txtPorcentaje.Text = datosCoberturaPoliza.Porcentaje_de_Poliza.ToString();

                    this.hfID.Value = datosCoberturaPoliza.ID.ToString();

                }

            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            this.buscaCoberturaPoliza();

        }

        void buscaCoberturaPoliza()
        {


            string nombreCobertura = this.txtBuscar.Text;

            this.txtBuscar.ReadOnly = true;

            BLCobertura_Poliza oCoberturaPoliza = new BLCobertura_Poliza();

            sp_SeleccionaUnaCoberturaPoliza_Result datosCoberturaPoliza = new sp_SeleccionaUnaCoberturaPoliza_Result();

            ///se almacena la información brindado por el mentodo almacenado de la clase BLGastoCategoriaModificaR

            datosCoberturaPoliza = oCoberturaPoliza.RetornaCoberturaPoliza(nombreCobertura);

            ///verifica que el objeto retornado no sea nulo

            if (datosCoberturaPoliza == null)
            {

                Response.Write("<script>alert('El nombre ingresado no fue encontrado en la base de Datos')</script>");

            }

            else
            {

                ///se asigna los valores correspondientes

                this.txtNombrePoliza.Text = datosCoberturaPoliza.Nombre_de_Poliza;

                this.txtDescripcion.Text = datosCoberturaPoliza.Descripcion_de_Poliza;

                this.txtPorcentaje.Text = datosCoberturaPoliza.Porcentaje_de_Poliza.ToString();

                this.hfID.Value = datosCoberturaPoliza.ID.ToString();

            }


        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            this.eliminarRegistro();

        }

        void eliminarRegistro()
        {

            if (this.IsValid)
            {

                string mensaje = "";

                BLCobertura_Poliza oElimina = new BLCobertura_Poliza();

                bool resultado = false;

                try
                {

                    int id = Convert.ToInt16(this.hfID.Value);

                    /// se llama al procedimiento almacenado para eliminar la información

                    resultado = oElimina.EliminarCoberturaPoliza(id);


                }
                catch (Exception excepcionCapturada)
                {

                    mensaje += $"Ocurrió un error: {excepcionCapturada.Message} ";


                }
                finally
                {

                    /// si la variable resultado es verdadera implica que no hubo errores

                    if (resultado)
                    {

                        mensaje += "El registro fue eliminado";

                    }

                }

                ///motrar el mensaje

                Response.Write("<script>alert('" + mensaje + "')</script>");


            }
        }
    }
}