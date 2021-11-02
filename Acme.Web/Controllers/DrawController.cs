using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.Web.Controllers
{
  public class DrawController : Controller
  {
    public IActionResult Index()
    {

      return View(BusinessLayer.Get.Participants());
    }

    public IActionResult Details()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Details(Models.DrawViewModel model)
    {

      var exsist = BusinessLayer.Create.ValidateExistingParticipant(model.Email, model.DateOfBirth);
      if (exsist)
      {
        ViewBag.Message = "Email already in use!";
        return View();
      }
      else
      {
       var create =  BusinessLayer.Create.Participant(model.Firstname, model.Lastname, model.Email, model.DateOfBirth);

        if (create)
        {
          return RedirectToAction("Index", "Draw");
        }
        else
        {
          return View();
        }
      }
    }
  }
}
