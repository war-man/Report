//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Orders.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Paids
    {
        public int id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string inv { get; set; }
        public string chk { get; set; }
        public Nullable<double> amtPaid { get; set; }
        public Nullable<double> invAmt { get; set; }
        public Nullable<int> orderId { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
