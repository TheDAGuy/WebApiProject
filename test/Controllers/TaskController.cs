using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Models;
using WebApiProject.Services;

namespace WebApiProject.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/{controller}")]
    [ApiController]
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskService _context;
        public TaskController(ITaskService context)
        {
            _context = context;
        }

        [HttpGet]
        [ResponseCache(Duration =120)]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = _context.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        [ResponseCache(Duration = 120)]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = _context.GetTaskById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskItem task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdTask = await _context.AddTask(task);
            return CreatedAtAction(nameof(CreateTask), new { id  = createdTask.Id}, createdTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskItem task)
        {
            if(id != task.Id)
            {
                return BadRequest();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _context.UpdateTask(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _context.DeleteTask(id);
            return NoContent();
        }
        
    }
}
