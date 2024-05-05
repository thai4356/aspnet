using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Italian_Restaurant.Models;

public partial class ItalyContext : DbContext
{
    public ItalyContext()
    {
    }

    public ItalyContext(DbContextOptions<ItalyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<BillDetail> BillDetails { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Pack> Packs { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<TestDetail> TestDetails { get; set; }

    public virtual DbSet<Tip> Tips { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-OAJM4PN2;Initial Catalog=italy;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__Bill__CF6E7DA322087EC1");

            entity.ToTable("Bill");

            entity.Property(e => e.BillId)
                .ValueGeneratedNever()
                .HasColumnName("Bill_Id");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<BillDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Bill_Detail");

            entity.Property(e => e.BillId).HasColumnName("Bill_Id");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.Bill).WithMany()
                .HasForeignKey(d => d.BillId)
                .HasConstraintName("FK__Bill_Deta__Bill___4CA06362");

            entity.HasOne(d => d.Pack).WithMany()
                .HasForeignKey(d => d.PackId)
                .HasConstraintName("FK__Bill_Deta__PackI__4E88ABD4");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Bill_Deta__User___4D94879B");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PK__Category__6A1C8AFA52877152");

            entity.ToTable("Category");

            entity.Property(e => e.CatId).ValueGeneratedNever();
            entity.Property(e => e.CatName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comment__3214EC07ACC29A66");

            entity.ToTable("Comment");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.RecipeId).HasColumnName("Recipe_id");
            entity.Property(e => e.TipId).HasColumnName("Tip_Id");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Comments)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__Comment__Recipe___5812160E");

            entity.HasOne(d => d.Tip).WithMany(p => p.Comments)
                .HasForeignKey(d => d.TipId)
                .HasConstraintName("FK__Comment__Tip_Id__59063A47");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Comment__User_Id__571DF1D5");
        });

        modelBuilder.Entity<Pack>(entity =>
        {
            entity.HasKey(e => e.PackId).HasName("PK__Pack__FA6765697364E8BC");

            entity.ToTable("Pack");

            entity.Property(e => e.PackId).ValueGeneratedNever();
            entity.Property(e => e.PackLenght).HasColumnName("Pack_Lenght");
            entity.Property(e => e.PackName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("PK__Recipe__FDD988B007894E01");

            entity.ToTable("Recipe");

            entity.Property(e => e.RecipeId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Material)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RecipeName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RecipeRole)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.Category)
                .HasConstraintName("FK__Recipe__Category__403A8C7D");

            entity.HasOne(d => d.User).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Recipe__UserId__3F466844");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.TestId).HasName("PK__Test__B502D022FE5E0C24");

            entity.ToTable("Test");

            entity.Property(e => e.TestId)
                .ValueGeneratedNever()
                .HasColumnName("Test_Id");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TestName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.WinnerId).HasColumnName("Winner_Id");

            entity.HasOne(d => d.Winner).WithMany(p => p.Tests)
                .HasForeignKey(d => d.WinnerId)
                .HasConstraintName("FK__Test__Winner_Id__5165187F");
        });

        modelBuilder.Entity<TestDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Test_Detail");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.TestId).HasColumnName("Test_Id");

            entity.HasOne(d => d.Test).WithMany()
                .HasForeignKey(d => d.TestId)
                .HasConstraintName("FK__Test_Deta__Test___534D60F1");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Test_Deta__UserI__5441852A");
        });

        modelBuilder.Entity<Tip>(entity =>
        {
            entity.HasKey(e => e.TipId).HasName("PK__Tip__2DB1A1C8F608C332");

            entity.ToTable("Tip");

            entity.Property(e => e.TipId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.TipName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TipRole)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Tips)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Tip__UserId__4316F928");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C8D07DBF3");

            entity.ToTable("User");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Gmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Pass)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RoleStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserRole)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
