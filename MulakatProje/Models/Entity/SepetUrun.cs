//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MulakatProje.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class SepetUrun
    {
        public int SepetUrunID { get; set; }
        public Nullable<int> SepetID { get; set; }
        public Nullable<int> Tutar { get; set; }
        public string Aciklama { get; set; }
        public Nullable<int> UrunID { get; set; }
    
        public virtual Sepet Sepet { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
