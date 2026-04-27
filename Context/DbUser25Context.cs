using System;
using System.Collections.Generic;
using Demo2704.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo2704.Context;

public partial class DbUser25Context : DbContext
{
    public DbUser25Context()
    {
    }

    public DbUser25Context(DbContextOptions<DbUser25Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderproduct> Orderproducts { get; set; }

    public virtual DbSet<Pickuppoint> Pickuppoints { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("host=192.168.200.10; username=user25; database=db_user25; password=user25");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Manufacturerid).HasName("manufacturer_pkey");

            entity.ToTable("manufacturer");

            entity.Property(e => e.Manufacturerid).HasColumnName("manufacturerid");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Orderdeliverydate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("orderdeliverydate");
            entity.Property(e => e.Orderpickuppointid).HasColumnName("orderpickuppointid");
            entity.Property(e => e.Orderstatusid).HasColumnName("orderstatusid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Orderpickuppoint).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Orderpickuppointid)
                .HasConstraintName("orders_pickuppoint_fk");

            entity.HasOne(d => d.Orderstatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Orderstatusid)
                .HasConstraintName("orders_statuses_fk");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("orders_users_fk");
        });

        modelBuilder.Entity<Orderproduct>(entity =>
        {
            entity.HasKey(e => e.Orderproductid).HasName("orderproduct_pkey");

            entity.ToTable("orderproduct");

            entity.Property(e => e.Orderproductid).HasColumnName("orderproductid");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderproducts)
                .HasForeignKey(d => d.Orderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderproduct_orders_fk");

            entity.HasOne(d => d.Product).WithMany(p => p.Orderproducts)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("orderproduct_product_fk");
        });

        modelBuilder.Entity<Pickuppoint>(entity =>
        {
            entity.HasKey(e => e.Pickuppointid).HasName("pickuppoint_pkey");

            entity.ToTable("pickuppoint");

            entity.Property(e => e.Pickuppointid).HasColumnName("pickuppointid");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Productid).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Productarticlenumber)
                .HasMaxLength(100)
                .HasColumnName("productarticlenumber");
            entity.Property(e => e.Productcategoryid).HasColumnName("productcategoryid");
            entity.Property(e => e.Productcost)
                .HasPrecision(19, 2)
                .HasColumnName("productcost");
            entity.Property(e => e.Productdescription).HasColumnName("productdescription");
            entity.Property(e => e.Productdiscountamount).HasColumnName("productdiscountamount");
            entity.Property(e => e.Productmanufacturerid).HasColumnName("productmanufacturerid");
            entity.Property(e => e.Productname).HasColumnName("productname");
            entity.Property(e => e.Productphoto).HasColumnName("productphoto");
            entity.Property(e => e.Productquantityinstock).HasColumnName("productquantityinstock");
            entity.Property(e => e.Productstatus).HasColumnName("productstatus");

            entity.HasOne(d => d.Productcategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.Productcategoryid)
                .HasConstraintName("product_category_fk");

            entity.HasOne(d => d.Productmanufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.Productmanufacturerid)
                .HasConstraintName("product_manufacturer_fk");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("role_pkey");

            entity.ToTable("role");

            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Rolename)
                .HasMaxLength(100)
                .HasColumnName("rolename");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Statusid).HasName("statuses_pkey");

            entity.ToTable("statuses");

            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Userlogin).HasColumnName("userlogin");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
            entity.Property(e => e.Userpassword).HasColumnName("userpassword");
            entity.Property(e => e.Userpatronymic)
                .HasMaxLength(100)
                .HasColumnName("userpatronymic");
            entity.Property(e => e.Userrole).HasColumnName("userrole");
            entity.Property(e => e.Usersurname)
                .HasMaxLength(100)
                .HasColumnName("usersurname");

            entity.HasOne(d => d.UserroleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Userrole)
                .HasConstraintName("users_role_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
