using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Car_Insurance.Co.Models
{
    public partial class Car_Insurance_CoContext : DbContext
    {
        public Car_Insurance_CoContext()
        {
        }

        public Car_Insurance_CoContext(DbContextOptions<Car_Insurance_CoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClaimDetail> ClaimDetails { get; set; } = null!;
        public virtual DbSet<CompanyExpense> CompanyExpenses { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerBillingInfo> CustomerBillingInfos { get; set; } = null!;
        public virtual DbSet<CustomerPolicy> CustomerPolicies { get; set; } = null!;
        public virtual DbSet<Estimate> Estimates { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClaimDetail>(entity =>
            {
                entity.HasKey(e => e.ClaimNumber);

                entity.ToTable("Claim_Details");

                entity.Property(e => e.ClaimNumber).HasColumnName("Claim Number");

                entity.Property(e => e.ClaimableAmount).HasColumnName("Claimable amount");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Customer Name");

                entity.Property(e => e.DateOfAccident)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Date of accident");

                entity.Property(e => e.InsuredAmount).HasColumnName("Insured amount");

                entity.Property(e => e.PlaceOfAccident)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Place of accident");

                entity.Property(e => e.PolicyEndDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Policy End Date");

                entity.Property(e => e.PolicyNumber).HasColumnName("Policy number");

                entity.Property(e => e.PolicyStartDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Policy Start Date");
            });

            modelBuilder.Entity<CompanyExpense>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Company_Expenses");

                entity.Property(e => e.AmountOfExpense).HasColumnName("Amount of Expense");

                entity.Property(e => e.DateOfExpense)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Date of Expense");

                entity.Property(e => e.TypeOfExpense)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Type of Expense");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("Customer ID");

                entity.Property(e => e.CustomerAdd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Customer ADD");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Customer Name");

                entity.Property(e => e.CustomerPhoneNumber).HasColumnName("Customer phone number");
            });

            modelBuilder.Entity<CustomerBillingInfo>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("Customer_Billing_Info");

                entity.Property(e => e.CustomerId).HasColumnName("Customer ID");

                entity.Property(e => e.BillNo).HasColumnName("Bill No.");

                entity.Property(e => e.CustomerAddProve)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Customer Add Prove");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Customer Name");

                entity.Property(e => e.CustomerPhoneNumber).HasColumnName("Customer phone number");

                entity.Property(e => e.Date)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PolicyNumber).HasColumnName("Policy number");

                entity.Property(e => e.VehicleBodyNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle body number");

                entity.Property(e => e.VehicleEngineNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle engine number");

                entity.Property(e => e.VehicleModel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle model");

                entity.Property(e => e.VehicleName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle name");

                entity.Property(e => e.VehicleRate).HasColumnName("Vehicle Rate");
            });

            modelBuilder.Entity<CustomerPolicy>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("Customer_Policy");

                entity.Property(e => e.CustomerId).HasColumnName("Customer ID");

                entity.Property(e => e.CustomerAdd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Customer ADD");

                entity.Property(e => e.CustomerAddProve)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Customer Add Prove");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Customer Name");

                entity.Property(e => e.CustomerPhoneNumber).HasColumnName("Customer phone number");

                entity.Property(e => e.PolicyDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Policy date");

                entity.Property(e => e.PolicyDuration).HasColumnName("Policy duration");

                entity.Property(e => e.PolicyNumber).HasColumnName("Policy number");

                entity.Property(e => e.VehicleBodyNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle body number");

                entity.Property(e => e.VehicleEngineNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle engine number");

                entity.Property(e => e.VehicleModel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle model");

                entity.Property(e => e.VehicleName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle name");

                entity.Property(e => e.VehicleNumber).HasColumnName("Vehicle number");

                entity.Property(e => e.VehicleRate).HasColumnName("Vehicle Rate");

                entity.Property(e => e.VehicleVersion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle version");

                entity.Property(e => e.VehicleWarranty)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle warranty");
            });

            modelBuilder.Entity<Estimate>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("Estimate");

                entity.Property(e => e.CustomerId).HasColumnName("Customer ID");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Customer Name");

                entity.Property(e => e.CustomerPhoneNumber).HasColumnName("Customer phone number");

                entity.Property(e => e.EstimateNumber).HasColumnName("Estimate number");

                entity.Property(e => e.VehicleModel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle model");

                entity.Property(e => e.VehicleName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle name");

                entity.Property(e => e.VehiclePolicyType)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle policy type");

                entity.Property(e => e.VehicleRate).HasColumnName("Vehicle Rate");

                entity.Property(e => e.VehicleWarranty)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle warranty");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_Email");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_Name");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_Password");

                entity.Property(e => e.UserPhone).HasColumnName("User_Phone");

                entity.Property(e => e.UserRole).HasColumnName("User_Role");

                entity.HasOne(d => d.UserRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__User_Role__33D4B598");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("User_Role");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Role_Name");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.Property(e => e.VehicleId).HasColumnName("Vehicle Id");

                entity.Property(e => e.VehicleBodyNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle body number");

                entity.Property(e => e.VehicleEngineNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle engine number");

                entity.Property(e => e.VehicleModel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle model");

                entity.Property(e => e.VehicleName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle name");

                entity.Property(e => e.VehicleNumber).HasColumnName("Vehicle number");

                entity.Property(e => e.VehicleRate).HasColumnName("Vehicle Rate");

                entity.Property(e => e.VehicleSOwnerName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle’s owner name");

                entity.Property(e => e.VehicleVersion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle version");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
