﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Laundry
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class kitchenEntities : DbContext
    {
        public kitchenEntities()
            : base("name=kitchenEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Anbar> Anbar { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<ErsalNashode> ErsalNashode { get; set; }
        public virtual DbSet<Manage> Manage { get; set; }
        public virtual DbSet<NameService> NameService { get; set; }
        public virtual DbSet<Prodoct> Prodoct { get; set; }
        public virtual DbSet<Reg> Reg { get; set; }
        public virtual DbSet<ReportService> ReportService { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServicesPrice> ServicesPrice { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<WhiteSms> WhiteSms { get; set; }
    }
}
