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
    
    public partial class PRUEBA
    {
        public int id_prueba { get; set; }
        public System.DateTime fec_pruebas { get; set; }
        public System.TimeSpan hora_inicio_p { get; set; }
        public System.TimeSpan hora_termino_p { get; set; }
        public System.TimeSpan tiem_prueba { get; set; }
        public string id_combu { get; set; }
        public string id_electr { get; set; }
        public string id_termo { get; set; }
        public string id_retencion { get; set; }
        public string id_basc { get; set; }
        public string id_resist { get; set; }
        public string id_trab { get; set; }
        public string id_nivelac { get; set; }
        public int id_condicion { get; set; }
        public string id_fuga { get; set; }
        public string n_planilla { get; set; }
        public string id_c_llama { get; set; }
    
        public virtual CONDICION_ENSAYO CONDICION_ENSAYO { get; set; }
        public virtual ENSAYO_BASCUL ENSAYO_BASCUL { get; set; }
        public virtual ENSAYO_C_LLAMA ENSAYO_C_LLAMA { get; set; }
        public virtual ENSAYO_COMB ENSAYO_COMB { get; set; }
        public virtual ENSAYO_ELECTR ENSAYO_ELECTR { get; set; }
        public virtual ENSAYO_FUGA_G ENSAYO_FUGA_G { get; set; }
        public virtual ENSAYO_NIVELAC ENSAYO_NIVELAC { get; set; }
        public virtual ENSAYO_RESIST ENSAYO_RESIST { get; set; }
        public virtual ENSAYO_RETENCION ENSAYO_RETENCION { get; set; }
        public virtual ENSAYO_TERMOCUP ENSAYO_TERMOCUP { get; set; }
        public virtual ENSAYO_TRABAM ENSAYO_TRABAM { get; set; }
        public virtual INFORME_PRUEBA INFORME_PRUEBA { get; set; }
    }
}
