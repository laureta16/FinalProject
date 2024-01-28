using FinalProjeckt.Data;
using FinalProjeckt.Data.DTOs;
using FinalProjeckt.Data.Models;
using FinalProjeckt.Services;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Services
{

    public class ProjectService : IProjectService
    {
        private AppDbContext _dbContext;

        public ProjectService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Project>> GetProjectAsync()
        {
            var allProject = await _dbContext.Project.ToListAsync();
            return allProject;
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var ProjectFromDb = await _dbContext.Project.FirstOrDefaultAsync(x => x.Id == id);
            return ProjectFromDb;
        }

        public async Task PostProjectAsync(PostProjectDto project)
        {
            var newProject = new Project()
            {
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,

            };
            await _dbContext.Project.AddAsync(newProject);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Project> UpdateProjectAsync(int id, PutProjectDto project)
        {
            var projectFromDb = await _dbContext.Project.FirstOrDefaultAsync(x => x.Id == id);

            if (projectFromDb != null)
            {
                projectFromDb.Description = project.Description;
                projectFromDb.StartDate = project.StartDate;
                projectFromDb.EndDate = project.EndDate;

                await _dbContext.SaveChangesAsync();
            }

            return projectFromDb;
        }

        public async Task DeleteProjectByIdAsync(int id)
        {
            var customerFromDb = await _dbContext.Customer.FirstOrDefaultAsync(x => x.Id == id);

            if (customerFromDb != null)
            {
                _dbContext.Customer.Remove(customerFromDb);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
