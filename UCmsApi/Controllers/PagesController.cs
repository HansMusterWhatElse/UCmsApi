using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UCmsApi.Data;
using UCmsApi.Models;

namespace UCmsApi.Controllers
{
    [Route("api/[controller]")]
    public class PagesController : Controller
    {
        private readonly UCmsApiContext _context;

        public PagesController(UCmsApiContext context)
        {
            _context = context;
        }

        // GEt api/pages
        public IActionResult Get()
        {
            List<Page> pages = _context.Pages.ToList();
            return Json(pages);
        }
    }
}