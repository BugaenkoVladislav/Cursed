using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Сursovaya.Entities;

namespace Сursovaya.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Buy> Buys { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productsbuy> Productsbuys { get; set; }

    public virtual DbSet<Productsprovide> Productsprovides { get; set; }

    public virtual DbSet<Provide> Provides { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;uid=root;pwd=1234;database=shop", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Buy>(entity =>
        {
            entity.HasKey(e => e.IdBuy).HasName("PRIMARY");

            entity.ToTable("buys");

            entity.HasIndex(e => e.IdClient, "Buys_Clients_fkey_idx");

            entity.HasIndex(e => e.IdEmployee, "Buys_Employees_fkey_idx");

            entity.Property(e => e.IdBuy).HasColumnName("idBuy");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdClient).HasColumnName("idClient");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Buys)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("Buys_Clients_fkey");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Buys)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("Buys_Employees_fkey");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PRIMARY");

            entity.ToTable("clients");

            entity.Property(e => e.IdClient).HasColumnName("idClient");
            entity.Property(e => e.Firstname)
                .HasMaxLength(45)
                .HasColumnName("firstname");
            entity.Property(e => e.Midname)
                .HasMaxLength(45)
                .HasColumnName("midname");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee).HasName("PRIMARY");

            entity.ToTable("employees");

            entity.HasIndex(e => e.Login, "login_UNIQUE").IsUnique();

            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.Firstname)
                .HasMaxLength(45)
                .HasColumnName("firstname");
            entity.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");
            entity.Property(e => e.Midname)
                .HasMaxLength(45)
                .HasColumnName("midname");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PRIMARY");

            entity.ToTable("products");

            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Productsbuy>(entity =>
        {
            entity.HasKey(e => new { e.IdBuy, e.IdProduct })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("productsbuys");

            entity.HasIndex(e => e.IdProduct, "ProductsBuys_Products_fkey_idx");

            entity.Property(e => e.IdBuy).HasColumnName("idBuy");
            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Price)
                .HasPrecision(8, 2)
                .HasColumnName("price");
            entity.Property(e => e.Sum)
                .HasPrecision(8, 2)
                .HasColumnName("sum");

            entity.HasOne(d => d.IdBuyNavigation).WithMany(p => p.Productsbuys)
                .HasForeignKey(d => d.IdBuy)
                .HasConstraintName("ProductsBuys_Buys_fkey");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Productsbuys)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("ProductsBuys_Products_fkey");
        });

        modelBuilder.Entity<Productsprovide>(entity =>
        {
            entity.HasKey(e => new { e.IdProvide, e.IdProduct })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("productsprovides");

            entity.HasIndex(e => e.IdProduct, "ProductsProvides_Products_fkey_idx");

            entity.Property(e => e.IdProvide).HasColumnName("idProvide");
            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.PriceForOne)
                .HasPrecision(8, 2)
                .HasColumnName("priceForOne");
            entity.Property(e => e.Sum)
                .HasPrecision(8, 2)
                .HasColumnName("sum");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Productsprovides)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("ProductsProvides_Products_fkey");

            entity.HasOne(d => d.IdProvideNavigation).WithMany(p => p.Productsprovides)
                .HasForeignKey(d => d.IdProvide)
                .HasConstraintName("ProductsProvides_Provides_fkey");
        });

        modelBuilder.Entity<Provide>(entity =>
        {
            entity.HasKey(e => e.IdProvide).HasName("PRIMARY");

            entity.ToTable("provides");

            entity.HasIndex(e => e.IdProvider, "Provedes_Providers_idx");

            entity.HasIndex(e => e.IdEmployee, "Provides_Employees_fkey_idx");

            entity.Property(e => e.IdProvide).HasColumnName("idProvide");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdProvider).HasColumnName("idProvider");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Provides)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("Provides_Employees_fkey");

            entity.HasOne(d => d.IdProviderNavigation).WithMany(p => p.Provides)
                .HasForeignKey(d => d.IdProvider)
                .HasConstraintName("Provedes_Providers_fkey");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.IdProvider).HasName("PRIMARY");

            entity.ToTable("providers");

            entity.Property(e => e.IdProvider).HasColumnName("idProvider");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .HasColumnName("phoneNumber");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
