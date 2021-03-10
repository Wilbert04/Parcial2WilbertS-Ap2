﻿using Microsoft.EntityFrameworkCore;
using SegundoParcial_AP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial_AP.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Cobros> Cobros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data/CobrosDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Clientes>().HasData(new Clientes() { Nombres = "FERRETERIA GAMA" });

            modelBuilder.Entity<Ventas>().HasData(new Ventas() { Fecha = new DateTime(2020, 09, 01), ClienteId = 1, Monto = 1000, Balance = 1000 });

            modelBuilder.Entity<Ventas>().HasData(new Ventas() { Fecha = new DateTime(2020, 10, 01), ClienteId = 1, Monto = 900, Balance = 800 });



            modelBuilder.Entity<Clientes>().HasData(new Clientes() { ClienteId = 2, Nombres = "AVALON DISCO" });

            modelBuilder.Entity<Ventas>().HasData(new Ventas() { VentaId = 3, Fecha = new DateTime(2020, 09, 01), ClienteId = 2, Monto = 2000, Balance = 2000 });

            modelBuilder.Entity<Ventas>().HasData(new Ventas() { VentaId = 4, Fecha = new DateTime(2020, 10, 01), ClienteId = 2, Monto = 1900, Balance = 1800 });



            modelBuilder.Entity<Clientes>().HasData(new Clientes() { ClienteId = 3, Nombres = "PRESTAMOS CEFIPROD" });

            modelBuilder.Entity<Ventas>().HasData(new Ventas() { VentaId = 5, Fecha = new DateTime(2020, 09, 01), ClienteId = 3, Monto = 3000, Balance = 3000 });

            modelBuilder.Entity<Ventas>().HasData(new Ventas() { VentaId = 6, Fecha = new DateTime(2020, 10, 01), ClienteId = 3, Monto = 2900, Balance = 1900 });

        }

    }

}
