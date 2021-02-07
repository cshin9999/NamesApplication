using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NamesApplication.DbContexts;
using NamesApplication.Domain;

namespace NamesApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamesController : Controller
    {
        private readonly DataContext _context;

        public NamesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Name>> GetNames()
        {
            return _context.Names.ToList();
        }

        /*
        [HttpGet]
        public ActionResult<IEnumerable<Name>> GetNames()
        {
            return 
            return new JsonResult(_context.Names.ToList());
        }
        */

        [HttpGet("namesearch")]
        public ActionResult<Name> GetName(string firstName, string lastName)
        {
            return _context.Names.SingleOrDefault(c => c.FirstName == firstName && c.LastName == lastName); ;
        }

        /*
         * 
        [HttpGet("namesearch")]
        public IActionResult GetName(string firstName, string lastName)
        {
            return new JsonResult(_context.Names.Where(c => c.FirstName == firstName && c.LastName == lastName)); ;
        }
        */

        [HttpPost]
        public ActionResult<Name> CreateName([FromBody] Name name)
        {
            _context.Names.Add(name);
            _context.SaveChanges();

            return name;
        }
    }
}
