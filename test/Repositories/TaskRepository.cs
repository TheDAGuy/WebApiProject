using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Data;
using WebApiProject.Models;

namespace WebApiProject.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TaskItem> AddTaskAsync(TaskItem task)
        {
            _context.Task.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.Task.FindAsync(id);
            if(task != null)
            {
                _context.Task.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            return await _context.Task.ToListAsync();
        }

        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            return await _context.Task.FindAsync(id);
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            _context.Task.Update(task);
            await _context.SaveChangesAsync();
        }

    }
}
