using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AseguradoraSiglo21.BL;

namespace AseguradoraSiglo21.FormulariosEmpresa
{
    public partial class frmCoberturaPolizaAgregar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void agregarCoberturaPoliza()
        {

            if (this.IsValid)
            {

                string mensaje = "";

                BLCobertura_Poliza oInserta = new BLCobertura_Poliza();

                bool resultado = false;

                try
                {
                    ///Aquí se va a optener los datos para ingresar la información a la BD

                    string nombre = this.txtNombrePoliza.Text;

                    string descripcion = this.txtDescripcion.Text;

                    float porcentaje = (float)Math.Round(Convert.ToDouble(this.txtPorcentaje.Text), 1);

                    /// se llama al procedimiento almacenado para ingresar la información

                    resultado = oInserta.InsertaCoberturaPoliza(nombre, descripcion, porcentaje);

                    mensaje += "El registro fue insertado";


                }
                catch (Exception excepcionCapturada)
                {

                    mensaje += $"Ocurrió un error: {excepcionCapturada.Message} ";


                }
                finally
                {

                    ///motrar el mensaje

                    Response.Write("<script>alert('" + mensaje + "nmm" + "')</script>");

                }




            }





        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            this.agregarCoberturaPoliza();

        }


    }
}