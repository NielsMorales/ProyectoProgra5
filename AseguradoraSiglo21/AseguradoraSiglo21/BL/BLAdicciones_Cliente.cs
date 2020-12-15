using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AseguradoraSiglo21.Modelos;

namespace AseguradoraSiglo21.BL
{
    public class BLAdicciones_Cliente
    {

        /// <summary>
        /// Variable del modelo EF, contiene todos los objetos
        /// que fueron seleccionados de la base de datos
        /// </summary>

        siglo21Entities1 modeloBD = new siglo21Entities1();

        public bool InsertaAdiccionCliente(int pID_Adiccion, string pCedula)
        {

            /// Esta variable lleva el contéo de los registros afectados 
            /// al realizar un insert en la tabla de Adicciones
            /// rgistro afectados debe ser mayor a 0 

            int registrosAfectados = 0;

            registrosAfectados = this.modeloBD.sp_InsertaAdiccion_Cliente(pID_Adiccion, pCedula);

            return registrosAfectados > 0;

        }

        /// <summary>
        /// Este método retorna todos los registros de la tabla Adicciones Cliente
        /// </summary>
        /// <returns></returns>

        public List<sp_SeleccionaAdicciones_Cliente_Result> RetornaAdiccionesCliente(string pCedula)
        {

            /// crea la variable que se retornará con la información de Adicciones

            List<sp_SeleccionaAdicciones_Cliente_Result> resultado = new List<sp_SeleccionaAdicciones_Cliente_Result>();

            /// asigna a la variable el resultado de la consulta a la BD

            resultado = this.modeloBD.sp_SeleccionaAdicciones_Cliente(pCedula).ToList();

            /// se retorna el valor

            return resultado;

        }

        /// <summary>
        /// Este método modifíca un registro de la tabla Adicciones Cliente
        /// </summary>
        /// <returns></returns>

        public bool ModificaAdiccionCliente(int pIdAdiccionCliente, int pID_Adiccion, string pCedula)
        {

            /// Esta variable lleva el contéo de los registros afectados 
            /// al realizar un insert en la tabla de Adicciones
            /// rgistro afectados debe ser mayor a 0 

            int registrosAfectados = 0;

            registrosAfectados = this.modeloBD.sp_ModificaRegistroAdiccion_Cliente(pIdAdiccionCliente, pID_Adiccion, pCedula);


            return registrosAfectados > 0;

        }

        public bool EliminarAdiccionCliente(int pIdAdiccionCliente)
        {

            /// Esta variable lleva el contéo de los registros afectados 
            /// al realizar un insert en la tabla de Adiccion Cliente
            /// rgistro afectados debe ser mayor a 0 

            int registrosAfectados = 0;

            registrosAfectados = this.modeloBD.sp_EliminaRegistroAdicciones_Cliente(pIdAdiccionCliente);

            return registrosAfectados > 0;

        }

        public sp_AdiccionesClienteBuscaDuplicados_Result consultaDuplicado(int pCodigo, string pCedula) 
        {

            /// crea la variable que se retornará con la información de Adicciones

            sp_AdiccionesClienteBuscaDuplicados_Result resultado = new sp_AdiccionesClienteBuscaDuplicados_Result();

            /// asigna a la variable el resultado de la consulta a la BD

            resultado = this.modeloBD.sp_AdiccionesClienteBuscaDuplicados(pCodigo,pCedula).FirstOrDefault();

            /// se retorna el valor

            return resultado;

        }

        public sp_SeleccionaUnaAdiccion_Result RetornaAdicionID(int pID)
        {

            /// crea la variable que se retornará con la información del cliente

            sp_SeleccionaUnaAdiccion_Result Resultado = new sp_SeleccionaUnaAdiccion_Result();

            /// asigna a la variable el resultado de la consulta a la BD

            Resultado = this.modeloBD.sp_SeleccionaUnaAdiccion(pID).FirstOrDefault();

            return Resultado;


        }

        public List<sp_ClienteBusquedaAdicciones_Result> RetornAdiccionesClienteBusqueda(string pCedula = null, string pCodigoAdiccion = null, string pNombre = null, string pApellido1 = null, string pApellido2 = null)
        {


            /// crea la variable que se retornará con la información del cliente

            List<sp_ClienteBusquedaAdicciones_Result> resultado = new List<sp_ClienteBusquedaAdicciones_Result>();

            /// asigna a la variable el resultado de la consulta a la BD

            resultado = this.modeloBD.sp_ClienteBusquedaAdicciones(pCedula, pCodigoAdiccion,pNombre,pApellido1,pApellido2).ToList();

            /// se retorna el valor

            return resultado;

        }

        public sp_SelecionaAdiccionesClienteID_Result RetornaAdicionClienteID(int pID)
        {

            /// crea la variable que se retornará con la información del cliente

            sp_SelecionaAdiccionesClienteID_Result Resultado = new sp_SelecionaAdiccionesClienteID_Result();

            /// asigna a la variable el resultado de la consulta a la BD

            Resultado = this.modeloBD.sp_SelecionaAdiccionesClienteID(pID).FirstOrDefault();

            return Resultado;


        }

        public List<sp_AdiccionesClienteReporte_Result> ReporteAdiccionesCliente(string pCedula = null, string pNombre = null, string pApellido1 = null, string pApellido2 = null, string pCodigo = null, string pNombreAdiccion = null)
        {


            /// crea la variable que se retornará con la información del cliente

            List<sp_AdiccionesClienteReporte_Result> resultado = new List<sp_AdiccionesClienteReporte_Result>();

            /// asigna a la variable el resultado de la consulta a la BD

            resultado = this.modeloBD.sp_AdiccionesClienteReporte(pCedula, pNombre, pApellido1, pApellido2,pCodigo,pNombreAdiccion).ToList();

            /// se retorna el valor

            return resultado;

        }
    }
}