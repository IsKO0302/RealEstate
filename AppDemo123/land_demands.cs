//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppDemo123
{
    using System;
    using System.Collections.Generic;
    
    public partial class land_demands
    {
        public byte Id { get; set; }
        public string Address_City { get; set; }
        public string Address_Street { get; set; }
        public Nullable<int> Address_House { get; set; }
        public Nullable<int> Address_Number { get; set; }
        public Nullable<int> MinPrice { get; set; }
        public Nullable<int> MaxPrice { get; set; }
        public byte AgentId { get; set; }
        public byte ClientId { get; set; }
        public Nullable<int> MinArea { get; set; }
        public Nullable<int> MaxArea { get; set; }
    
        public virtual agents agents { get; set; }
        public virtual clients clients { get; set; }
    }
}
