using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AseguradoraSiglo21.BL;


namespace AseguradoraSiglo21.FormulariosEmpresa
{
    public partial class frmAdiccionesIngresar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void agregrarAdiccion()
        {


            if (this.IsValid)
            {

                string mensaje = "";

                BLAdicciones oInserta = new BLAdicciones();

                bool resultado = false;

                try
                {
                    ///Aquí se va a optener los datos para ingresar la información a la BD

                    string nombre = this.txtNombre.Text;

                    string codigo = this.txtCodigo.Text;


                    /// se llama al procedimiento almacenado para ingresar la información

                    resultado = oInserta.InsertaAdiccion(nombre, codigo);


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

                        mensaje += "El registro fue insertado";

                    }

                }

                ///motrar el mensaje

                Response.Write("<script>alert('" + mensaje + "')</script>");


            }

        }

        protected void btnAgregar_Click1(object sender, EventArgs e)
        {

            this.agregrarAdiccion();

        }
    }
}