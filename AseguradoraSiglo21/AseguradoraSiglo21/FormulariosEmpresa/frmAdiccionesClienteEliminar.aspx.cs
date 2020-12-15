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
    public partial class frmAdiccionesClienteEliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {

                this.cargaAdicciones();

                this.cargaCodigoAdiccion();

                this.cargaCodigos();

                this.cargaDatosRegistroEnviado();
            }

        }

        void cargaDatosBusqueda()
        {

            int id = Convert.ToInt16(this.ddCodigoBurcar.SelectedValue);

            string cedulaBuscar = txtcedulaBuscar.Text;


            BLAdicciones_Cliente datosAdiccionesCliente = new BLAdicciones_Cliente();

            sp_AdiccionesClienteBuscaDuplicados_Result datosCliente = new sp_AdiccionesClienteBuscaDuplicados_Result();

            ///se almacena la información brindado por el mentodo almacenado de la clase BLAdicionCliente

            datosCliente = datosAdiccionesCliente.consultaDuplicado(id, cedulaBuscar);

            ///verifica que el objeto retornado no sea nulo

            if (datosCliente == null)
            {

                Response.Write("<script>alert('La Adicción ingresado no esta asociado a este Cliente')</script>");

            }
            else
            {

                ///se asigna los valores correspondientes
                ///

                this.ddAdicciones.SelectedValue = datosCliente.ID_Adiccion.ToString();

                this.cargaCodigoAdiccion();

                BLCliente oNombre = new BLCliente();

                sp_SeleccionaClienteCedula_Result nombreCliente = oNombre.RetornaClienteCed(txtcedulaBuscar.Text);

                this.txtNombreCompleto.Text = nombreCliente.Nombre + " " + nombreCliente.Primer_Apellido + " " + nombreCliente.Segundo_Apellido;

                this.hdCedula.Value = this.txtcedulaBuscar.Text;

                this.hdIDAdiccion.Value = datosCliente.ID.ToString();

            }


        }

        void cargaAdicciones()
        {


            siglo21Entities1 oCarga = new siglo21Entities1();

            ///Se indica al dropdownlist la fuente de datos que va a tener

            this.ddAdicciones.DataSource = oCarga.sp_SeleccionaAdicciones();

            //indicarle al dropdownlist que se muestre

            this.ddAdicciones.DataBind();

        }

        void cargaCodigoAdiccion()
        {


            BLAdicciones_Cliente oAdiccion = new BLAdicciones_Cliente();

            sp_SeleccionaUnaAdiccion_Result adiccion = oAdiccion.RetornaAdicionID(Convert.ToInt16(this.ddAdicciones.SelectedValue));

            this.txtCodigo.Text = adiccion.Codigo;


        }

        void cargaCodigos()
        {

            siglo21Entities1 oCargaCodigos = new siglo21Entities1();

            ///Se indica al dropdownlist la fuente de datos que va a tener

            this.ddCodigoBurcar.DataSource = oCargaCodigos.sp_SeleccionaAdicciones();

            //indicarle al dropdownlist que se muestre

            this.ddCodigoBurcar.DataBind();

        }


        void eliminarRegistro()
        {
            

            if (this.IsValid)
            {

                string mensaje = "";

                BLAdicciones_Cliente oElimina = new BLAdicciones_Cliente();

                bool resultado = false;

                try
                {

                    int id = Convert.ToInt16(this.hdIDAdiccion.Value);

                    /// se llama al procedimiento almacenado para eliminar la información

                    resultado = oElimina.EliminarAdiccionCliente(id);


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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.cargaDatosBusqueda();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarRegistro();
        }

        protected void ddAdicciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cargaCodigoAdiccion();
        }

        void cargaDatosRegistroEnviado()
        {


            ///Optiene el parámetro enviado del grid

            string parametroID = this.Request.QueryString["id"];

            /// Valida si el parametro es correcto

            if (!string.IsNullOrEmpty(parametroID))
            {

                ///Variable que recibe el parametro enviado

                int ID = Convert.ToInt16(parametroID);

                ///Se trae la información del registro por el ID

                BLAdicciones_Cliente oAdiccionCliente = new BLAdicciones_Cliente();

                sp_SelecionaAdiccionesClienteID_Result datosClienteAdiccion = new sp_SelecionaAdiccionesClienteID_Result();

                ///se almacena la información brindado por el ID

                datosClienteAdiccion = oAdiccionCliente.RetornaAdicionClienteID(ID);

                ////
                ///

                BLAdicciones_Cliente datosAdiccionesCliente = new BLAdicciones_Cliente();

                sp_AdiccionesClienteBuscaDuplicados_Result datosCliente = new sp_AdiccionesClienteBuscaDuplicados_Result();

                ///se almacena la información brindado por el mentodo almacenado de la clase BLAdicionCliente

                datosCliente = datosAdiccionesCliente.consultaDuplicado(datosClienteAdiccion.ID_Adiccion, datosClienteAdiccion.ID_Cliente);

                ///verifica que el objeto retornado no sea nulo

                if (datosCliente == null)
                {

                    Response.Write("<script>alert('La Adicción ingresado no esta asociado a este Cliente')</script>");

                }
                else
                {

                    ///se asigna los valores correspondientes
                    ///

                    this.txtcedulaBuscar.Text = datosClienteAdiccion.ID_Cliente;

                    this.txtcedulaBuscar.ReadOnly = true;

                    this.ddAdicciones.SelectedValue = datosCliente.ID_Adiccion.ToString();

                    this.ddCodigoBurcar.SelectedValue = datosCliente.ID_Adiccion.ToString();

                    this.ddCodigoBurcar.Enabled = false;

                    this.cargaCodigoAdiccion();

                    BLCliente oNombre = new BLCliente();

                    sp_SeleccionaClienteCedula_Result nombreCliente = oNombre.RetornaClienteCed(datosClienteAdiccion.ID_Cliente);

                    this.txtNombreCompleto.Text = nombreCliente.Nombre + " " + nombreCliente.Primer_Apellido + " " + nombreCliente.Segundo_Apellido;

                    this.hdCedula.Value = this.txtcedulaBuscar.Text;

                    this.hdIDAdiccion.Value = datosCliente.ID.ToString();

                }

            }

        }
    }
}