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
    
    public partial class TABLA_MAESTRO
    {
        public int id_maestro { get; set; }
        public string descrip_metric { get; set; }
        public string descrip_unid_medida { get; set; }
        public string unid_medida { get; set; }
        public double valor_max { get; set; }
        public Nullable<double> valor_min { get; set; }
    }
}
