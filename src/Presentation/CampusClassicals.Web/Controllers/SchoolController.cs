﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace CampusClassicals.Web.Controllers
{
    public class SchoolController : Controller
    {
        public IActionResult All()
        {
            return View();
        }


    }
}
