using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class DbManager : DbContext
{
    public DbManager()
    {
    }

    public DbManager(DbContextOptions<DbManager> options)
        : base(options)
    {
    }

    public virtual DbSet<CustemerType> CustemerTypes { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Deal> Deals { get; set; }

    public virtual DbSet<IllustrationViewPoint> IllustrationViewPoints { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Recommend> Recommends { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='A:\\הפרויקט\\PROJECT\\DAL\\DATA\\PROJECTDATABASE.MDF';Integrated Security=True;Connect Timeout=30;Encrypt=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustemerType>(entity =>
        {
            entity.HasKey(e => e.CustomerTypeId).HasName("PK__tmp_ms_x__3214EC072AA69222");

            entity.ToTable("custemer_type");

            entity.Property(e => e.CustomerTypeId).HasColumnName("CustomerType_Id");
            entity.Property(e => e.CustomerType)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("customer_type");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomersId).HasName("PK__tmp_ms_x__69AC2B90061BC382");

            entity.ToTable("customers");

            entity.Property(e => e.CustomersId).HasColumnName("Customers_Id");
            entity.Property(e => e.CompNameCustName)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("comp_name/cust_name");
            entity.Property(e => e.ConnectPerson)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("connect_person");
            entity.Property(e => e.CustomerType).HasColumnName("customer_type");
            entity.Property(e => e.Mail)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("mail");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("phone");

            entity.HasOne(d => d.CustomerTypeNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_customers");
        });

        modelBuilder.Entity<Deal>(entity =>
        {
            entity.HasKey(e => e.DealId).HasName("PK__tmp_ms_x__C011A3147A7253B4");

            entity.ToTable("deal");

            entity.Property(e => e.DealId).HasColumnName("deal_Id");
            entity.Property(e => e.DealDescription)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("deal_description");
        });

        modelBuilder.Entity<IllustrationViewPoint>(entity =>
        {
            entity.HasKey(e => e.IllustrationViewPointId).HasName("PK__illustra__3214EC07A424A088");

            entity.ToTable("illustration_view_point");

            entity.Property(e => e.IllustrationViewPointId)
                .ValueGeneratedNever()
                .HasColumnName("illustration_view_point_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("description");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImgId).HasName("PK__tmp_ms_x__6F16A71CF6A94C53");

            entity.ToTable("images");

            entity.Property(e => e.ImgId).HasColumnName("img_id");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(100)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("image_url");
            entity.Property(e => e.ProjectId).HasColumnName("projectId");

            entity.HasOne(d => d.Project).WithMany(p => p.Images)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_images_ToTable");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("order");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("order_id");
            entity.Property(e => e.Budget).HasColumnName("budget");
            entity.Property(e => e.CustId).HasColumnName("cust_id");
            entity.Property(e => e.DealId).HasColumnName("deal_id");
            entity.Property(e => e.Meters).HasColumnName("meters");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.OrderFinishDate).HasColumnName("order_finish_date");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("status");
            entity.Property(e => e.ViewPointId).HasColumnName("viewPointId");

            entity.HasOne(d => d.Cust).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_ToTable_1");

            entity.HasOne(d => d.Deal).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DealId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_ToTable");

            entity.HasOne(d => d.ViewPoint).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ViewPointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_ToTable_2");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07C413EB6D");

            entity.ToTable("projects");

            entity.Property(e => e.CompNameCustName)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("comp_name/cust_name");
            entity.Property(e => e.FinalDate).HasColumnName("final date");
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("image");
            entity.Property(e => e.PackageId).HasColumnName("package_id");

            entity.HasOne(d => d.Package).WithMany(p => p.Projects)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK_projects_ToTable");
        });

        modelBuilder.Entity<Recommend>(entity =>
        {
            entity.HasKey(e => e.RecommendId).HasName("PK__recommen__5D4DAA710F38AEA1");

            entity.ToTable("recommends");

            entity.Property(e => e.RecommendId)
                .ValueGeneratedNever()
                .HasColumnName("recommend_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.DealId).HasColumnName("deal_id");
            entity.Property(e => e.RecDescription)
                .HasMaxLength(100)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("rec_description");

            entity.HasOne(d => d.Customer).WithMany(p => p.Recommends)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_recommends_ToCustomer");

            entity.HasOne(d => d.Deal).WithMany(p => p.Recommends)
                .HasForeignKey(d => d.DealId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_recommends_ToTable_1");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.ImgId);

            entity.ToTable("Table");

            entity.Property(e => e.ImgId)
                .ValueGeneratedNever()
                .HasColumnName("img_Id");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(100)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("img_url");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");

            entity.HasOne(d => d.Project).WithMany(p => p.Tables)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_Table_ToTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
