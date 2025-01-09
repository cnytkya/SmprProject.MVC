using Microsoft.AspNetCore.Mvc;
using SmpProject.MVC.Data;
using SmpProject.MVC.Models;

namespace SmpProject.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context; //AppDbContext, Entity Framework Core kullanarak bir veritabanı bağlamı (DbContext) tanımlayan bir C# sınıfıdır. DbContext, Entity Framework Core'un veritabanı işlemlerini yönetmek için kullandığı temel sınıftır. Bu sınıf, veritabanı bağlantılarını ve veritabanı işlemlerini yönetir.

        public CategoryController(AppDbContext context) //CategoryController sınıfının bir yapıcı metodunu tanımlar. Yapıcı metotlar, bir sınıfın yeni bir örneği (instance) oluşturulduğunda çağrılır ve genellikle sınıfın başlangıç durumunu ayarlamak için kullanılır.
        {
            _context = context;
        }

        // GET: Category
        public IActionResult Index() //Index metodu, CategoryController sınıfının bir metodu olup, kategori listesini görüntülemek için kullanılır.
        {
            var categories = _context.Categories.ToList(); //Categories, AppDbContext sınıfının bir özelliğidir ve Category türündeki verileri temsil eder. ToList metodu, veritabanındaki tüm kategorileri bir liste olarak almak için kullanılır.
            return View(categories); //View metodu, bir görünümü (view) temsil eden bir ViewResult nesnesi döndürür. ViewResult nesnesi, bir görünümü (view) HTML olarak oluşturmak için kullanılır.
        }

        // GET: Category/Create
        public IActionResult Create() //Create metodu, CategoryController sınıfının bir metodu olup, yeni bir kategori oluşturmak için kullanılır.
        {
            return View(); //View metodu, bir görünümü (view) temsil eden bir ViewResult nesnesi döndürür. ViewResult nesnesi, bir görünümü (view) HTML olarak oluşturmak için kullanılır.
        }

        // POST: Category/Create
        [HttpPost] //HttpPost niteliği, bir metodu HTTP POST isteklerine karşı işlemek için kullanılır. Bu nitelik, bir metodu yalnızca HTTP POST istekleriyle eşleştirmek için kullanılır.
        [ValidateAntiForgeryToken] //ValidateAntiForgeryToken, ASP.NET Core MVC uygulamalarında Cross-Site Request Forgery (CSRF) saldırılarına karşı koruma sağlar. Bu özellik, bir form gönderildiğinde, formun sunucuya gönderilen verilerin güvenilirliğini doğrular.
        public IActionResult Create(Category category) //Create metodu, CategoryController sınıfının bir metodu olup, yeni bir kategori oluşturmak için kullanılır.
        {
            if (ModelState.IsValid) //ModelState.IsValid özelliği, modelin geçerli olup olmadığını belirten bir değer döndürür. ModelState, bir modelin durumunu ve geçerliliğini temsil eden bir ModelStateDictionary nesnesidir.
            {
                _context.Categories.Add(category); //Categories, AppDbContext sınıfının bir özelliğidir ve Category türündeki verileri temsil eder. Add metodu, bir kategori eklemek için kullanılır.
                _context.SaveChanges(); //SaveChanges metodu, veritabanındaki tüm değişiklikleri kaydeder. Bu metot, veritabanındaki değişiklikleri kalıcı hale getirmek için kullanılır.
                return RedirectToAction(nameof(Index)); //RedirectToAction metodu, belirtilen bir eyleme yönlendirme yapar. Bu metot, bir eyleme yönlendirme yapmak için kullanılır.
            }
            return View(category); //View metodu, bir görünümü (view) temsil eden bir ViewResult nesnesi döndürür. ViewResult nesnesi, bir görünümü (view) HTML olarak oluşturmak için kullanılır.
        }

        // GET: Category/Edit/5
        public IActionResult Edit(int? id) //Edit metodu, CategoryController sınıfının bir metodu olup, belirli bir kategoriyi düzenlemek için kullanılır. Kullanıcı tarafından seçilen kategori Id'sini alır ve bu Id'ye sahip kategoriyi düzenlemek için kullanılır.
        {
            if (id == null || id == 0) //id, Edit metodu tarafından alınan bir parametredir ve düzenlenecek kategori Id'sini temsil eder. Bu ifade, id'nin null veya 0 olup olmadığını kontrol eder.
            {
                return NotFound(); //NotFound metodu, 404 Not Found HTTP yanıtını döndürür. Bu metot, bir sayfanın veya kaynağın bulunamadığını belirtmek için kullanılır.
            }

            var category = _context.Categories.Find(id); //Categories, AppDbContext sınıfının bir özelliğidir ve Category türündeki verileri temsil eder. Find metodu, belirtilen bir anahtara sahip bir kategori bulmak için kullanılır.
            if (category == null)//category, Edit metodu tarafından alınan bir parametredir ve düzenlenecek kategoriyi temsil eder. Bu ifade, kategorinin null olup olmadığını kontrol eder.
            {
                return NotFound();//eğer null ise NotFound metodu, 404 Not Found HTTP yanıtını döndürür. Bu metot, bir sayfanın veya kaynağın bulunamadığını belirtmek için kullanılır.
            }

            return View(category); //View metodu, bir görünümü (view) temsil eden bir ViewResult nesnesi döndürür. ViewResult nesnesi, bir görünümü (view) HTML olarak oluşturmak için kullanılır.
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] //ValidateAntiForgeryToken, ASP.NET Core MVC uygulamalarında Cross-Site Request Forgery (CSRF) saldırılarına karşı koruma sağlar. Bu özellik, bir form gönderildiğinde, formun sunucuya gönderilen verilerin güvenilirliğini doğrular.
        public IActionResult DeleteConfirmed(int? id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category); //Remove metodu, bir kategoriyi silmek için kullanılır.
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Category/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _context.Categories.Find(id); //Categories, AppDbContext sınıfının bir özelliğidir ve Category türündeki verileri temsil eder. Find metodu, belirtilen bir anahtara sahip bir kategori bulmak için kullanılır. eğer id null ise NotFound metodu, 404 Not Found HTTP yanıtını döndürür. Bu metot, bir sayfanın veya kaynağın bulunamadığını belirtmek için kullanılır. bunun için aşağıdaki gibi if bloğu kullanılır.
            if (category == null)
            {
                return NotFound();
            }

            return View(category); //eğer id boş(null) değilse category nesnesini döndürür.
        }
    }
}