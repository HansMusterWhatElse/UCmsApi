using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        // GET api/pages
        public IActionResult Get()
        {
            List<Page> pages = _context.Pages.ToList();
            return Json(pages);
        }

        // GET api/pages/slug
        [HttpGet("{slug}")]
        public IActionResult Get(string slug)
        {
            Page page = _context.Pages.SingleOrDefault(x => x.Slug == slug);
            if (page == null)
            {
                return Json("PageNotFound");
            }
            return Json(page);
        }

        // POST api/pages/create
        [HttpPost("create")]
        public IActionResult create([FromBody]Page page)
        {
            page.Slug = page.Title.Replace(" ", "-").ToLower();
            page.HasSidebar = page.HasSidebar ?? "no";

            var slug = _context.Pages.FirstOrDefault(x => x.Slug == page.Slug);
            if (slug != null)
            {
                return Json("pageExists");
            }
            else
            {
                _context.Pages.Add(page);
                _context.SaveChanges();

                return Json("ok");
            }
        }
    }
}