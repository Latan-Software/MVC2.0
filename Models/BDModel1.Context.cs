﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC2._0.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyBDatosEntities : DbContext
    {
        public MyBDatosEntities()
            : base("name=MyBDatosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ASISTENCIACARRETERA> ASISTENCIACARRETERA { get; set; }
        public virtual DbSet<BASTIDORESTECHO> BASTIDORESTECHO { get; set; }
        public virtual DbSet<CUBIERTAS> CUBIERTAS { get; set; }
        public virtual DbSet<REMOLQUE> REMOLQUE { get; set; }
        public virtual DbSet<ALFOMBRAS> ALFOMBRAS { get; set; }
        public virtual DbSet<ENTRETENIMIENTO> ENTRETENIMIENTO { get; set; }
        public virtual DbSet<PEDALES> PEDALES { get; set; }
        public virtual DbSet<PERILLASCAMBIO> PERILLASCAMBIO { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<BUJIAS> BUJIAS { get; set; }
        public virtual DbSet<FAJASYMANGUERAS> FAJASYMANGUERAS { get; set; }
        public virtual DbSet<FILTROACEITE> FILTROACEITE { get; set; }
        public virtual DbSet<FILTROCOMBUSTIBLE> FILTROCOMBUSTIBLE { get; set; }
        public virtual DbSet<FILTRODEAIRE> FILTRODEAIRE { get; set; }
        public virtual DbSet<TERMOSTATO> TERMOSTATO { get; set; }
        public virtual DbSet<ALTERNADORES> ALTERNADORES { get; set; }
        public virtual DbSet<DIRECCION> DIRECCION { get; set; }
        public virtual DbSet<ENCENDIDO> ENCENDIDO { get; set; }
        public virtual DbSet<FRENOS> FRENOS { get; set; }
        public virtual DbSet<LUCES> LUCES { get; set; }
        public virtual DbSet<RADIADORES> RADIADORES { get; set; }
        public virtual DbSet<SUSPENCION> SUSPENCION { get; set; }
    }
}
