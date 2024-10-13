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
    
    public partial class MASCOTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MASCOTA()
        {
            this.CIRUGIAs = new HashSet<CIRUGIA>();
            this.CONSULTAMEDICAs = new HashSet<CONSULTAMEDICA>();
            this.FACTURAs = new HashSet<FACTURA>();
            this.HISTORIA_MEDICA = new HashSet<HISTORIA_MEDICA>();
            this.HOSPITALIZACIONs = new HashSet<HOSPITALIZACION>();
        }
    
        public int ID_Mascota { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public Nullable<int> ID_Especie { get; set; }
        public Nullable<int> ID_Propietario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CIRUGIA> CIRUGIAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONSULTAMEDICA> CONSULTAMEDICAs { get; set; }
        public virtual ESPECIE ESPECIE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FACTURA> FACTURAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIA_MEDICA> HISTORIA_MEDICA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOSPITALIZACION> HOSPITALIZACIONs { get; set; }
        public virtual PROPIETARIO PROPIETARIO { get; set; }
    }
}