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
      return View(BusinessLayer.Get.ParticipantDraws());
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Register(Models.DrawViewModel model)
    {
      var years = ((DateTime.Now - model.DateOfBirth).Days / 365);
      
      if (years < 18)
      {
        ViewBag.Message = "You are to young to register!";
        return View();
      }

      var valitserialnumber = BusinessLayer.Create.SerialNumberAlreadyRegistred(model.SerialNumber);
      if (valitserialnumber)
      {
        ViewBag.Message = "Serialnumber already registred!";
        return View();
      }

      var exsist = BusinessLayer.Create.ValidateExistingParticipant(model.Email, model.DateOfBirth);
      if (exsist)
      {
        ViewBag.Message = "Email already in use!";
        return View();
      }
      else
      {
       var create =  BusinessLayer.Create.Participant(model.Firstname, model.Lastname, model.Email, model.DateOfBirth);
        var addSerialNumber = BusinessLayer.Create.Draw(model.Email, model.SerialNumber);
        if (create && addSerialNumber)
        {
          return RedirectToAction("Index", "draw");
        }
        else
        {
          return View();
        }
      }
    }

    public IActionResult RegisterProduct()
    {
      return View();
    }

    [HttpPost]
    public IActionResult RegisterProduct(Models.DrawViewModel model)
    {
      var serialNumberAlreadyRegistred = BusinessLayer.Create.SerialNumberAlreadyRegistred(model.SerialNumber);
      if (serialNumberAlreadyRegistred)
      {
        ViewBag.Message = "Serialnumber already registred!";
        return View();
      }

      var exsist = BusinessLayer.Create.ValidateExistingParticipant(model.Email, model.DateOfBirth);
      if (!exsist)
      {
        ViewBag.Message = "Participant does not exist register first!";
        return View();
      }
      else
      {
        var create = BusinessLayer.Create.Draw(model.Email,model.SerialNumber);
        if (create)
        {
          return RedirectToAction("Index", "draw");
        }
        else
        {
          return View();
        }
      }
    }
  }
}
