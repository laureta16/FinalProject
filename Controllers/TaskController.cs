using FinalProjeckt.Data;
using FinalProjeckt.Data.DTOs;
using FinalProjeckt.Data.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace FinalProjeckt.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TaskController:ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var TaskDb = FakeDB.TasksDb.ToList();

            return Ok(TaskDb);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var TasksDb = FakeDB.TasksDb.FirstOrDefault(x => x.Id == id);

            if (TasksDb == null)
            {
                return NotFound($"Task with id = {id} not found");
            }
            else
            {
                return Ok(TasksDb);
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteTaskById(int id)
        {
            var TasksDb = FakeDB.TasksDb.FirstOrDefault(x => x.Id == id);
            if (TasksDb == null)
            {
                return NotFound($"Task with id = {id} not found");
            }
            else
            {
                FakeDB.TasksDb.Remove(TasksDb);
                return Ok($"Task with id = {id} was removed");
            }
        }
        [HttpPost]
        public IActionResult PostTasks([FromBody] PostTaskDto payload)
        {
            var newTask = new Tasks()
            {
                Id = new Random().Next(10, 100),
                Title = payload.Title,
                Description = payload.Description,
                DueDate = payload.DueDate,
                Status = payload.Status
            };

            FakeDB.TasksDb.Add(newTask);

            return Ok("New Book created");
        }


        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, [FromBody] PutTaskDto payload)
        {
            var TasksDb = FakeDB.TasksDb.FirstOrDefault(x => x.Id == id);

            if (TasksDb == null)
            {
                return NotFound($"Task with id = {id} not found");
            }
            else
            {
                TasksDb.Title = payload.Title;
                TasksDb.Description = payload.Description;
                TasksDb.DueDate = payload.DueDate;
                TasksDb.Status = payload.Status;


                return Ok($"Task with id = {id} was updated");
            }
        }

    }
}
