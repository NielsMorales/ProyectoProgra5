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
    public partial class frmRegistroPolizaModificar : System.Web.UI.Page
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

            this.txtPorcentajeCobertura.Text = adiccion.Porcentaje.ToString();

            this.hdIDCovertura.Value = adiccion.ID.ToString();

        }

        protected void ddNombrePoliza_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.cargaDescripcion();

        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {

            this.cargaCantidadAdicciones();

        }

        void cargaCantidadAdicciones()
        {


            BLRegistro_Poliza oCantidad = new BLRegistro_Poliza();

            BLCliente oCliente = new BLCliente();

            sp_CantidadAdCliente_Result cantidad = oCantidad.RetornaCatidadAdiccionesCliente(this.txtCedula.Text);

            sp_SeleccionaClienteCedula_Result cliente = oCliente.RetornaClienteCed(this.txtCedula.Text);

            ///verifica que el objeto retornado no sea nulo

            if (cliente == null)
            {

                Response.Write("<script>alert('El número de cédula ingresado no corresponde a ningún cliente')</script>");

            }
            else
            {
                /// una vez validado si el cliente existe se va a cargar el nombre del cliente

                this.txtNombreCompleto.Text = cliente.Nombre + " " + cliente.Primer_Apellido + " " + cliente.Segundo_Apellido;


                if (cantidad == null)
                {
                    ///Si se retorna null en la tabla de adicciones por cliente se va a asignar 0

                    this.txtTotalAdicciones.Text = "0";

                }
                else
                {
                    /// Si hay adicciones registradas se van a cargar la cantidad que el cliente tenga registrados

                    this.txtTotalAdicciones.Text = cantidad.Cantidad.ToString();

                }

            }

        }

        protected void txtMontoAsegurado_TextChanged(object sender, EventArgs e)
        {

            BLRegistro_Poliza oMontoAdicciones = new BLRegistro_Poliza();

            double montoAdicciones = oMontoAdicciones.CalculaMontoAdicciones(Convert.ToDouble(this.txtMontoAsegurado.Text), Convert.ToInt16(this.txtTotalAdicciones.Text));

            this.txtMontoAdicciones.Text = montoAdicciones.ToString();

            ///se realiza la operación prima antes de impuestos

            double montoAsegurado = Convert.ToDouble(this.txtMontoAsegurado.Text);

            double SumaMonAdicionesMonAsegurado = montoAsegurado + montoAdicciones;

            this.txtPrimaAntesImpuestos.Text = SumaMonAdicionesMonAsegurado.ToString();

            ///se realiza el cálculo del impuesto de ventas

            double trecePociento = SumaMonAdicionesMonAsegurado * 0.13;

            this.txtImpuestos.Text = trecePociento.ToString();

            ///se realiza la suma del monto total + el impuesto


            double montoTotal = SumaMonAdicionesMonAsegurado + trecePociento;

            this.txtPrimaFinal.Text = montoTotal.ToString();

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
                    Response.Write("<script>alert('Esta Póliza no se puede modificar debido a que ya vencíó')</script>");
                }

            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            cargaDatosBusqueda();
        }

        void cargaNombre(string pCedula) {

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

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            this.modificaRegistro();

        }

        void modificaRegistro()
        {

            if (this.IsValid)
            {

                string mensaje = "";

                BLRegistro_Poliza oModifica = new BLRegistro_Poliza();

                bool resultado = false;

                try
                {
                    ///Aquí se va a optener los datos para ingresar la información a la BD
                    ///

                    int id = Convert.ToInt16(txtIDPoliza.Text);

                    float montoAsegurado = (float)Math.Round(Convert.ToDouble(this.txtMontoAsegurado.Text), 1);

                    float pocentajeCobertura = (float)Convert.ToDouble(this.txtPorcentajeCobertura.Text);

                    int cantidadAdicciones = Convert.ToInt16(this.txtTotalAdicciones.Text);

                    float montoAdicciones = (float)Math.Round(Convert.ToDouble(this.txtMontoAdicciones.Text), 1);

                    float primaAntesImpuestos = (float)Math.Round(Convert.ToDouble(this.txtPrimaAntesImpuestos.Text), 1);

                    float impuestos = (float)Math.Round(Convert.ToDouble(this.txtImpuestos.Text), 1);

                    float primaFinal = (float)Math.Round(Convert.ToDouble(this.txtPrimaFinal.Text), 1);

                    int id_Cobertura_poliza = Convert.ToInt16(this.hdIDCovertura.Value);

                    string cedula = this.txtCedula.Text;

                    DateTime fecha_vencimiento = Convert.ToDateTime(this.txtFechaVencimiento.Text);

                    /// se llama al procedimiento almacenado para ingresar la información

                    resultado = oModifica.ModificaRegistroPolizaCliente(id,montoAsegurado, pocentajeCobertura, cantidadAdicciones, montoAdicciones, primaAntesImpuestos, impuestos, primaFinal, id_Cobertura_poliza, cedula, fecha_vencimiento);

                    mensaje += "El registro fue insertado";


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

                        mensaje += "El registro fue modificado";

                    }

                }

                ///motrar el mensaje

                Response.Write("<script>alert('" + mensaje + "')</script>");


            }


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
                        Response.Write("<script>alert('Esta Póliza no se puede modificar debido a que ya vencíó')</script>");

                        
                    }

                }


            }

        }
    }
}

