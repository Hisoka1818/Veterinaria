//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Veterinaria_REST.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DETALLESERVICIO
    {
        public int ID_Detalle { get; set; }
        public Nullable<int> ID_Factura { get; set; }
        public Nullable<int> ID_Servicio { get; set; }
    
        public virtual FACTURA FACTURA { get; set; }
        public virtual SERVICIOS_ADICIONALES SERVICIOS_ADICIONALES { get; set; }
    }
}