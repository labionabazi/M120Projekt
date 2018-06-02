﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace M120Projekt.DAL
{
    class Context : DbContext
    {
        public Context() : base("name=M120Connectionstring")
        {
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DAL.Context, M120Projekt.Migrations.Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bewegung>().ToTable("Bewegungen"); // Damit kein "s" angehängt wird an Tabelle
            modelBuilder.Entity<Artikel>().ToTable("Artikel"); // Damit kein "s" angehängt wird an Tabelle
        }
        public DbSet<Bewegung> Bewegung { get; set; }
        public DbSet<Artikel> Artikel { get; set; }
    }
}
