using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface ITaskRepository
    {
        public Task Add(Task_ task);
        public Task Update(Task_ task, int id);
        public Task Delete(int id);
        public Task<Task_> GetByID(int id);
        public Task<List<Task_>> GetAll();
        public Task<bool> TaskExists(int id);
    }
}
