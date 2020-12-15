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
    public partial class frmRegistroPolizaEliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {

                this.cargaPolizas();

                this.cargaDescripcion();

                this.cargaDatosRegistroEnviado();

            }


        }

        void cargaPolizas()
        {


            siglo21Entities1 oCarga = new siglo21Entities1();

            ///Se indica al dropdownlist la fuente de datos que va a tener

            this.ddNombrePoliza.DataSource = oCarga.sp_CoberturaPolizaTodo();

            //indicarle al dropdownlist que se muestre

            this.ddNombrePoliza.DataBind();



        }

        void cargaDescripcion()
        {

            BLRegistro_Poliza oCovertura = new BLRegistro_Poliza();

            sp_CoberturaPolizaBuscaUna_Result adiccion = oCovertura.RetornaCoberturaDescripcion(this.ddNombrePoliza.SelectedValue);

            this.txtDescripcionPoliza.Text = adiccion.Descripcion;

            this.hdIDCovertura.Value = adiccion.ID.ToString();

        }

        protected void ddNombrePoliza_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cargaDescripcion();
        }

        void cargaDatosBusqueda()
        {

            int IDpoliza = Convert.ToInt16(this.txtIDPoliza.Text);

            txtIDPoliza.ReadOnly = true;

            BLRegistro_Poliza datos = new BLRegistro_Poliza();

            sp_RegistroPolizaBusquedaID_Result datosPoliza = new sp_RegistroPolizaBusquedaID_Result();


            ///se almacena la información brindado por el mentodo almacenado de la clase BLGastoCategoriaModificaR

            datosPoliza = datos.RetornaDatosPoliza(IDpoliza);

            ///verifica que el objeto retornado no sea nulo

            if (datosPoliza == null)
            {

                Response.Write("<script>alert('El Código ingresado no esta en la base de datos')</script>");

                this.txtIDPoliza.ReadOnly = false;

            }
            else
            {

                if (DateTime.Now < datosPoliza.Fecha_Vencimiento)
                {

                    ///se asigna los valores correspondientes
                    ///

                    BLRegistro_Poliza oPoliza = new BLRegistro_Poliza();

                    sp_CoberturaPolizaBuscaID_Result PolizaDatos = new sp_CoberturaPolizaBuscaID_Result();

                    int IDCobertura = datosPoliza.ID_Cobertura_Poliza;

                    PolizaDatos = oPoliza.RetornaCoberturaPoliza(IDCobertura);

                    this.ddNombrePoliza.SelectedValue = PolizaDatos.Nombre;

                    cargaDescripcionPoliza(PolizaDatos.Nombre);

                    this.txtCedula.Text = datosPoliza.ID_Cliente;

                    this.cargaNombre(datosPoliza.ID_Cliente);

                    this.txtMontoAsegurado.Text = datosPoliza.Monto_Asegurado.ToString();

                    this.txtPorcentajeCobertura.Text = datosPoliza.Porcentaje_Cobertura.ToString();

                    this.txtTotalAdicciones.Text = datosPoliza.Numero_Adicciones.ToString();

                    this.txtMontoAdicciones.Text = datosPoliza.Monto_Adicciones.ToString();

                    this.txtPrimaAntesImpuestos.Text = datosPoliza.Prima_Antes_Impuestos.ToString();

                    this.txtImpuestos.Text = datosPoliza.Impuestos.ToString();

                    this.txtPrimaFinal.Text = datosPoliza.Prima_Final.ToString();

                    this.txtFechaVencimiento.Text = datosPoliza.Fecha_Vencimiento.ToString("yyyy-MM-dd");

                }
                else
                {
                    Response.Write("<script>alert('Esta Póliza no se puede eliminar debido a que ya vencíó')</script>");
                }

            }

        }

        void cargaNombre(string pCedula)
        {

            BLCliente oCliente = new BLCliente();

            sp_SeleccionaClienteCedula_Result cliente = oCliente.RetornaClienteCed(pCedula);

            ///verifica que el objeto retornado no sea nulo

            if (cliente == null)
            {

                Response.Write("<script>alert('El número de cédula ingresado no corresponde a ningún cliente')</script>");

            }
            else
            {
                /// una vez validado si el cliente existe se va a cargar el nombre del cliente

                this.txtNombreCompleto.Text = cliente.Nombre + " " + cliente.Primer_Apellido + " " + cliente.Segundo_Apellido;


            }

        }

        void cargaDescripcionPoliza(string pNombre)
        {

            BLRegistro_Poliza oCovertura = new BLRegistro_Poliza();

            sp_CoberturaPolizaBuscaUna_Result adiccion = oCovertura.RetornaCoberturaDescripcion(pNombre);

            this.txtDescripcionPoliza.Text = adiccion.Descripcion;

            this.hdIDCovertura.Value = adiccion.ID.ToString();

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            cargaDatosBusqueda();

        }

        void cargaDatosRegistroEnviado()
        {


            ///Optiene el parámetro enviado del grid

            string parametroID = this.Request.QueryString["id"];

            /// Valida si el parametro es correcto

            if (!string.IsNullOrEmpty(parametroID))
            {

                int IDpoliza = Convert.ToInt16(parametroID);

                this.txtIDPoliza.Text = parametroID;

                txtIDPoliza.ReadOnly = true;

                BLRegistro_Poliza datos = new BLRegistro_Poliza();

                sp_RegistroPolizaBusquedaID_Result datosPoliza = new sp_RegistroPolizaBusquedaID_Result();


                ///se almacena la información brindado por el mentodo almacenado de la clase BLGastoCategoriaModificaR

                datosPoliza = datos.RetornaDatosPoliza(IDpoliza);

                ///verifica que el objeto retornado no sea nulo

                if (datosPoliza == null)
                {

                    Response.Write("<script>alert('El Código ingresado no esta en la base de datos')</script>");

                    this.txtIDPoliza.ReadOnly = false;

                }
                else
                {

                    if (DateTime.Now < datosPoliza.Fecha_Vencimiento)
                    {

                        ///se asigna los valores correspondientes
                        ///

                        BLRegistro_Poliza oPoliza = new BLRegistro_Poliza();

                        sp_CoberturaPolizaBuscaID_Result PolizaDatos = new sp_CoberturaPolizaBuscaID_Result();

                        int IDCobertura = datosPoliza.ID_Cobertura_Poliza;

                        PolizaDatos = oPoliza.RetornaCoberturaPoliza(IDCobertura);

                        this.ddNombrePoliza.SelectedValue = PolizaDatos.Nombre;

                        cargaDescripcionPoliza(PolizaDatos.Nombre);

                        this.txtCedula.Text = datosPoliza.ID_Cliente;

                        this.cargaNombre(datosPoliza.ID_Cliente);

                        this.txtMontoAsegurado.Text = datosPoliza.Monto_Asegurado.ToString();

                        this.txtPorcentajeCobertura.Text = datosPoliza.Porcentaje_Cobertura.ToString();

                        this.txtTotalAdicciones.Text = datosPoliza.Numero_Adicciones.ToString();

                        this.txtMontoAdicciones.Text = datosPoliza.Monto_Adicciones.ToString();

                        this.txtPrimaAntesImpuestos.Text = datosPoliza.Prima_Antes_Impuestos.ToString();

                        this.txtImpuestos.Text = datosPoliza.Impuestos.ToString();

                        this.txtPrimaFinal.Text = datosPoliza.Prima_Final.ToString();

                        this.txtFechaVencimiento.Text = datosPoliza.Fecha_Vencimiento.ToString("yyyy-MM-dd");

                    }
                    else
                    {
                        Response.Write("<script>alert('Esta Póliza no se puede eliminar debido a que ya vencíó')</script>");


                    }

                }


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

                BLRegistro_Poliza oElimina = new BLRegistro_Poliza();

                bool resultado = false;

                try
                {

                    int codigo = Convert.ToInt16(txtIDPoliza.Text);

                    /// se llama al procedimiento almacenado para eliminar la información

                    resultado = oElimina.EliminarPolizaCliente(codigo);

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