using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrderSystem.Models;

public partial class OrderSystemContext : DbContext
{
    public OrderSystemContext()
    {
    }

    public OrderSystemContext(DbContextOptions<OrderSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccYear> AccYears { get; set; }

    public virtual DbSet<AgrpMast> AgrpMasts { get; set; }

    public virtual DbSet<CompanyDetail> CompanyDetails { get; set; }

    public virtual DbSet<CompanyMaster> CompanyMasters { get; set; }

    public virtual DbSet<EmailSetting> EmailSettings { get; set; }

    public virtual DbSet<ErrorDetail> ErrorDetails { get; set; }

    public virtual DbSet<ItemMaster> ItemMasters { get; set; }

    public virtual DbSet<MenuMaster> MenuMasters { get; set; }

    public virtual DbSet<MenuPermission> MenuPermissions { get; set; }

    public virtual DbSet<MenuRoleDetail> MenuRoleDetails { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderMaster> OrderMasters { get; set; }

    public virtual DbSet<OrderPayment> OrderPayments { get; set; }

    public virtual DbSet<PartyMast> PartyMasts { get; set; }

    public virtual DbSet<UserCategoryMaster> UserCategoryMasters { get; set; }

    public virtual DbSet<UserMaster> UserMasters { get; set; }

    public virtual DbSet<UserWiseItemMaster> UserWiseItemMasters { get; set; }

    public virtual DbSet<UserWisePartyMaster> UserWisePartyMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-T5MN2V5;Database=OrderSystem;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccYear>(entity =>
        {
            entity.HasKey(e => new { e.CompanyId, e.AcYear });

            entity.ToTable("AccYear");

            entity.Property(e => e.FtrnDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("FTrnDate");
            entity.Property(e => e.Remark)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.TtrnDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("TTrnDate");
        });

        modelBuilder.Entity<AgrpMast>(entity =>
        {
            entity.HasKey(e => e.Agrcode);

            entity.ToTable("AGrpMast");

            entity.Property(e => e.Agrcode)
                .ValueGeneratedNever()
                .HasColumnName("AGRCode");
            entity.Property(e => e.Agrname)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("AGRName");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Remark)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CompanyDetail>(entity =>
        {
            entity.HasKey(e => new { e.CompanyId, e.CompanyDetailsId });

            entity.Property(e => e.CompanyDetailsId).ValueGeneratedOnAdd();
            entity.Property(e => e.CompanyAddress)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.ContactNoOffice)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.ContactNoPersonal)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.ContactPersonFirstName)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.ContactPersonLastName)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyDetails)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompanyDetails_CompanyMaster");
        });

        modelBuilder.Entity<CompanyMaster>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK_CompanyMaster_1");

            entity.ToTable("CompanyMaster");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmailSetting>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EmailSetting");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.Smtpserver)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMTPServer");
        });

        modelBuilder.Entity<ErrorDetail>(entity =>
        {
            entity.Property(e => e.CreatedDateTime).HasColumnType("date");
            entity.Property(e => e.Message).IsUnicode(false);
            entity.Property(e => e.MethodName)
                .HasMaxLength(512)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItemMaster>(entity =>
        {
            entity.HasKey(e => e.ItemId);

            entity.ToTable("ItemMaster");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ItemCode)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.ItemDescription)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.ItemImage)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.ItemName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.ItemRate).HasColumnType("decimal(5, 0)");
            entity.Property(e => e.Mrp)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("MRP");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<MenuMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MenuMast__3214EC0775366F1E");

            entity.ToTable("MenuMaster");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Icon)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Path)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<MenuPermission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK__MenuPerm__EFA6FB2FACA72BBF");

            entity.ToTable("MenuPermission");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuPermissions)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("FK__MenuPermi__MenuI__503BEA1C");
        });

        modelBuilder.Entity<MenuRoleDetail>(entity =>
        {
            entity.HasKey(e => e.MenuRoleId);

            entity.ToTable("MenuRoleDetail");

            entity.HasOne(d => d.MenuMaster).WithMany(p => p.MenuRoleDetails)
                .HasForeignKey(d => d.MenuMasterId)
                .HasConstraintName("FK_MenuRoleDetail_MenuMaster");

            entity.HasOne(d => d.UserCategory).WithMany(p => p.MenuRoleDetails)
                .HasForeignKey(d => d.UserCategoryId)
                .HasConstraintName("FK_MenuRoleDetail_UserCategoryMaster");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.CompanyId, e.AcYear, e.TrnNo, e.SeqNo });

            entity.Property(e => e.Amount).HasColumnType("decimal(6, 0)");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Pcs).HasColumnType("decimal(6, 0)");
            entity.Property(e => e.Rate).HasColumnType("decimal(6, 0)");
            entity.Property(e => e.TrnDate).HasColumnType("date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<OrderMaster>(entity =>
        {
            entity.HasKey(e => new { e.CompanyId, e.AcYear, e.TrnNo }).HasName("PK_OrderSummary");

            entity.ToTable("OrderMaster");

            entity.Property(e => e.AdjustAmount).HasColumnType("decimal(6, 0)");
            entity.Property(e => e.Amount)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("date");
            entity.Property(e => e.InvoiceNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PartyCode)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(6, 0)");
            entity.Property(e => e.PaymentDate).HasColumnType("date");
            entity.Property(e => e.Rate).HasColumnType("decimal(6, 0)");
            entity.Property(e => e.RemaningAmount).HasColumnType("decimal(6, 0)");
            entity.Property(e => e.TotalPcs).HasColumnType("decimal(6, 0)");
            entity.Property(e => e.TrnDate).HasColumnType("date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("date");
        });

        modelBuilder.Entity<OrderPayment>(entity =>
        {
            entity.HasKey(e => new { e.CompanyId, e.AcYear, e.TrnNo, e.SeqNo });

            entity.ToTable("OrderPayment");

            entity.Property(e => e.AdjustAmount).HasColumnType("decimal(6, 0)");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(6, 0)");
            entity.Property(e => e.PaymentDate).HasColumnType("date");
            entity.Property(e => e.Remark)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<PartyMast>(entity =>
        {
            entity.HasKey(e => new { e.PartyCode, e.CompanyId, e.AcYear }).HasName("PK_OLD");

            entity.ToTable("PartyMast");

            entity.Property(e => e.PartyCode)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.Add1)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Add2)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Add3)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Agrcode).HasColumnName("AGRCode");
            entity.Property(e => e.City)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.Gstno)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("GSTNo");
            entity.Property(e => e.Mobile)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.PanNo)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.PartyName)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Remark)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserCategoryMaster>(entity =>
        {
            entity.HasKey(e => e.UserCategoryId);

            entity.ToTable("UserCategoryMaster");

            entity.Property(e => e.UserCategoryName)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserMaster>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_UserMaster_1");

            entity.ToTable("UserMaster");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserWiseItemMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserWiseItemMaster");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Rate).HasColumnType("decimal(6, 0)");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserWisePartyMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserWisePartyMaster");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PartyCode)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(56)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
