﻿using Microsoft.AspNetCore.Mvc;
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
      return View();
    }

    public IActionResult Details()
    {
      return View();
    }
  }
}
