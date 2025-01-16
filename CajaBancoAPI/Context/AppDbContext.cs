using CajaBanco.DTO.Reportes;
using CajaBancoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CajaBancoAPI.Context
{

    public class AppDbContext:DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Banco> Ban01Banco { get;set; }
        public DbSet<PermisosxPerfil> ListaMenuxPerfil { get; set; }
        public DbSet<Cuenta_Bancaria> Ban01CuentaBancaria { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Banco>().HasNoKey();
            modelBuilder.Entity<Banco>()
                .HasKey(b => new { b.Ban01Empresa, b.Ban01IdBanco });

            // para la db Ban01CuentaBancaria
            modelBuilder.Entity<Cuenta_Bancaria>()
                .HasKey(cb => new { cb.Ban01Empresa, cb.Ban01IdBanco, cb.Ban01IdCuenta });

            modelBuilder.Entity<PermisosxPerfil>().HasNoKey();


            
        }

    }
}
