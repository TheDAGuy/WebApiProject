using WebApiProject.Models;

namespace WebApiProject.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task<TaskItem> GetTaskByIdAsync(int id); 
        Task<TaskItem> AddTaskAsync(TaskItem task); 
        Task UpdateTaskAsync(TaskItem task); 
        Task DeleteTaskAsync(int id);
    }
}
