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
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    

    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            this.USUARIO_PERFIL = new HashSet<USUARIO_PERFIL>();
        }
    
        public int ID_Usuario { get; set; }
        public Nullable<int> ID_Propietario { get; set; }
        public string userName { get; set; }
        public string Clave { get; set; }
        public string Salt { get; set; }

        [JsonIgnore]
        public virtual PROPIETARIO PROPIETARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO_PERFIL> USUARIO_PERFIL { get; set; }
    }
}
