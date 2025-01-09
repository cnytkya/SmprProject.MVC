using Microsoft.EntityFrameworkCore;
using SmpProject.MVC.Models;
using System.Reflection.Metadata;

namespace SmpProject.MVC.Data
{
    public class AppDbContext : DbContext //AppDbContext, Entity Framework Core kullanarak bir veritabanı bağlamı (DbContext) tanımlayan bir C# sınıfıdır. DbContext, Entity Framework Core'un veritabanı işlemlerini yönetmek için kullandığı temel sınıftır. Bu sınıf, veritabanı bağlantılarını ve veritabanı işlemlerini yönetir.
    {
        public DbSet<Category> Categories { get; set; } //Categories, AppDbContext sınıfının bir özelliğidir ve Category türündeki verileri temsil eder. DbSet sınıfı, Entity Framework Core'un bir parçasıdır ve veritabanı tablolarını temsil eden sorguları oluşturmak için kullanılır.

        public AppDbContext(DbContextOptions options) : base(options)
        {
            /*
             1.Yapıcı Metot(Constructor): public AppDbContext(DbContextOptions options) ifadesi, AppDbContext sınıfının bir yapıcı metodunu tanımlar.Yapıcı metotlar, bir sınıfın yeni bir örneği (instance) oluşturulduğunda çağrılır ve genellikle sınıfın başlangıç durumunu ayarlamak için kullanılır.
             2.	Parametre (Parameter): DbContextOptions options parametresi, Entity Framework Core'un DbContextOptions sınıfından türetilmiş bir nesneyi alır. Bu nesne, veritabanı bağlantı bilgilerini ve diğer yapılandırma seçeneklerini içerir.
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //OnModelCreating metodu, DbContext sınıfından devralınan bir metottur ve veritabanı modelini oluşturmak için kullanılır. Bu metot, veritabanı tablolarını ve ilişkilerini tanımlamak için kullanılır.
        {
            modelBuilder.Entity<Category>().HasData( //Entity<Category> ifadesi, Category sınıfının bir örneğini temsil eder. HasData metodu, veritabanına başlangıç verileri eklemek için kullanılır.
                new Category { Id = 1, Name = "C# Programming", DisplayOrder = 1 }, //Category sınıfının bir örneği oluşturulur ve veritabanına eklenir.
                new Category { Id = 2, Name = "ASP.NET Core", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Entity Framework Core", DisplayOrder = 3 }
            );
        }
    }
}