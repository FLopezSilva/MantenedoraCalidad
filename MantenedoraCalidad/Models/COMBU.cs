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
    
    public partial class COMBU
    {
        public int id_comb { get; set; }
        public string nom_quemador { get; set; }
        public string nom_posicion { get; set; }
        public Nullable<float> co { get; set; }
        public Nullable<float> co_2 { get; set; }
        public Nullable<float> co_n { get; set; }
        public Nullable<float> cumple_comb { get; set; }
        public string id_combu { get; set; }
    
        public virtual ENSAYO_COMB ENSAYO_COMB { get; set; }
    }
}