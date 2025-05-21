using TO_DO_LIST.Data;
using TO_DO_LIST.Interface;
using TO_DO_LIST.Models;

namespace TO_DO_LIST.Repository
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly DataContext _context;
        public TaskItemRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<TaskItem> GetAllTasks(string status, int? priority, DateTime? dueDate)
        {
            var query = _context.Tasks.AsQueryable();
            if (status != null)
            {
                query = query.Where(t => t.Status == status);
            }
            if (priority.HasValue)
            {
                query = query.Where(t => t.Priority == priority.ToString());
            }
            if (dueDate.HasValue)
            {
                query = query.Where(t => t.DueDate.Date == dueDate.Value.Date);
            }
            return query.ToList();
        }

        public TaskItem GetTaskById(int id)
        {
            return _context.Tasks.Find(id);
        }
        public TaskItem AddTask(TaskItem task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }
        public void UpdateTask(TaskItem task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }
        public void DeleteTask(int id)
        {
            var task = GetTaskById(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

       
    }
    

    
}
