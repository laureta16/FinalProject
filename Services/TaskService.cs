using FinalProjeckt.Data;
using FinalProjeckt.Data.DTOs;
using FinalProjeckt.Data.Models;
using FinalProjeckt.Services;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Services
{

    public class TaskService : ITaskService
    {
        private AppDbContext _dbContext;

        public TaskService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Tasks>> GetTaskAsync()
        {
            var allTask = await _dbContext.Tasks.ToListAsync();
            return allTask;
        }

        public async Task<Tasks> GetTaskByIdAsync(int id)
        {
            var taskFromDb = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            return taskFromDb;
        }

        public async Task PostTaskAsync(PostTaskDto task)
        {
            var newTask = new Tasks()
            {
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                DueDate = task.DueDate
                
            };

            await _dbContext.Tasks.AddAsync(newTask);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Tasks> UpdateTaskAsync(int id, PutTaskDto task)
        {
            var taskFromDb = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if (taskFromDb != null)
            {
                taskFromDb.Title = task.Title;
                taskFromDb.Status = task.Status;
                taskFromDb.Description = task.Description;
                taskFromDb.DueDate = task.DueDate;

                await _dbContext.SaveChangesAsync();
            }

            return taskFromDb;
        }

        public async Task DeleteTaskByIdAsync(int id)
        {
            var taskFromDb = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if (taskFromDb != null)
            {
                _dbContext.Tasks.Remove(taskFromDb);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

