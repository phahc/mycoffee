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
    
    public partial class tonkho
    {
        public string NGAYTHANG { get; set; }
        public int MAMH { get; set; }
        public Nullable<int> SOLUONGDAU { get; set; }
        public Nullable<int> SOLUONGXUAT { get; set; }
        public Nullable<int> SOLUONGTON { get; set; }
        public Nullable<int> SOLUONGNHAP { get; set; }
    
        public virtual product product { get; set; }
    }
}
