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
    
    public partial class TERMOC
    {
        public int id_termoc { get; set; }
        public string descrip_pieza { get; set; }
        public float temp_pieza { get; set; }
        public bool cumple_term { get; set; }
        public string id_termo { get; set; }
        public string temp_norma { get; set; }
    
        public virtual ENSAYO_TERMOCUP ENSAYO_TERMOCUP { get; set; }
    }
}
