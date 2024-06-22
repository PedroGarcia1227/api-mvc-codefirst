using Microsoft.EntityFrameworkCore;

public partial class ApplicationDatabaseContext : DbContext
{
    public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
    {

    }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<SalesOrder> SalesOrders { get; set; } 
    public virtual DbSet<SalesOrderItem> SalesOrderItems { get; set; } 
    public virtual DbSet<Shipper> Shippers { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Supplier> Suppliers { get; set; }           

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductCategory>().HasKey(e => e.ProductCategoryID);
        modelBuilder.Entity<ProductCategory>().Property(p => p.ProductCategoryID).ValueGeneratedNever();
        modelBuilder.Entity<ProductCategory>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<ProductCategory>().HasMany<Product>().WithOne().HasForeignKey(k => k.ProductCategoryID);

        modelBuilder.Entity<Product>().HasKey(e => e.ProductID);
        modelBuilder.Entity<Product>().Property(p => p.ProductID).ValueGeneratedNever();
        modelBuilder.Entity<Product>().Property(p => p.ProductCategoryID).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasPrecision(11, 5).IsRequired();
        modelBuilder.Entity<Product>().HasMany<SalesOrderItem>().WithOne().HasForeignKey(k => k.ProductID);

        modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeID);
        modelBuilder.Entity<Employee>().Property(p => p.EmployeeID).ValueGeneratedNever();
        modelBuilder.Entity<Employee>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Employee>().Property(p => p.BirthDate).IsRequired();
        modelBuilder.Entity<Employee>().Property(p => p.HireDate).IsRequired();
        modelBuilder.Entity<Employee>().Property(p => p.Address).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Employee>().Property(p => p.City).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Employee>().Property(p => p.State).HasMaxLength(30).IsRequired();
        modelBuilder.Entity<Employee>().Property(p => p.PostalCode).HasMaxLength(13).IsRequired();
        modelBuilder.Entity<Employee>().Property(p => p.ReportTo);
        modelBuilder.Entity<Employee>().HasMany<Employee>().WithOne().HasForeignKey(k => k.ReportTo).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Employee>().HasMany<SalesOrder>().WithOne().HasForeignKey(k => k.EmployeeID);

        modelBuilder.Entity<SalesOrder>().HasKey(e => e.SalesOrderID);
        modelBuilder.Entity<SalesOrder>().Property(p => p.SalesOrderID).ValueGeneratedNever();
        modelBuilder.Entity<SalesOrder>().Property(p => p.CustomerID).IsRequired();
        modelBuilder.Entity<SalesOrder>().Property(p => p.EmployeeID).IsRequired();
        modelBuilder.Entity<SalesOrder>().Property(p => p.ShipperID).IsRequired();
        modelBuilder.Entity<SalesOrder>().Property(p => p.OrderDate).IsRequired();
        modelBuilder.Entity<SalesOrder>().Property(p => p.EstimatedDeliveryDate);
        modelBuilder.Entity<SalesOrder>().Property(p => p.Freight).HasPrecision(11, 5).IsRequired();
        modelBuilder.Entity<SalesOrder>().Property(p => p.Total).HasPrecision(11, 5).IsRequired();
        modelBuilder.Entity<SalesOrder>().HasMany(k => k.SalesOrderItems).WithOne(k => k.SalesOrder).HasForeignKey(k => k.SalesOrderID);

        modelBuilder.Entity<SalesOrderItem>().HasKey(e => new { e.SalesOrderID, e.ProductID });
        modelBuilder.Entity<SalesOrderItem>().Property(p => p.Quantity).IsRequired();
        modelBuilder.Entity<SalesOrderItem>().Property(p => p.UnitPrice).HasPrecision(11, 5).IsRequired();
        modelBuilder.Entity<SalesOrderItem>().Property(p => p.Discount).HasPrecision(11, 5).IsRequired();

        modelBuilder.Entity<Shipper>().HasKey(e => e.ShipperID);
        modelBuilder.Entity<Shipper>().Property(p => p.ShipperID).ValueGeneratedNever();
        modelBuilder.Entity<Shipper>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Shipper>().HasMany<SalesOrder>().WithOne().HasForeignKey(k => k.ShipperID);

        modelBuilder.Entity<Customer>().HasKey(e => e.CustomerID);
        modelBuilder.Entity<Customer>().Property(p => p.CustomerID).ValueGeneratedNever();
        modelBuilder.Entity<Customer>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.Address).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.City).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.State).HasMaxLength(30).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.PostalCode).HasMaxLength(13).IsRequired();
        modelBuilder.Entity<Customer>().HasMany<SalesOrder>().WithOne().HasForeignKey(k => k.CustomerID);
        
        modelBuilder.Entity<Supplier>().HasKey(e => e.SupplierID);
        modelBuilder.Entity<Supplier>().Property(p => p.SupplierID).ValueGeneratedNever();
        modelBuilder.Entity<Supplier>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Supplier>().Property(p => p.Address).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Supplier>().Property(p => p.City).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Supplier>().Property(p => p.State).HasMaxLength(30).IsRequired();
        modelBuilder.Entity<Supplier>().Property(p => p.PostalCode).HasMaxLength(13).IsRequired();

        this.OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}