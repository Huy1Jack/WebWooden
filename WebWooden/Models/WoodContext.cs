using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebWooden.Areas.Admin.Models;

namespace WebWooden.Models;

public partial class WoodContext : DbContext
{
    public WoodContext()
    {
    }

    public WoodContext(DbContextOptions<WoodContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbBlog> TbBlogs { get; set; }

    public virtual DbSet<TbBlogComment> TbBlogComments { get; set; }

    public virtual DbSet<TbCategory> TbCategories { get; set; }

    public virtual DbSet<TbCustomer> TbCustomers { get; set; }

    public virtual DbSet<TbMenu> TbMenus { get; set; }

    public virtual DbSet<TbNews> TbNews { get; set; }

    public virtual DbSet<TbOrder> TbOrders { get; set; }

    public virtual DbSet<TbOrderDetail> TbOrderDetails { get; set; }

    public virtual DbSet<TbOrderStatus> TbOrderStatuses { get; set; }

    public virtual DbSet<TbProduct> TbProducts { get; set; }

    public virtual DbSet<TbProductCategory> TbProductCategories { get; set; }

    public virtual DbSet<TbProductReview> TbProductReviews { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("tb_Blog");

            entity.Property(e => e.Alias).HasMaxLength(255);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Detail).HasMaxLength(255);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.SeoDescription).HasMaxLength(255);
            entity.Property(e => e.SeoKeywords).HasMaxLength(255);
            entity.Property(e => e.SeoTitle).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<TbBlogComment>(entity =>
        {
            entity.HasKey(e => e.CommentId);

            entity.ToTable("tb_BlogComment");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Detail).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<TbCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.ToTable("tb_Category");

            entity.Property(e => e.CreatedBy).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.ToTable("tb_Customer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<TbMenu>(entity =>
        {
            entity.HasKey(e => e.MenuId);

            entity.ToTable("tb_Menu");

            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbNews>(entity =>
        {
            entity.HasKey(e => e.NewId);

            entity.ToTable("tb_News");

            entity.Property(e => e.NewId).HasColumnName("NewID");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.SeoTitle).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<TbOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__tbl_Orde__C3905BAFDCDED359");

            entity.ToTable("tb_Order");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName).HasMaxLength(255);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_tb_Order_tb_Customer");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.OrderStatusId)
                .HasConstraintName("FK__tbl_Order__Order__6FE99F9F");
        });

        modelBuilder.Entity<TbOrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__tbl_Orde__D3B9D30C5B500CCC");

            entity.ToTable("tb_OrderDetail");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.TbOrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__tbl_Order__Order__72C60C4A");
        });

        modelBuilder.Entity<TbOrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId).HasName("PK__tbl_Orde__BC674F4134486FC5");

            entity.ToTable("tb_OrderStatus");

            entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<TbProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__tb_Produ__B40CC6CD1256A44A");

            entity.ToTable("tb_Product");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PriceSale).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Star).HasColumnType("decimal(3, 2)");

            entity.HasOne(d => d.CategoryProduct).WithMany(p => p.TbProducts)
                .HasForeignKey(d => d.CategoryProductId)
                .HasConstraintName("FK__tb_Produc__Categ__440B1D61");
        });

        modelBuilder.Entity<TbProductCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryProductId).HasName("PK__tb_Produ__FAFA184FC598CEBA");

            entity.ToTable("tb_ProductCategory");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbProductReview>(entity =>
        {
            entity.HasKey(e => e.ProductReviewId).HasName("PK__tb_Produ__396318807C05C4A4");

            entity.ToTable("tb_ProductReview");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Star).HasColumnType("decimal(3, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.TbProductReviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__tb_Produc__Produ__46E78A0C");
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("tb_User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
