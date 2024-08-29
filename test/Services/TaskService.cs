using System.Threading.Tasks;
using WebApiProject.Models;
using WebApiProject.Repositories;

namespace WebApiProject.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<TaskItem> AddTask(TaskItem task)
        {
            return await _taskRepository.AddTaskAsync(task);
        }

        public async Task DeleteTask(int id)
        {
            await _taskRepository.DeleteTaskAsync(id);
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasks()
        {
            return await _taskRepository.GetAllTasksAsync();
        }

        public async Task<TaskItem> GetTaskById(int id)
        {
            return await _taskRepository.GetTaskByIdAsync(id);
        }

        public async Task UpdateTask(TaskItem task)
        {
            await _taskRepository.UpdateTaskAsync(task);
        }
    }
}
