using TO_DO_LIST.Models;

namespace TO_DO_LIST.Interface
{
    public interface ITaskItemRepository
    {
        IEnumerable<TaskItem> GetAllTasks(string status, int? priority, DateTime? dueDate);
        public TaskItem GetTaskById(int id);
        public TaskItem AddTask(TaskItem task);
        public void UpdateTask(TaskItem task);
        public void DeleteTask(int id);
    }
}
