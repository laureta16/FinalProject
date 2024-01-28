using FinalProjeckt.Data.DTOs;
using FinalProjeckt.Data.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace FinalProjeckt.Services;

public interface ITaskService
{
    Task<List<Tasks>> GetTaskAsync();
    Task<Tasks> GetTaskByIdAsync(int id);
    Task PostTaskAsync(PostTaskDto task);
    Task<Tasks> UpdateTaskAsync(int id, PutTaskDto task);
    Task DeleteTaskByIdAsync(int id);
}
