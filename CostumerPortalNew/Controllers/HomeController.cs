using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CostumerPortalNew.Models;

namespace CostumerPortalNew.Controllers;

[ApiController]
[Route("")]
public class HomeController : Controller
{

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

}
