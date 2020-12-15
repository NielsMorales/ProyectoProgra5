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
    public partial class frmAdiccionesClienteAgregar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {

                this.cargaAdicciones();

                this.cargaCodigoAdiccion();
            }

        }


        void agregrarAdiccionesCliente()
        {
           
            if (this.IsValid)
            {

                string mensaje = "";

                BLAdicciones_Cliente oInserta = new BLAdicciones_Cliente();

                bool resultado = false;

                try
                {
                    ///Aquí se va a optener los datos para ingresar la información a la BD

                    int IDAdiccion = Convert.ToInt16(this.ddAdicciones.SelectedValue);

                    string Cedula = this.txtCedula.Text;


                    BLAdicciones_Cliente datosAdiccionesCliente = new BLAdicciones_Cliente();

                    sp_AdiccionesClienteBuscaDuplicados_Result datosCliente = new sp_AdiccionesClienteBuscaDuplicados_Result();

                    ///se almacena la información brindado por el mentodo almacenado de la clase BLAdicionCliente

                    datosCliente = datosAdiccionesCliente.consultaDuplicado(IDAdiccion, Cedula);

                    ///verifica que el objeto retornado no sea nulo

                    if (datosCliente == null)
                    {

                        /// se llama al procedimiento almacenado para ingresar la información

                        resultado = oInserta.InsertaAdiccionCliente(IDAdiccion, Cedula);


                    }
                    else
                    {
                        mensaje += "No se pudo Realizar el registro debido a que el cliente ya tiene inscrito esta adicción";
                    }
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
            this.agregrarAdiccionesCliente();
        }

        void cargaAdicciones()
        {


            siglo21Entities1 oCarga = new siglo21Entities1();

            ///Se indica al dropdownlist la fuente de datos que va a tener

            this.ddAdicciones.DataSource = oCarga.sp_SeleccionaAdicciones();

            //indicarle al dropdownlist que se muestre

            this.ddAdicciones.DataBind();

        }

        protected void ddAdicciones_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.cargaCodigoAdiccion();

        }

        void cargaCodigoAdiccion() {


            BLAdicciones_Cliente oAdiccion = new BLAdicciones_Cliente();

            sp_SeleccionaUnaAdiccion_Result adiccion = oAdiccion.RetornaAdicionID(Convert.ToInt16(this.ddAdicciones.SelectedValue));

            this.txtCodigo.Text = adiccion.Codigo;


        }
    }
}