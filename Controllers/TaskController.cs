using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskAdministrator.Models;

namespace TaskAdministrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskDbContext _baseDatos;

        public TaskController(TaskDbContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var taskList = await _baseDatos.Tasks.ToListAsync();
            return Ok(taskList);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddTask([FromBody] Models.Task request)
        {
            await _baseDatos.Tasks.AddAsync(request);
            await _baseDatos.SaveChangesAsync();
            return Ok(request);
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var taskToDelete = await _baseDatos.Tasks.FindAsync(id);
            if (taskToDelete == null)
            {
                return BadRequest("No task found!");
            }
            _baseDatos.Tasks.Remove(taskToDelete);
            await _baseDatos.SaveChangesAsync();
            return Ok();
        }
    }
}
