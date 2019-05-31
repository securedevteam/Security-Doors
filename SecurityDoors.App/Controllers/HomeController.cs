﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecurityDoors.DataAccessLayer.Models;

namespace SecurityDoors.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
		public IActionResult About ()
		{
			return View();
		}
	}
}