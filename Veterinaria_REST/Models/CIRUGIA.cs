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
    
    public partial class CIRUGIA
    {
        public int ID_Cirugia { get; set; }
        public Nullable<System.DateTime> Fecha_Cirugia { get; set; }
        public string Tipo_Cirugia { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> ID_Mascota { get; set; }
        public Nullable<int> ID_Veterinario { get; set; }

        [JsonIgnore]
        public virtual MASCOTA MASCOTA { get; set; }
        [JsonIgnore]
        public virtual VETERINARIO VETERINARIO { get; set; }
    }
}
