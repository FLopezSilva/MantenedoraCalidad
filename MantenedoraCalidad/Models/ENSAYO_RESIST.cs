//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MantenedoraCalidad.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ENSAYO_RESIST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ENSAYO_RESIST()
        {
            this.PRUEBA = new HashSet<PRUEBA>();
        }
    
        public string id_resist { get; set; }
        public float resist_puerta { get; set; }
        public bool cumple_resis { get; set; }
        public System.DateTime fecha_resis { get; set; }
        public System.TimeSpan hora_inicio_res { get; set; }
        public System.TimeSpan hora_termino_res { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRUEBA> PRUEBA { get; set; }
    }
}
