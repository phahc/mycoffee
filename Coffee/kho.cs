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
    
    public partial class kho
    {
        public kho()
        {
            this.products = new HashSet<product>();
        }
    
        public string makho { get; set; }
        public int manv { get; set; }
        public string tenkho { get; set; }
        public string diachi { get; set; }
        public string sdtb { get; set; }
        public string dtdd { get; set; }
        public string nguoilh { get; set; }
        public string fax { get; set; }
        public string ghichu { get; set; }
        public Nullable<int> tinhtrang { get; set; }
    
        public virtual ICollection<product> products { get; set; }
    }
}