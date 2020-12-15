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
    public partial class frmAdiccionesEliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {

                this.cargaDatosRegistroEnviado();

            }

        }

        void cargaDatosBusqueda()
        {
            string codigo = this.txtCodigoBuscar.Text;

            this.txtCodigoBuscar.ReadOnly = true;

            BLAdicciones datos = new BLAdicciones();

            sp_SeleccionaUnaAdiccionCodigo_Result datosAdiccion = new sp_SeleccionaUnaAdiccionCodigo_Result();

            ///se almacena la información brindado por el mentodo almacenado de la clase BLAdicciones

            datosAdiccion = datos.RetornaAdiccionPorCodigo(codigo);

            ///verifica que el objeto retornado no sea nulo

            if (datosAdiccion == null)
            {

                Response.Write("<script>alert('El código ingresado no esta en la base de datos')</script>");

            }
            else
            {

                ///se asigna los valores correspondientes
                ///

                this.txtNombre.Text = datosAdiccion.Nombre;

                this.txtCodigo.Text = datosAdiccion.Codigo;

                this.hdID.Value = datosAdiccion.ID.ToString();

            }

        }

        void eliminarRegistro()
        {
            
            if (this.IsValid)
            {

                string mensaje = "";

                BLAdicciones oElimina = new BLAdicciones();

                bool resultado = false;

                try
                {

                    int codigo = Convert.ToInt16 (this.hdID.Value);

                    /// se llama al procedimiento almacenado para eliminar la información

                    resultado = oElimina.EliminarAdiccion(codigo);

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

            string parametroID = this.Request.QueryString["codigo"];

            /// Valida si el parametro es correcto

            if (!string.IsNullOrEmpty(parametroID))
            {

                this.txtCodigoBuscar.Text = parametroID;

                this.txtCodigoBuscar.ReadOnly = true;

                BLAdicciones oAdiccion = new BLAdicciones();

                sp_SeleccionaUnaAdiccionCodigo_Result datosAdicciones = new sp_SeleccionaUnaAdiccionCodigo_Result();

                ///se almacena la información brindado por el mentodo almacenado de la clase BLAdicciones

                datosAdicciones = oAdiccion.RetornaAdiccionPorCodigo(parametroID);

                ///verifica que el objeto retornado no sea nulo

                if (datosAdicciones == null)
                {

                    Response.Write("<script>alert('El nombre ingresado no fue encontrado en la base de Datos')</script>");

                }

                else
                {

                    ///se asigna los valores correspondientes

                    this.txtNombre.Text = datosAdicciones.Nombre;

                    this.txtCodigo.Text = datosAdicciones.Codigo;

                    this.hdID.Value = datosAdicciones.ID.ToString();

                }

            }

        }

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {

            this.cargaDatosBusqueda();

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarRegistro();
        }
    }
}