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
    
    public partial class menu
    {
        public menu()
        {
            this.products = new HashSet<product>();
        }
    
        public int MenuID { get; set; }
        public string MenuCode { get; set; }
        public int ImageIndex { get; set; }
        public int Status { get; set; }
        public Nullable<int> SystemKey { get; set; }
    
        public virtual icon icon { get; set; }
        public virtual ICollection<product> products { get; set; }
    }
}