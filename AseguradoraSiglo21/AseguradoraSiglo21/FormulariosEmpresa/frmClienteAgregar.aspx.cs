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
    public partial class frmClienteAgregar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {

                this.cargarCanton();

                this.cargarDistrito();

            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            if (this.IsValid)
            {

                string mensaje = "";

                BLCliente oInserta = new BLCliente();

                bool resultado = false;

                try
                {
                    ///Aquí se va a optener los datos para ingresar la información a la BD

                    string nombre = this.txtNombre.Text;

                    string apellido1 = this.txtApellido1.Text;

                    string apellido2 = this.txtApellido2.Text;

                    string cedula = this.txtCedula.Text;

                    string genero = this.ddGenero.SelectedValue;

                    DateTime fechaNacimiento = Convert.ToDateTime(this.txtFechanacimiento.Text);

                    string direccion = this.txtDireccion.Text;

                    string telefono1 = this.txtTelefono1.Text;

                    string telefono2 = this.txtTelefono2.Text;

                    string correo = this.txtCorreo.Text;

                    int idProvincia = Convert.ToInt16(this.ddProvincia.SelectedValue);

                    int idCanton = Convert.ToInt16(this.ddCanton.SelectedValue);

                    int idDistrito = Convert.ToInt16(this.ddDistrito.SelectedValue);

                    

                    /// se llama al procedimiento almacenado para ingresar la información

                   resultado = oInserta.InsertaCliente(cedula,genero,fechaNacimiento,nombre,apellido1,apellido2,direccion,telefono1,telefono2,correo,idProvincia,idCanton,idDistrito);


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
    }
}