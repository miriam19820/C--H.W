using Microsoft.AspNetCore.Mvc;
using NewspaperServer.Models;
using System.Linq;

namespace NewspaperServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly NewContext _context;

        public WorkersController(NewContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
         
            return Ok(_context.Workers.ToList());
        }

        
        [HttpPost]
        public IActionResult Create(Worker worker) 
        {
            if (worker == null)
            {
                return BadRequest("הנתונים שהתקבלו ריקים");
            }

            _context.Workers.Add(worker); 
            _context.SaveChanges();
            return Ok(worker);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(string id, Worker worker) 
        {
            if (id != worker.WorkerId)
            {
                return BadRequest("מזהה העובד אינו תואם");
            }

            _context.Workers.Update(worker); 
            _context.SaveChanges();
            return Ok(worker);
        }

      
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var workerToDelete = _context.Workers.Find(id); 

            if (workerToDelete == null)
            {
                return NotFound();
            }

            _context.Workers.Remove(workerToDelete);
            _context.SaveChanges();
            return Ok("העובד נמחק בהצלחה");
        }
    }
}