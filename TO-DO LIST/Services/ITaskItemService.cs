using TO_DO_LIST.Models;

namespace TO_DO_LIST.Services
{
    public interface ITaskItemService
    {
        ApiResponse<IEnumerable<TaskItem>> GetAllTasks(string status, int? priority, DateTime? dueDate);
        ApiResponse<TaskItem> GetTaskById(int id);
        ApiResponse<TaskItem> CreateTask(TaskItem task);
        ApiResponse<TaskItem> UpdateTask(int id, TaskItem task);
        ApiResponse<bool> DeleteTask(int id);
        ApiResponse<TaskItem> MarkTaskAsComplete(int id);
    }

}
