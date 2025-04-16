using Microsoft.EntityFrameworkCore;
namespace CustomClothingApp.Server.Models;
public partial class CustomClothingDbContext : DbContext
{
    public CustomClothingDbContext()
    {
    }
    public CustomClothingDbContext(DbContextOptions<CustomClothingDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Clothingmodel> Clothingmodels { get; set; }
    public virtual DbSet<Measurement> Measurements { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CustomClothingDB;Username=postgres;Password=Cdtnkfyf23");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clothingmodel>(entity =>
        {
            entity.HasKey(e => e.Modelid).HasName("clothingmodels_pkey");
            entity.ToTable("clothingmodels");
            entity.Property(e => e.Modelid).HasColumnName("modelid");
            entity.Property(e => e.Baseprice)
                .HasPrecision(10, 2)
                .HasColumnName("baseprice");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Modeldescription)
                .HasMaxLength(500)
                .HasColumnName("modeldescription");
            entity.Property(e => e.Modelname)
                .HasMaxLength(100)
                .HasColumnName("modelname");
            entity.Property(e => e.Category).HasMaxLength(100);
        });
        modelBuilder.Entity<Measurement>(entity =>
        {
            entity.HasKey(e => e.Measurementsid).HasName("measurements_pkey");
            entity.ToTable("measurements");
            entity.Property(e => e.Measurementsid).HasColumnName("measurementsid");
            entity.Property(e => e.Chest)
                .HasPrecision(5, 2)
                .HasColumnName("chest");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Height)
                .HasPrecision(5, 2)
                .HasColumnName("height");
            entity.Property(e => e.Hip)
                .HasPrecision(5, 2)
                .HasColumnName("hip");
            entity.Property(e => e.Othermeasurements).HasColumnName("othermeasurements");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Waist)
                .HasPrecision(5, 2)
                .HasColumnName("waist");

            entity.HasOne(d => d.User).WithMany(p => p.Measurements)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_user_measurements");
        });
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("orders_pkey");
            entity.ToTable("orders");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Currentstage)
                .HasMaxLength(100)
                .HasColumnName("currentstage");
            entity.Property(e => e.Escrowstatus)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Reserved'::character varying")
                .HasColumnName("escrowstatus");
            entity.Property(e => e.Measurementsid).HasColumnName("measurementsid");
            entity.Property(e => e.Modelid).HasColumnName("modelid");
            entity.Property(e => e.Stagedescription)
                .HasMaxLength(255)
                .HasColumnName("stagedescription");
            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Updateddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.HasOne(d => d.Measurements).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Measurementsid)
                .HasConstraintName("fk_measurements_orders");
            entity.HasOne(d => d.Model).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Modelid)
                .HasConstraintName("fk_model_orders");
            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_user_orders");
        });
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");
            entity.ToTable("users");
            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
            entity.Property(e => e.Userrole)
                .HasMaxLength(20)
                .HasColumnName("userrole");
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}