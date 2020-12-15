using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AseguradoraSiglo21.Modelos;

namespace AseguradoraSiglo21.BL
{
    public class BLRegistro_Poliza
    {

        /// <summary>
        /// Variable del modelo EF, contiene todos los objetos
        /// que fueron seleccionados de la base de datos
        /// </summary>

        siglo21Entities1 modeloBD = new siglo21Entities1();

        public bool InsertaRegistroPoliza(float pMonto_Asegurado, float pPorcentaje_Cobertura, int pNumero_Adicciones, float pMonto_Adicciones,

                                          float pPrima_Antes_Impuesto, float pImpuestos, float pPrima_Final, int pID_Cobertura_Poliza, string CedulaCliente, DateTime fecha_Vencimiento)
        {

            /// Esta variable lleva el contéo de los registros afectados 
            /// al realizar un insert en la tabla de Registro Poliza
            /// rgistro afectados debe ser mayor a 0 

            int registrosAfectados = 0;

            registrosAfectados = this.modeloBD.sp_InsertaRegistroPoliza(pMonto_Asegurado, pPorcentaje_Cobertura, pNumero_Adicciones, pMonto_Adicciones,

                                                                         pPrima_Antes_Impuesto, pImpuestos, pPrima_Final, pID_Cobertura_Poliza, CedulaCliente,fecha_Vencimiento);

            return registrosAfectados > 0;

        }

        /// <summary>
        /// Este método retorna todos los registros de la tabla Registro Poliza
        /// No requiere parámatros
        /// </summary>
        /// <returns></returns>

        public List<sp_SeleccionaRegistroPoliza_Result> RetornaRegistroPolizaCliente(string pCedulaCliente)
        {

            /// crea la variable que se retornará con la información de Registro Poliza

            List<sp_SeleccionaRegistroPoliza_Result> resultado = new List<sp_SeleccionaRegistroPoliza_Result>();

            /// asigna a la variable el resultado de la consulta a la BD

            resultado = this.modeloBD.sp_SeleccionaRegistroPoliza(pCedulaCliente).ToList();

            /// se retorna el valor

            return resultado;

        }

        /// <summary>
        /// Este método modifíca un registro de la tabla Registro Poliza
        /// por medio del código
        /// </summary>
        /// <param name="pIdAdiccion"></param>
        /// <returns></returns>

        public bool ModificaRegistroPolizaCliente(int pIdPoliza, float pMonto_Asegurado, float pPorcentaje_Cobertura, int pNumero_Adicciones, float pMonto_Adicciones,

                                                  float pPrima_Antes_Impuesto, float pImpuestos, float pPrima_Final, int pID_Cobertura_Poliza, string CedulaCliente, DateTime fecha_vencimiento)
        {

            /// Esta variable lleva el contéo de los registros afectados 
            /// al realizar un insert en la tabla de Registro Poliza
            /// rgistro afectados debe ser mayor a 0 

            int registrosAfectados = 0;

            registrosAfectados = this.modeloBD.sp_RegistroPolizaModifica(pIdPoliza, pMonto_Asegurado, pPorcentaje_Cobertura, pNumero_Adicciones, pMonto_Adicciones, pPrima_Antes_Impuesto,

                                                                         pImpuestos, pPrima_Final, pID_Cobertura_Poliza, CedulaCliente,fecha_vencimiento);


            return registrosAfectados > 0;

        }

        public bool EliminarPolizaCliente(int pIdPoliza)
        {

            /// Esta variable lleva el contéo de los registros afectados 
            /// al realizar un insert en la tabla de Registro Poliza
            /// rgistro afectados debe ser mayor a 0 

            int registrosAfectados = 0;

            registrosAfectados = this.modeloBD.sp_EliminaRegistroPoliza(pIdPoliza);

            return registrosAfectados > 0;

        }

        public sp_CoberturaPolizaBuscaUna_Result RetornaCoberturaDescripcion(string pNombre)
        {

            /// crea la variable que se retornará con la información del cliente

            sp_CoberturaPolizaBuscaUna_Result Resultado = new sp_CoberturaPolizaBuscaUna_Result();

            /// asigna a la variable el resultado de la consulta a la BD

            Resultado = this.modeloBD.sp_CoberturaPolizaBuscaUna(pNombre).FirstOrDefault();

            return Resultado;


        }

        public sp_CantidadAdCliente_Result RetornaCatidadAdiccionesCliente(string pCedula) {


            /// crea la variable que se retornará con la información del cliente

            sp_CantidadAdCliente_Result Resultado = new sp_CantidadAdCliente_Result();

            /// asigna a la variable el resultado de la consulta a la BD

            Resultado = this.modeloBD.sp_CantidadAdCliente(pCedula).FirstOrDefault();

            return Resultado;

        }

        /// <summary>
        /// Este método calcula el monto a pagar por cada adicción del cliente
        /// </summary>
        /// <param name="pMontoAsegurado"></param>
        /// <param name="pCantidadAdicciones"></param>
        /// <returns></returns>
        public double CalculaMontoAdicciones(double pMontoAsegurado, int pCantidadAdicciones) {

            double calculoAdicciones = 0;

            if (pCantidadAdicciones == 1)
            {

                calculoAdicciones = pMontoAsegurado * 0.05;

            }
            else if (pCantidadAdicciones >= 2 && pCantidadAdicciones <= 3)
            {
                calculoAdicciones = pMontoAsegurado * 0.10;
            }
            else if (pCantidadAdicciones > 3)
            {
                calculoAdicciones = pMontoAsegurado * 0.15;
            }
            else
            {
                calculoAdicciones = pMontoAsegurado * 0;
            }


            return calculoAdicciones;

        }

        public sp_RegistroPolizaBusquedaID_Result RetornaDatosPoliza (int pID)
        {


            /// crea la variable que se retornará con la información del cliente

            sp_RegistroPolizaBusquedaID_Result Resultado = new sp_RegistroPolizaBusquedaID_Result();

            /// asigna a la variable el resultado de la consulta a la BD

            Resultado = this.modeloBD.sp_RegistroPolizaBusquedaID(pID).FirstOrDefault();

            return Resultado;

        }

        public sp_CoberturaPolizaBuscaID_Result RetornaCoberturaPoliza(int pID)
        {


            /// crea la variable que se retornará con la información del cliente

            sp_CoberturaPolizaBuscaID_Result Resultado = new sp_CoberturaPolizaBuscaID_Result();

            /// asigna a la variable el resultado de la consulta a la BD

            Resultado = this.modeloBD.sp_CoberturaPolizaBuscaID(pID).FirstOrDefault();

            return Resultado;

        }


        public List<sp_PolizaBusqueda_Result> RetornaBusquedaPoliza(string pCedulaCliente, string pNombre, string pApellido1, string pApellido2)
        {

            /// crea la variable que se retornará con la información de Registro Poliza

            List<sp_PolizaBusqueda_Result> resultado = new List<sp_PolizaBusqueda_Result>();

            /// asigna a la variable el resultado de la consulta a la BD

            resultado = this.modeloBD.sp_PolizaBusqueda(pCedulaCliente,pNombre,pApellido1,pApellido2).ToList();

            /// se retorna el valor

            return resultado;

        }



    }
}