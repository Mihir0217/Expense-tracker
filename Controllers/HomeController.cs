using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using firstmvc.Models;


namespace firstmvc.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ExpensesDbContext _context;


    public HomeController(ILogger<HomeController> logger, ExpensesDbContext context)
    {
        _logger = logger;
        _context = context;

    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CreateEditExp(int? Id)
    {
        if (Id != null)
        {
            var expenseId = _context.Spendings.SingleOrDefault(x => x.Id == Id);
            return View(expenseId);
        }

        return View();
    }

    public IActionResult DeleteExp(int? Id)
    {
        var expenseId = _context.Spendings.SingleOrDefault(model => model.Id == Id);


        if (expenseId != null)
        {
            _context.Spendings.Remove(expenseId);
            _context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Expense not found.");
        }
            return RedirectToAction("Expenses");

    }

    public IActionResult Expenses()
    {
        var allexpenses = _context.Spendings.ToList();
        return View(allexpenses);
    }

    [HttpPost]
    public IActionResult CreateEditForm(Expense model)
    {
        if (@model.Id == 0)
        {
            model.Date = DateTime.Now;
            _context.Spendings.Add(model);
        }
        else
        {
            model.Date = DateTime.Now;
            _context.Spendings.Update(model);

        }

        _context.SaveChanges();

        return RedirectToAction("Expenses");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
