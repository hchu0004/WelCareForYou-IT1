﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BusinessModelContainer : DbContext
    {
        public BusinessModelContainer()
            : base("name=BusinessModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Suburb> Suburbs { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<House> Houses { get; set; }
    }
}
