//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace qlkdstDB.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class roominglist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public roominglist()
        {
            this.roominglistd = new HashSet<roominglistd>();
        }
    
        public decimal id_roomlist { get; set; }
        public Nullable<decimal> idtour { get; set; }
        public string tenkhachsan { get; set; }
        public Nullable<System.DateTime> ngaycheckin { get; set; }
        public Nullable<System.DateTime> ngaycheckout { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<roominglistd> roominglistd { get; set; }
    }
}