//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication12.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Order_ID { get; set; }
        public int Customer_ID { get; set; }
        public int Product_ID { get; set; }
        public Nullable<double> Amount { get; set; }
        public double Total { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}