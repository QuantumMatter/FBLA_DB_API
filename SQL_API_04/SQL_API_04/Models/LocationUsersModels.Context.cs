﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SQL_API_04.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FBLA02Entities : DbContext
    {
        public FBLA02Entities()
            : base("name=FBLA02Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<SQL_API_04.Models.Membership> Memberships { get; set; }
    }
}