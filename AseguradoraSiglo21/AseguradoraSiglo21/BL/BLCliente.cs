

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AseguradoraSiglo21.Modelos;

namespace AseguradoraSiglo21.BL
{
    public class BLCliente
    {
        /// <summary>
        /// Variable del modelo EF, contiene todos los objetos
        /// que fueron seleccionados de la base de datos
        /// </summary>

        siglo21Entities1 modeloBD = new siglo21Entities1();

        public bool InsertaCliente(string pCedula, string pGenero, DateTime pFecha_Nacimiento, string pNombre, string pApellido1, string pApellido2,

                                   string pDireccion, string pTelefono1, string pTelefono2, string pCorreo_Electronico, int pID_Provincia,

                                   int pID_Canton, int pID_Distrito)
        {


            /// Esta variable lleva el contéo de los registros afectados 
            /// al realizar un insert en la tabla de cliente
            /// rgistro afectados debe ser mayor a 0 

            int registrosAfectados = 0;

            registrosAfectados = this.modeloBD.sp_InsertaCliente(pCedula, pGenero, pFecha_Nacimiento, pNombre, pApellido1, pApellido2, pDireccion,

                                                                pTelefono1, pTelefono2, pCorreo_Electronico, pID_Provincia, pID_Canton, pID_Distrito);

            return registrosAfectados > 0;

        }


        /// <summary>
        /// Este método retorna todos los registros de la tabla clientes
        /// No requiere parámatros
        /// </summary>
        /// <returns></returns>

        public List<sp_SeleccionaTodo_Clientes_Result> RetornaClientes()
        {

            /// crea la variable que se retornará con la información del cliente

            List<sp_SeleccionaTodo_Clientes_Result> resultado = new List<sp_SeleccionaTodo_Clientes_Result>();

            /// asigna a la variable el resultado de la consulta a la BD

            resultado = this.modeloBD.sp_SeleccionaTodo_Clientes().ToList();

            /// se retorna el valor

            return resultado;

        }

        /// <summary>
        /// Este método retorna una busque de cliente con la cédula del cliente 
        /// </summary>
        /// <param name="pID_Cliente"></param>
        /// <returns></returns>

        public sp_SeleccionaClienteCedula_Result RetornaClienteCed(string pID_Cliente)
        {

            /// crea la variable que se retornará con la información del cliente

            sp_SeleccionaClienteCedula_Result Resultado = new sp_SeleccionaClienteCedula_Result();

            /// asigna a la variable el resultado de la consulta a la BD

            Resultado = this.modeloBD.sp_SeleccionaClienteCedula(pID_Cliente).FirstOrDefault();

            return Resultado;


        }

        /// <summary>
        /// Este método modifíca un registro de la tabla cliente 
        /// por medio de la cédula del cliente
        /// </summary>
        /// <param name="pID_ClienteCed"></param>
        /// <returns></returns>

        public bool ModificaCliente(string pID_ClienteCed, string pCedula, string pGenero, DateTime pFecha_Nacimiento, string pNombre, string pApellido1, string pApellido2,

                                    string pDireccion, string pTelefono1, string pTelefono2, string pCorreo_Electronico, int pID_Provincia,

                                    int pID_Canton, int pID_Distrito)
        {

            /// Esta variable lleva el contéo de los registros afectados 
            /// al realizar un insert en la tabla de cliente
            /// rgistro afectados debe ser mayor a 0 

            int registrosAfectados = 0;

            registrosAfectados = this.modeloBD.sp_ModificaRegistroCliente(pID_ClienteCed, pCedula, pGenero, pFecha_Nacimiento, pNombre, pApellido1, pApellido2, pDireccion,

                                                    pTelefono1, pTelefono2, pCorreo_Electronico, pID_Provincia, pID_Canton, pID_Distrito);


            return registrosAfectados > 0;

        }

        public bool EliminarCliente(string pID_ClienteCed)
        {

            /// Esta variable lleva el contéo de los registros afectados 
            /// al realizar un insert en la tabla de cliente
            /// rgistro afectados debe ser mayor a 0 

            int registrosAfectados = 0;

            registrosAfectados = this.modeloBD.sp_EliminaRegistroCliente(pID_ClienteCed);

            return registrosAfectados > 0;

        }

        public List<sp_ClientesBusquedas_Result> RetornaClienteBusqueda(string pNombre = null, string pApellido1 = null, string pApellido2 = null, string pCedula = null) 
        {


            /// crea la variable que se retornará con la información del cliente

            List<sp_ClientesBusquedas_Result> resultado = new List<sp_ClientesBusquedas_Result>();

            /// asigna a la variable el resultado de la consulta a la BD

            resultado = this.modeloBD.sp_ClientesBusquedas(pNombre,pApellido1,pApellido2,pCedula).ToList();

            /// se retorna el valor

            return resultado;

        }



    }
}