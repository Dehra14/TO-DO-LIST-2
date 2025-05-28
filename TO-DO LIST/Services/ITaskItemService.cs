using TO_DO_LIST.Models;

namespace TO_DO_LIST.Services
{
    public interface ITaskItemService
    {
        public ApiResponse<IEnumerable<TaskItem>> GetAllTasks(string? status, int? priority, DateTime? dueDate);
        public ApiResponse<TaskItem> GetTaskById(int id);
        public ApiResponse<TaskItem> CreateTask(TaskItem task);
        public ApiResponse<TaskItem> UpdateTask(int id, TaskItem task);
        public ApiResponse<bool> DeleteTask(int id);
        public ApiResponse<TaskItem> MarkTaskAsComplete(int id);
    }

}
