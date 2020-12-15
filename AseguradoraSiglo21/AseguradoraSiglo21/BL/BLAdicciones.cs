using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AseguradoraSiglo21.Modelos;

namespace AseguradoraSiglo21.BL
{
    public class BLAdicciones
    {

        /// <summary>
        /// Variable del modelo EF, contiene todos los objetos
        /// que fueron seleccionados de la base de datos
        /// </summary>

        siglo21Entities1 modeloBD = new siglo21Entities1();


        public bool InsertaAdiccion(string pNombre, string pCodigo)
        {

            /// Esta variable lleva el contéo de los registros afectados 
            /// al realizar un insert en la tabla de Adicciones
            /// rgistro afectados debe ser mayor a 0 

            int registrosAfectados = 0;

            registrosAfectados = this.modeloBD.sp_InsertaAdiccion(pNombre, pCodigo);

            return registrosAfectados > 0;

        }


        /// <summary>
        /// Este método retorna todos los registros de la tabla Adicciones
        /// No requiere parámatros
        /// </summary>
        /// <returns></returns>

        public List<sp_Selecciona_Todas_Adicciones_Result> RetornaAdicciones()
        {

            /// crea la variable que se retornará con la información de Adicciones

            List<sp_Selecciona_Todas_Adicciones_Result> resultado = new List<sp_Selecciona_Todas_Adicciones_Result>();

            /// asigna a la variable el resultado de la consulta a la BD

            resultado = this.modeloBD.sp_Selecciona_Todas_Adicciones().ToList();

            /// se retorna el valor

            return resultado;

        }

        /// <summary>
        /// Este método retorna una busqueda de Adicciones con el código
        /// </summary>
        /// <param name="pCogigo"></param>
        /// <returns></returns>

        public sp_SeleccionaUnaAdiccionCodigo_Result RetornaAdiccionPorCodigo(string pCodigo)
        {

            /// crea la variable que se retornará con la información de Adicciones

            sp_SeleccionaUnaAdiccionCodigo_Result Resultado = new sp_SeleccionaUnaAdiccionCodigo_Result();

            /// asigna a la variable el resultado de la consulta a la BD

            Resultado = this.modeloBD.sp_SeleccionaUnaAdiccionCodigo(pCodigo).FirstOrDefault();

            return Resultado;


        }

        /// <summary>
        /// Este método modifíca un registro de la tabla Adicciones 
        /// por medio del código
        /// </summary>
        /// <param name="pIdAdiccion"></param>
        /// <returns></returns>

        public bool ModificaAdiccion(int pIdAdiccion, string pNombre, string pCodigo)
        {

            /// Esta variable lleva el contéo de los registros afectados 
            /// al realizar un insert en la tabla de Adicciones
            /// rgistro afectados debe ser mayor a 0 

            int registrosAfectados = 0;

            registrosAfectados = this.modeloBD.sp_ModificaRegistroAdiccion(pIdAdiccion, pNombre, pCodigo);


            return registrosAfectados > 0;

        }

        public bool EliminarAdiccion(int pIdAdiccion)
        {

            /// Esta variable lleva el contéo de los registros afectados 
            /// al realizar un insert en la tabla de Adiccion
            /// rgistro afectados debe ser mayor a 0 

            int registrosAfectados = 0;

            registrosAfectados = this.modeloBD.sp_EliminaRegistroAdicciones(pIdAdiccion);

            return registrosAfectados > 0;

        }

        public List<sp_AdiccionesBusquedas_Result> RetornAdiccionesBusqueda(string pNombre = null, string pCodigo = null)
        {


            /// crea la variable que se retornará con la información del cliente

            List<sp_AdiccionesBusquedas_Result> resultado = new List<sp_AdiccionesBusquedas_Result>();

            /// asigna a la variable el resultado de la consulta a la BD

            resultado = this.modeloBD.sp_AdiccionesBusquedas(pNombre, pCodigo).ToList();

            /// se retorna el valor

            return resultado;

        }



    }
}