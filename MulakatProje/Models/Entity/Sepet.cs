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
    
    public partial class Sepet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sepet()
        {
            this.SepetUrun = new HashSet<SepetUrun>();
        }
    
        public int SepetID { get; set; }
        public Nullable<int> MusteriID { get; set; }
    
        public virtual Musteri Musteri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SepetUrun> SepetUrun { get; set; }
    }
}
