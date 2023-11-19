using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskMVC.Data;
using TaskMVC.Dto_s;
using TaskMVC.Entity;
using Microsoft.AspNetCore.Identity;
using TaskMVC.Interface;
using NToastNotify;
using System.Net.Mail;
using MimeKit;
using MailKit.Security;
using MimeKit.Text;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
namespace TaskMVC.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly UserManager<User> _userManager;
    private readonly AppDbContext _appDbContext;
    private readonly IToastNotification _notification;
    
    public ProductController(IProductRepository productRepository, UserManager<User> userManager, AppDbContext appDbContext, IToastNotification notification)
    {
        _productRepository = productRepository;
        _userManager = userManager;
        _appDbContext = appDbContext;
        _notification = notification;
    }
    public async Task<IActionResult> Index2()
    {
        var alresult = await _appDbContext.Products.ToListAsync();
        foreach (var product in alresult)
        {
            product.TotolPrice = (product.Price * product.Quantiy) * (1 + 0.1);
            product.TotolPrice = Math.Floor(product.TotolPrice);
            await _appDbContext.SaveChangesAsync();

        }
        return View(alresult);
    }
    public async Task<IActionResult> Index()
    {

        var alresult = await _appDbContext.Products.ToListAsync();
        foreach (var product in alresult)
        {
            product.TotolPrice = (product.Price * product.Quantiy) * (1 + 0.1);
            product.TotolPrice = Math.Floor(product.TotolPrice);
            await _appDbContext.SaveChangesAsync();


        }
        return View(alresult);
    }
    public async Task<IActionResult> AddProduct()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddProduct([Bind("Id,Title,Quantiy,Price")] Product product)
    {
        if (!ModelState.IsValid) return View(product);

        var user = await _userManager.GetUserAsync(HttpContext.User);
        await _productRepository.CreateProductAsync(product);
        _notification.AddSuccessToastMessage( "Create Product!");
        await _productRepository.CreateAudit(product, null, "Create", user);

        var alresult = await _appDbContext.Products.ToListAsync();
        foreach (var produc in alresult)
        {
            produc.TotolPrice = (produc.Price * produc.Quantiy) * (1 + 0.1);
            produc.TotolPrice = Math.Floor(produc.TotolPrice);
            await _appDbContext.SaveChangesAsync();

        }
        return View("Index2",alresult );
    }

    [HttpPost]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        if (!ModelState.IsValid)
        {
            return View("Index2");
        }
        var getid = await _appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (getid != null)
        {
            _appDbContext.Products.Remove(getid);
            await _appDbContext.SaveChangesAsync();
            _notification.AddSuccessToastMessage("Delete Product");

        }
        var allproduct = await _appDbContext.Products.ToListAsync();
        return View("Index2", allproduct);
    }
    public IActionResult UpdateProduct()
    {
        return View("UpdateProduct");
    }
    [HttpPost]
    public async Task<IActionResult> UpdateProduct(int id, [Bind("Id,Title,Quantiy,Price")] Product product)
    {
        if (id != product.Id) return NotFound();

        if (!ModelState.IsValid) return View(product);

        try
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var oldProduct = await _productRepository.GetOldValueAsync(id);
            var newProduct = await _productRepository.UpdateProductAsync(product);
            _notification.AddSuccessToastMessage("Update Product!");
            await _productRepository.CreateAudit(newProduct, oldProduct, "Edit", user);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (_productRepository.GetProductByIdAsync(product.Id) == null)
                return NotFound();
            else
                throw;
        }

        var alresult = await _appDbContext.Products.ToListAsync();
        foreach (var produc in alresult)
        {
            produc.TotolPrice = (produc.Price * produc.Quantiy) * (1 + 0.1);
            produc.TotolPrice = Math.Floor(produc.TotolPrice);
            await _appDbContext.SaveChangesAsync();

        }
        return View("Index2", alresult);

     
    }
}
