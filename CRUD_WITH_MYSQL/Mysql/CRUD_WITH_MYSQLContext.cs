using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUD_WITH_MYSQL.Mysql
{
    public partial class CRUD_WITH_MYSQLContext : DbContext
    {
        public CRUD_WITH_MYSQLContext()
        {
        }

        public CRUD_WITH_MYSQLContext(DbContextOptions<CRUD_WITH_MYSQLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=;Database=CRUD_WITH_MYSQL");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdadeUsuario)
                    .HasColumnName("idadeUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasColumnName("nomeUsuario")
                    .HasColumnType("varchar(50)");
            });
        }
    }
}
