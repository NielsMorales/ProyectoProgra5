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
    
    public partial class Cliente
    {
        public Cliente()
        {
            this.Adicciones_Cliente = new HashSet<Adicciones_Cliente>();
            this.Registro_Poliza = new HashSet<Registro_Poliza>();
        }
    
        public int ID { get; set; }
        public string Cedula { get; set; }
        public string Genero { get; set; }
        public System.DateTime Fecha_Nacimiento { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Direccion { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Correo_Electronico { get; set; }
        public int ID_Provincia { get; set; }
        public int ID_Canton { get; set; }
        public int ID_Distrito { get; set; }
    
        public virtual ICollection<Adicciones_Cliente> Adicciones_Cliente { get; set; }
        public virtual Canton Canton { get; set; }
        public virtual Distrito Distrito { get; set; }
        public virtual Provincia Provincia { get; set; }
        public virtual ICollection<Registro_Poliza> Registro_Poliza { get; set; }
    }
}
