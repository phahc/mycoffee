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
    
    public partial class employeestate
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public System.DateTime Date { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
    
        public virtual employee employee { get; set; }
    }
}
