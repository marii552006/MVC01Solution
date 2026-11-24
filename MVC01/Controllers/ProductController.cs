using Microsoft.AspNetCore.Mvc;
using MVC01.Models;

namespace MVC01.Controllers
{

    [Route("test")]
    public class ProductController : Controller
    {
        // GET BaseUrl/Test/json
        [HttpGet("json")]
        public IActionResult JsonAction()
        {
            return Json("Hello From Json Action");
        }

        //GET BaseURL/Test/ProductCode/10
        [HttpGet("ProductCode/{code:int}")]
        public IActionResult GetProductByCode(int code)
        {
            return Json(new Product() { Id = code, Name = "Laptop" });
        }


        [HttpGet]
        public IActionResult GetById([FromQuery] int id, [FromQuery(Name = "id2")] int otherId)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search(ProductFilter filter)// Binder Create New Object From ProductFilter and Fill Each Property
        {
            return View();
        }
        public string TestAction()
        {
            return "Hello from ProductController";
        }

        //  public ContentResult Index(){
        //    return Content("<h1>Hello from index</h1>", "text/html");
        // }
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetProducts()
        {
            var products = new List<Product>()
            {
        new Product { Id = 10, Name  = "Moobile" },
        new Product { Id = 20, Name = "laptop" }
        };
        return Json(products);
        }

        public IActionResult GetProductById(int id){
            if (id < 0)
                return BadRequest();
            else if (id == 0)
                return RedirectToAction(nameof(Index));
            else if (id < 10)
                return NotFound();
            else
                return Json(new Product() { Id = id, Name = "laptop" });
        }
        public IActionResult RedirectToLink(){
            return Redirect("https://www.microsoft.com/en-eg");
        }

        public IActionResult FileAction() { 
        var fileBytes = System.IO.File.ReadAllBytes("wwwroot/files/LINQ - Session 02.pdf");
        return File(fileBytes, "application/pdf", "TestFile.pdf");
        }
    }
}