using Microsoft.AspNetCore.Mvc;
using NewspaperServer.Models;
using System.Linq;

namespace NewspaperServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewspapersController : ControllerBase
    {
       
        private readonly NewContext _context;

        public NewspapersController(NewContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Newspapers.ToList());
        }

        
        [HttpPost]
        public IActionResult Create(Newspaper newspaper)
        {
            if (newspaper == null)
            {
                return BadRequest("הנתונים שהתקבלו ריקים");
            }

            _context.Newspapers.Add(newspaper);
            _context.SaveChanges();
            return Ok(newspaper);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Newspaper newspaper)
        {
           
            if (id != newspaper.NewsId)
            {
                return BadRequest("מזהה העיתון אינו תואם");
            }

            _context.Newspapers.Update(newspaper);
            _context.SaveChanges();
            return Ok(newspaper);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var newspaperToDelete = _context.Newspapers.Find(id);

            if (newspaperToDelete == null)
            {
                return NotFound();
            }

            _context.Newspapers.Remove(newspaperToDelete);
            _context.SaveChanges();
            return Ok("העיתון נמחק בהצלחה");
        }
    }
}