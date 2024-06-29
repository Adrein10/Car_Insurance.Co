using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Car_Insurance.Co.Models;

namespace Car_Insurance.Co.Data
{
    public partial class car_insuranceContext : DbContext
    {
        public car_insuranceContext()
        {
        }

        public car_insuranceContext(DbContextOptions<car_insuranceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminDetail> AdminDetails { get; set; } = null!;
        public virtual DbSet<CeoDetail> CeoDetails { get; set; } = null!;
        public virtual DbSet<ClaimInsurance> ClaimInsurances { get; set; } = null!;
        public virtual DbSet<ClaimStatus> ClaimStatuses { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<PlansDetail> PlansDetails { get; set; } = null!;
        public virtual DbSet<UserCarsDetail> UserCarsDetails { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminDetail>(entity =>
            {
                entity.ToTable("admin_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdminEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("admin_email");

                entity.Property(e => e.AdminName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("admin_name");

                entity.Property(e => e.AdminPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("admin_password");

                entity.Property(e => e.RegisterDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CeoDetail>(entity =>
            {
                entity.ToTable("ceo_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CeoEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ceo_email");

                entity.Property(e => e.CeoName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ceo_name");

                entity.Property(e => e.CeoPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ceo_password");
            });

            modelBuilder.Entity<ClaimInsurance>(entity =>
            {
                entity.ToTable("claim_insurance");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClaimStatus).HasColumnName("claim_status");

                entity.Property(e => e.Insurancemonths).HasColumnName("insurancemonths");

                entity.Property(e => e.Planname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("planname");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.ClaimStatusNavigation)
                    .WithMany(p => p.ClaimInsurances)
                    .HasForeignKey(d => d.ClaimStatus)
                    .HasConstraintName("FK__claim_ins__claim__32E0915F");
            });

            modelBuilder.Entity<ClaimStatus>(entity =>
            {
                entity.HasKey(e => e.ClaimId);

                entity.ToTable("claim_status");

                entity.Property(e => e.ClaimId).HasColumnName("claim_id");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("order_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.ClaimId).HasColumnName("claim_id");

                entity.Property(e => e.PlaneId).HasColumnName("plane_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__order_det__car_i__33D4B598");

                entity.HasOne(d => d.Claim)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ClaimId)
                    .HasConstraintName("FK__order_det__claim__36B12243");

                entity.HasOne(d => d.Plane)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.PlaneId)
                    .HasConstraintName("FK__order_det__plane__34C8D9D1");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__order_det__statu__35BCFE0A");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("Order_Status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<PlansDetail>(entity =>
            {
                entity.ToTable("plans_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Carcc).HasColumnName("carcc");

                entity.Property(e => e.Insurancemonths).HasColumnName("insurancemonths");

                entity.Property(e => e.Planname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("planname");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<UserCarsDetail>(entity =>
            {
                entity.ToTable("user_cars_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Carcolor)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("carcolor");

                entity.Property(e => e.Carmodel).HasColumnName("carmodel");

                entity.Property(e => e.Carname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("carname");

                entity.Property(e => e.Carnumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("carnumber");

                entity.Property(e => e.Carrcc).HasColumnName("carrcc");

                entity.Property(e => e.Chasisnumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("chasisnumber");

                entity.Property(e => e.Enginenumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("enginenumber");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCarsDetails)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__user_cars__useri__37A5467C");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.ToTable("user_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Usercontact).HasColumnName("usercontact");

                entity.Property(e => e.Useremail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("useremail");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Userpassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("userpassword");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
