using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AseguradoraSiglo21.Modelos;

namespace AseguradoraSiglo21.BL
{
    public class BLCobertura_Poliza
    {

        /// <summary>
        /// Variable del modelo EF, contiene todos los objetos
        /// que fueron seleccionados de la base de datos
        /// </summary>

        siglo21Entities1 modeloBD = new siglo21Entities1();

        public bool InsertaCoberturaPoliza(string pNombre, string pDescripcion, float pPorcentaje)
        {

            /// Esta variable lleva el contéo de los registros afectados 
            /// al realizar un insert en la tabla de Cobertura de Poliza
            /// rgistro afectados debe ser mayor a 0 

            int registrosAfectados = 0;

            registrosAfectados = this.modeloBD.sp_InsertaCobertura_Poliza(pNombre, pDescripcion, pPorcentaje);

            return registrosAfectados > 0;

        }

        /// <summary>
        /// Este método retorna todos los registros de la tabla Cobertura Poliza
        /// No requiere parámatros
        /// </summary>
        /// <returns></returns>

        public List<sp_SeleccionaTodo_Cobertura_Poliza_Result> RetornaCoberturaPolizas()
        {

            /// crea la variable que se retornará con la información de Cobertura Poliza

            List<sp_SeleccionaTodo_Cobertura_Poliza_Result> resultado = new List<sp_SeleccionaTodo_Cobertura_Poliza_Result>();

            /// asigna a la variable el resultado de la consulta a la BD

            resultado = this.modeloBD.sp_SeleccionaTodo_Cobertura_Poliza().ToList();

            /// se retorna el valor

            return resultado;

        }

        /// <summary>
        /// Este método retorna una busqueda de Cobertura Poliza con el nombre
        /// </summary>
        /// <param name="pNombreCobertura"></param>
        /// <returns></returns>

        public sp_SeleccionaUnaCoberturaPoliza_Result RetornaCoberturaPoliza(string pNombreCobertura)
        {

            /// crea la variable que se retornará con la información de Cobertura Poliza

            sp_SeleccionaUnaCoberturaPoliza_Result Resultado = new sp_SeleccionaUnaCoberturaPoliza_Result();

            /// asigna a la variable el resultado de la consulta a la BD

            Resultado = this.modeloBD.sp_SeleccionaUnaCoberturaPoliza(pNombreCobertura).FirstOrDefault();

            return Resultado;


        }

        /// <summary>
        /// Este método modifíca un registro de la tabla Cobertura Poliza 
        /// por medio del código
        /// </summary>
        /// <returns></returns>

        public bool ModificaCoberturaPoliza(int IdCobertura_Poliza, string pNombre, string pDescripcion, float pPorcentaje)
        {

            /// Esta variable lleva el contéo de los registros afectados 
            /// al realizar un insert en la tabla de Cobertura Poliza 
            /// rgistro afectados debe ser mayor a 0 

            int registrosAfectados = 0;

            registrosAfectados = this.modeloBD.sp_ModificaRegistroCobertura_Poliza(IdCobertura_Poliza, pNombre, pDescripcion, pPorcentaje);


            return registrosAfectados > 0;

        }

        public bool EliminarCoberturaPoliza(int IdCobertura_Poliza)
        {

            /// Esta variable lleva el contéo de los registros afectados 
            /// al realizar un insert en la tabla de Adiccion
            /// rgistro afectados debe ser mayor a 0 

            int registrosAfectados = 0;

            registrosAfectados = this.modeloBD.sp_EliminaRegistroCobertura_Poliza(IdCobertura_Poliza);

            return registrosAfectados > 0;

        }

        public List<sp_CoberturaPolizaBusqueda_Result> RetornaCoberturaPolizaBusqueda(string pNombre = null, string pDescripcion = null)
        {


            /// crea la variable que se retornará con la información del cliente

            List<sp_CoberturaPolizaBusqueda_Result> resultado = new List<sp_CoberturaPolizaBusqueda_Result>();

            /// asigna a la variable el resultado de la consulta a la BD

            resultado = this.modeloBD.sp_CoberturaPolizaBusqueda(pNombre, pDescripcion).ToList();

            /// se retorna el valor

            return resultado;

        }

    }
}