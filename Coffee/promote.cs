//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Coffee
{
    using System;
    using System.Collections.Generic;
    
    public partial class promote
    {
        public promote()
        {
            this.promote_detail = new HashSet<promote_detail>();
        }
    
        public int PromoteID { get; set; }
        public string PromoteName { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int Deleted { get; set; }
    
        public virtual ICollection<promote_detail> promote_detail { get; set; }
    }
}
