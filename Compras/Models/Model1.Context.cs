﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Compras.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBComprasEntities : DbContext
    {
        public DBComprasEntities()
            : base("name=DBComprasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Orden_de_compra> Orden_de_compra { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Unidades_de_medidas> Unidades_de_medidas { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
        public virtual DbSet<View_GetOrdenCompra> View_GetOrdenCompra { get; set; }
    }
}
