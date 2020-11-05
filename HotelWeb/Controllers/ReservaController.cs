using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HotelWeb.Controllers {
    public class ReservaController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
