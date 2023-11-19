using FinalProjeckt.Data.DTOs;
using FinalProjeckt.Data.Models;
using FinalProjeckt.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjeckt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var ProjectDb = FakeDB.ProjectDb.ToList();

            return Ok(ProjectDb);
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            var ProjectsDb = FakeDB.ProjectDb.FirstOrDefault(x => x.Id == id);

            if (ProjectsDb == null)
            {
                return NotFound($"Project with id = {id} not found");
            }
            else
            {
                return Ok(ProjectsDb);
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteProjectById(int id)
        {
            var ProjectsDb = FakeDB.ProjectDb.FirstOrDefault(x => x.Id == id);
            if (ProjectsDb == null)
            {
                return NotFound($"Project with id = {id} not found");
            }
            else
            {
                FakeDB.ProjectDb.Remove(ProjectsDb);
                return Ok($"Project with id = {id} was removed");
            }
        }
        [HttpPost]
        public IActionResult PostProject([FromBody] PostProjectDto payload)
        {
            var newProject = new Project()
            {
                Id = new Random().Next(10, 100),
                Name = payload.Name,
                Description = payload.Description,
                StartDate = payload.StartDate,
                EndDate = payload.EndDate
            };

            FakeDB.ProjectDb.Add(newProject);

            return Ok("New Project");
        }



        [HttpPut("{id}")]
        public IActionResult UpdateProjectsById(int id, [FromBody] PutProjectDto payload)
        {
            var ProjectsDb = FakeDB.ProjectDb.FirstOrDefault(x => x.Id == id);

            if (ProjectsDb == null)
            {
                return NotFound($"Project with id = {id} not found");
            }
            else
            {
                ProjectsDb.Name = payload.Name;
                ProjectsDb.Description = payload.Description;
                ProjectsDb.StartDate = payload.StartDate;
                ProjectsDb.EndDate = payload.EndDate;


                return Ok($"Project with id = {id} was updated");
            }
        }

    }
}


