//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WelCareForYou_IT1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class House
    {
        public int Id { get; set; }
        public int NumOfRoom { get; set; }
        public int MediumPrice { get; set; }
        public string HouseType { get; set; }
        public string SuburbSuburbName { get; set; }
    
        public virtual Suburb Suburb { get; set; }
    }
}