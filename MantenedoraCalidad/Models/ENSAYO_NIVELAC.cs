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
    
    public partial class ENSAYO_NIVELAC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ENSAYO_NIVELAC()
        {
            this.PRUEBA = new HashSet<PRUEBA>();
        }
    
        public string id_nivelac { get; set; }
        public int niv_puerta_sp { get; set; }
        public int niv_puerta_cp { get; set; }
        public bool cumple_nivelam { get; set; }
        public System.DateTime fecha_nivelac { get; set; }
        public System.TimeSpan hora_inicio_n { get; set; }
        public System.TimeSpan hora_termino_n { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRUEBA> PRUEBA { get; set; }
    }
}