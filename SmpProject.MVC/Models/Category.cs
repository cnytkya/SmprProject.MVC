using System.ComponentModel.DataAnnotations;

namespace SmpProject.MVC.Models
{
    public class Category
    {
        //[Key] Key niteliği, bir sınıfın veya bir sınıf üyesinin birincil anahtar (primary key) olduğunu belirtir. Bu nitelik, Entity Framework Core tarafından veritabanı tabloları ve sütunları oluşturmak için kullanılır.
        public int Id { get; set; } //Id, Category sınıfının bir özelliğidir ve birincil anahtar (primary key) olarak kullanılır. Bu özellik, Category sınıfının veritabanındaki kayıtlarını benzersiz bir şekilde tanımlar.

        [Required] //Required niteliği, bir sınıf üyesinin zorunlu olduğunu belirtir. Bu nitelik, bir sınıf üyesinin null olamayacağını belirtir ve bu nedenle veri tabanında bu sütunun null olamayacağını belirtir.
        public string Name { get; set; } //Name, Category sınıfının bir özelliğidir ve kategori adını temsil eder. Bu özellik, veritabanındaki kategori adı sütununu temsil eder.

        public int DisplayOrder { get; set; } //DisplayOrder, Category sınıfının bir özelliğidir ve kategori sıralamasını temsil eder. Bu özellik, veritabanındaki kategori sıralama sütununu temsil eder.
    }
}