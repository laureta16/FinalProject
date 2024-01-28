using FinalProjeckt.Data;
using FinalProjeckt.Data.DTOs;
using FinalProjeckt.Data.Models;
using FinalProjeckt.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace FinalProjeckt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TaskController : ControllerBase
    {

        private ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTask()
        {
            var taskDb = await _taskService.GetTaskAsync();

            return Ok(taskDb);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var taskDb = await _taskService.GetTaskByIdAsync(id);

            if (taskDb == null)
            {
                return NotFound($"Task with id = {id} not found");
            }
            else
            {
                return Ok(taskDb);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTaskById(int id)
        {
            await _taskService.DeleteTaskByIdAsync(id);

            return Ok("Deleted");
        }
        [HttpPost]
        public async Task<IActionResult> PostTask([FromBody] PostTaskDto payload)
        {
            await _taskService.PostTaskAsync(payload);

            return Ok("New Task created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskById(int id, [FromBody] PutTaskDto payload)
        {
            await _taskService.UpdateTaskAsync(id, payload);

            return Ok($"Task with id = {id} was updated");
        }
    }
}