using FinalProjeckt.Data.DTOs;
using FinalProjeckt.Data.Models;
using FinalProjeckt.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProjeckt.Services;

namespace FinalProjeckt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProjectController : ControllerBase
    {

        private IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProject()
        {
            var projectDb = await _projectService.GetProjectAsync();

            return Ok(projectDb);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var projectDb = await _projectService.GetProjectByIdAsync(id);

            if (projectDb == null)
            {
                return NotFound($"Project with id = {id} not found");
            }
            else
            {
                return Ok(projectDb);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteProjectById(int id)
        {
            await _projectService.DeleteProjectByIdAsync(id);

            return Ok("Deleted");
        }
        [HttpPost]
        public async Task<IActionResult> PostProject([FromBody] PostProjectDto payload)
        {
            await _projectService.PostProjectAsync(payload);

            return Ok("New Project created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjectById(int id, [FromBody] PutProjectDto payload)
        {
            await _projectService.UpdateProjectAsync(id, payload);

            return Ok($"Project with id = {id} was updated");
        }
    }
}


