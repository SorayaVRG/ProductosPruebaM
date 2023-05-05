using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProductosPruebaM.Modelos;

namespace ProductosPruebaM.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Zonas> Zonas { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<PR_PRODUCTOS_Q01> PR_PRODUCTOS_Q01 { get; set; }
        public DbSet<PR_COMPRAS_S01> PR_COMPRAS_S01 { get; set; }
        public DbSet<Trabajadores> Trabajadores { get; set; } // Agrega esta línea para definir el DbSet de Trabajadores
        public DbSet<Compras> Compras { get; set; }
    }
}