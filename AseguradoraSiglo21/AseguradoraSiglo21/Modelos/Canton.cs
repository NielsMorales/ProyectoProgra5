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
    
    public partial class Canton
    {
        public Canton()
        {
            this.Cliente = new HashSet<Cliente>();
            this.Distrito = new HashSet<Distrito>();
            this.Empleado = new HashSet<Empleado>();
        }
    
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int ID_Provincia { get; set; }
    
        public virtual Provincia Provincia { get; set; }
        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Distrito> Distrito { get; set; }
        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
