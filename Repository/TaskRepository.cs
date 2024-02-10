using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext dataContext_;
        private object _context;

        public TaskRepository(DataContext dataContext) 
        {
            dataContext_ = dataContext;
        }
        public async Task Add(Task_ task)
        {
            dataContext_.Tasks.Add(task);
            await dataContext_.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var task_ = await dataContext_.Tasks.FindAsync(id);
            dataContext_.Tasks.Remove(task_);
            await dataContext_.SaveChangesAsync();
        }

        public async Task<List<Task_>> GetAll()
        {
            return await dataContext_.Tasks.ToListAsync();
        }

        public async Task<Task_> GetByID(int id)
        {
            var task_ = await dataContext_.Tasks.FindAsync(id);
            return task_;
        }

        public async Task Update(Task_ task, int id)
        {
            Task_ taskToUpdate = await dataContext_.Tasks.FindAsync(id);
            taskToUpdate.Name = task.Name;
            taskToUpdate.Description = task.Description;
            taskToUpdate.Statuc_ID = task.Statuc_ID;
            //dataContext_.Entry(task).State = EntityState.Modified;
            await dataContext_.SaveChangesAsync();
        }
        public async Task<bool> TaskExists(int id)
        {
            return await dataContext_.Tasks.AnyAsync(e => e.Id == id);
        }
    }
}
