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
    public partial class frmClienteEliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {

                this.cargarCanton();

                this.cargarDistrito();

                this.cargaDatosRegistroEnviado();

            }

        }

        void cargarCanton()
        {

            siglo21Entities1 oCarga = new siglo21Entities1();

            ///Se indica al dropdownlist la fuente de datos que va a tener

            this.ddCanton.DataSource = oCarga.sp_SeleccionaCantonesProvincia1(Convert.ToInt16(this.ddProvincia.SelectedValue));

            //indicarle al dropdownlist que se muestre

            this.ddCanton.DataBind();



        }

        void cargarDistrito()
        {

            siglo21Entities1 oCarga = new siglo21Entities1();

            ///Se indica al dropdownlist la fuente de datos que va a tener

            this.ddDistrito.DataSource = oCarga.sp_SeleccionaDistritosPorCanton(Convert.ToInt16(this.ddCanton.SelectedValue));

            //indicarle al dropdownlist que se muestre

            this.ddDistrito.DataBind();



        }

        protected void ddProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.cargarCanton();

            this.cargarDistrito();

        }

        protected void ddCanton_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.cargarDistrito();

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            this.cargaDatosBusqueda();

        }

        void cargaDatosBusqueda()
        {

            string cedulaBusqueda = txtcedulaBuscar.Text;

            txtcedulaBuscar.ReadOnly = true;

            BLCliente datos = new BLCliente();

            sp_SeleccionaClienteCedula_Result datosCliente = new sp_SeleccionaClienteCedula_Result();

            ///se almacena la información brindado por el mentodo almacenado de la clase BLGastoCategoriaModificaR

            datosCliente = datos.RetornaClienteCed(cedulaBusqueda);

            ///verifica que el objeto retornado no sea nulo

            if (datosCliente == null)
            {

                Response.Write("<script>alert('El número de Cédula no esta en la base de datos')</script>");

            }
            else
            {

                ///se asigna los valores correspondientes
                ///

                this.txtNombre.Text = datosCliente.Nombre;

                this.txtApellido1.Text = datosCliente.Primer_Apellido;

                this.txtApellido2.Text = datosCliente.Segundo_Apellido;

                this.txtCedula.Text = datosCliente.Cedula;

                this.ddGenero.SelectedValue = datosCliente.Genero;

                this.txtFechanacimiento.Text = datosCliente.Fecha_Nacimiento.ToString("yyyy-MM-dd");

                this.ddProvincia.SelectedValue = datosCliente.ID_Provincia.ToString();

                this.cargarCanton();

                this.ddCanton.SelectedValue = datosCliente.ID_Cantón.ToString();

                this.cargarDistrito();

                this.ddDistrito.SelectedValue = datosCliente.ID_Distrito.ToString();

                this.txtDireccion.Text = datosCliente.Direccion;

                this.txtTelefono1.Text = datosCliente.Primer_Teléfono;

                this.txtTelefono2.Text = datosCliente.Segundo_Teléfono;

                this.txtCorreo.Text = datosCliente.Correo;

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

                BLCliente oElimina = new BLCliente();

                bool resultado = false;

                try
                {

                    string cedulaEliminar = txtcedulaBuscar.Text;

                    /// se llama al procedimiento almacenado para eliminar la información

                    resultado = oElimina.EliminarCliente(cedulaEliminar);


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

        void cargaDatosRegistroEnviado()
        {


            ///Optiene el parámetro enviado del grid

            string parametroID = this.Request.QueryString["Cedula"];

            /// Valida si el parametro es correcto

            if (!string.IsNullOrEmpty(parametroID))
            {

                string cedulaBusqueda = parametroID;

                txtcedulaBuscar.Text = cedulaBusqueda;

                txtcedulaBuscar.ReadOnly = true;

                BLCliente datos = new BLCliente();

                sp_SeleccionaClienteCedula_Result datosCliente = new sp_SeleccionaClienteCedula_Result();

                ///se almacena la información brindado por el mentodo almacenado de la clase BLGastoCategoriaModificaR

                datosCliente = datos.RetornaClienteCed(cedulaBusqueda);

                ///verifica que el objeto retornado no sea nulo

                if (datosCliente == null)
                {

                    Response.Write("<script>alert('El número de Cédula no esta en la base de datos')</script>");

                }
                else
                {

                    ///se asigna los valores correspondientes
                    ///

                    this.txtNombre.Text = datosCliente.Nombre;

                    this.txtApellido1.Text = datosCliente.Primer_Apellido;

                    this.txtApellido2.Text = datosCliente.Segundo_Apellido;

                    this.txtCedula.Text = datosCliente.Cedula;

                    this.ddGenero.SelectedValue = datosCliente.Genero;

                    this.txtFechanacimiento.Text = datosCliente.Fecha_Nacimiento.ToString("yyyy-MM-dd");

                    this.ddProvincia.SelectedValue = datosCliente.ID_Provincia.ToString();

                    this.cargarCanton();

                    this.ddCanton.SelectedValue = datosCliente.ID_Cantón.ToString();

                    this.cargarDistrito();

                    this.ddDistrito.SelectedValue = datosCliente.ID_Distrito.ToString();

                    this.txtDireccion.Text = datosCliente.Direccion;

                    this.txtTelefono1.Text = datosCliente.Primer_Teléfono;

                    this.txtTelefono2.Text = datosCliente.Segundo_Teléfono;

                    this.txtCorreo.Text = datosCliente.Correo;


                }

            }

        }
    }
}