using FinalProjeckt.Data.DTOs;
using FinalProjeckt.Data.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace FinalProjeckt.Services;

public interface IProjectService
{
    Task<List<Project>> GetProjectAsync();
    Task<Project> GetProjectByIdAsync(int id);
    Task PostProjectAsync(PostProjectDto project);
    Task<Project> UpdateProjectAsync(int id, PutProjectDto project);
    
    Task DeleteProjectByIdAsync(int id);
}
