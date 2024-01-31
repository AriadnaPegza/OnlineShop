using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace ExamenDeStat
{
  public class ApplicationContext:DbContext
    {
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Comanda> Comands { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Clients");

                entity.HasKey(e => e.CodClient);

                entity.Property(e => e.Nume).IsRequired();
                entity.Property(e => e.Prenume).IsRequired();
                entity.Property(e => e.Adresa).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Telefon).IsRequired();

            });


            modelBuilder.Entity<Comanda>(entity =>
            {
                entity.ToTable("Comands");

                entity.HasKey(e => e.CodComanda);

                entity.Property(e => e.DataComanda).IsRequired();
                entity.Property(e => e.SumaTotala).IsRequired();
        

                entity.HasOne(e => e.client)
                    .WithMany()
                    .HasForeignKey(e => e.CodClient);
            });


}

       

        public ApplicationContext()
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Magazin.db");
        }
    }
}