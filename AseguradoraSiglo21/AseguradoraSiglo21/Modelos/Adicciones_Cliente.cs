//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AseguradoraSiglo21.Modelos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Adicciones_Cliente
    {
        public int ID { get; set; }
        public int ID_Adiccion { get; set; }
        public string ID_Cliente { get; set; }
    
        public virtual Adicciones Adicciones { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
