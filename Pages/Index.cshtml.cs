using azure_lab_ch3.Models;
using azure_lab_ch3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace azure_lab_ch3.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;

        public IndexModel(ILogger<IndexModel> logger)
        {
           // _logger = logger;
        }

        public void OnGet()
        {
            ProductService productService= new ProductService();
            Products= productService.GetProduct();
        }
    }
}