using WebApiProject.Models;

namespace WebApiProject.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllTasks();
        Task<TaskItem> GetTaskById (int id);
        Task<TaskItem> AddTask (TaskItem task);
        Task UpdateTask (TaskItem task);
        Task DeleteTask (int id);

    }
}
