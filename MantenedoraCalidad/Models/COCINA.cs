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
    
    public partial class COCINA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COCINA()
        {
            this.CONDICION_ENSAYO = new HashSet<CONDICION_ENSAYO>();
        }
    
        public string cod_cocina { get; set; }
        public System.DateTime mes_certif { get; set; }
        public Nullable<int> solicitud { get; set; }
        public string n_serie_desde { get; set; }
        public string n_serie_hasta { get; set; }
        public string id_modelo { get; set; }
        public string id_n_ensayo { get; set; }
    
        public virtual MODELO MODELO { get; set; }
        public virtual N_ENSAYO N_ENSAYO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONDICION_ENSAYO> CONDICION_ENSAYO { get; set; }
    }
}