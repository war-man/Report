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
    
    public partial class Accounting
    {
        public Accounting()
        {
            this.WorkOrder = new HashSet<WorkOrder>();
        }
    
        public int id { get; set; }
        public string inv { get; set; }
        public string chk { get; set; }
        public Nullable<decimal> amtPaid { get; set; }
        public Nullable<decimal> invAmt { get; set; }
        public Nullable<System.DateTime> datePaid { get; set; }
        public Nullable<decimal> disc { get; set; }
    
        public virtual ICollection<WorkOrder> WorkOrder { get; set; }
    }
}
