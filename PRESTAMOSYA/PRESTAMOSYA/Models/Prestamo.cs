//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PRESTAMOSYA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Prestamo
    {
        public int ID_Prestamo { get; set; }
        public int ID_Empleado { get; set; }
        public decimal Monto_Aprobado { get; set; }
        public int Cuotas { get; set; }
        public decimal Gastos_Cierre { get; set; }
        public string Garante { get; set; }
        public decimal Tasa { get; set; }
        public int ID_Cliente { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Empleado Empleado { get; set; }
    }
}
