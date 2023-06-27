using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ruby.Models
{
    public partial class RubyHome_DatabaseContext : DbContext
    {
        public RubyHome_DatabaseContext()
        {
        }

        public RubyHome_DatabaseContext(DbContextOptions<RubyHome_DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CurrentPosition> CurrentPositions { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Property> Properties { get; set; } = null!;
        public virtual DbSet<StructureOfEmployee> StructureOfEmployees { get; set; } = null!;
        public virtual DbSet<StructureOfUserProperty> StructureOfUserProperties { get; set; } = null!;
        public virtual DbSet<TypeProperty> TypeProperties { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserCard> UserCards { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=KANDREY1604\\MYSERVERSQL;Initial Catalog=RubyHome_Database;Persist Security Info=True;User ID=sa;Password=12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrentPosition>(entity =>
            {
                entity.HasKey(e => e.IdCurrentPosition);

                entity.ToTable("Current_Position");

                entity.HasIndex(e => e.NameCurrentPosition, "UQ_Name_Current_Position")
                    .IsUnique();

                entity.Property(e => e.IdCurrentPosition).HasColumnName("ID_Current_Position");

                entity.Property(e => e.NameCurrentPosition)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Name_Current_Position");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);

                entity.ToTable("Employee");

                entity.HasIndex(e => e.LoginEmployee, "UQ_Login_Employee")
                    .IsUnique();

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.FirstNameEmployee)
                    .IsUnicode(false)
                    .HasColumnName("First_Name_Employee");

                entity.Property(e => e.LoginEmployee)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Login_Employee");

                entity.Property(e => e.MiddleNameEmployee)
                    .IsUnicode(false)
                    .HasColumnName("Middle_Name_Employee")
                    .HasDefaultValueSql("('-')");

                entity.Property(e => e.PasswordEmployee)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Password_Employee");

                entity.Property(e => e.SecondNameEmployee)
                    .IsUnicode(false)
                    .HasColumnName("Second_Name_Employee");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(e => e.IdProperty);

                entity.ToTable("Property");

                entity.HasIndex(e => e.Location, "UQ_Location")
                    .IsUnique();

                entity.Property(e => e.IdProperty).HasColumnName("ID_Property");

                entity.Property(e => e.BathroomCount).HasColumnName("Bathroom_Count");

                entity.Property(e => e.BedroomCount).HasColumnName("Bedroom_Count");

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.KitchenCount).HasColumnName("Kitchen_Count");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameProperty)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Property");

                entity.Property(e => e.Price).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.Square).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.TypePropertyId).HasColumnName("Type_Property_ID");

                entity.HasOne(d => d.TypeProperty)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.TypePropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Type_Property_Property");
            });

            modelBuilder.Entity<StructureOfEmployee>(entity =>
            {
                entity.HasKey(e => e.IdStructureOfEmployee);

                entity.ToTable("Structure_Of_Employee");

                entity.Property(e => e.IdStructureOfEmployee).HasColumnName("ID_Structure_Of_Employee");

                entity.Property(e => e.CurrentPositionId).HasColumnName("Current_Position_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.PropertyId).HasColumnName("Property_ID");

                entity.HasOne(d => d.CurrentPosition)
                    .WithMany(p => p.StructureOfEmployees)
                    .HasForeignKey(d => d.CurrentPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Current_Position_Structure_Of_Employee");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.StructureOfEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Structure_Of_Employee");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.StructureOfEmployees)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Property_Structure_Of_Employee");
            });

            modelBuilder.Entity<StructureOfUserProperty>(entity =>
            {
                entity.HasKey(e => e.IdStructureOfUserProperty);

                entity.ToTable("Structure_Of_User_Property");

                entity.Property(e => e.IdStructureOfUserProperty).HasColumnName("ID_Structure_Of_User_Property");

                entity.Property(e => e.PropertyId).HasColumnName("Property_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.StructureOfUserProperties)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Property_Structure_Of_User_Property");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StructureOfUserProperties)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Structure_Of_User_Property");
            });

            modelBuilder.Entity<TypeProperty>(entity =>
            {
                entity.HasKey(e => e.IdTypeProperty);

                entity.ToTable("Type_Property");

                entity.Property(e => e.IdTypeProperty).HasColumnName("ID_Type_Property");

                entity.Property(e => e.TypePropertyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Type_Property_Name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.HasIndex(e => e.LoginUser, "UQ_Login_User")
                    .IsUnique();

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.LoginUser)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Login_User");

                entity.Property(e => e.PasswordUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Password_User");
            });

            modelBuilder.Entity<UserCard>(entity =>
            {
                entity.HasKey(e => e.IdUserCard);

                entity.ToTable("User_Card");

                entity.HasIndex(e => e.CardNumber, "UQ_Card_Number")
                    .IsUnique();

                entity.Property(e => e.IdUserCard).HasColumnName("ID_User_Card");

                entity.Property(e => e.CardHolder)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Card_Holder");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(19)
                    .IsUnicode(false)
                    .HasColumnName("Card_Number");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.Validity)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCards)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_User_Card");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
