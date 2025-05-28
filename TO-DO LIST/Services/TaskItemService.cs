using TO_DO_LIST.Interface;
using TO_DO_LIST.Models;

namespace TO_DO_LIST.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _repository;
        private readonly ILogger<TaskItemService> _logger;

        public TaskItemService(ITaskItemRepository repository, ILogger<TaskItemService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public ApiResponse<IEnumerable<TaskItem>> GetAllTasks(string? status, int? priority, DateTime? dueDate)
        {
            try
            {
                var tasks = _repository.GetAllTasks(status, priority, dueDate);
                return new ApiResponse<IEnumerable<TaskItem>> { Success = true, Data = tasks };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving tasks");
                return new ApiResponse<IEnumerable<TaskItem>> { Success = false, Message = "Error retrieving tasks" };
            }
        }

        public ApiResponse<TaskItem> GetTaskById(int id)
        {
            try
            {
                var task = _repository.GetTaskById(id);
                if (task == null)
                {
                    return new ApiResponse<TaskItem> { Success = false, Message = "Task not found" };
                }
                return new ApiResponse<TaskItem> { Success = true, Data = task };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving task with ID {id}");
                return new ApiResponse<TaskItem> { Success = false, Message = "Error retrieving task" };
            }
        }
    
            public ApiResponse<TaskItem> CreateTask(TaskItem task)
        {
            try
            {
                task.Status = "pending";
                var createdTask = _repository.AddTask(task);
                return new ApiResponse<TaskItem> { Success = true, Data = createdTask, Message = "Task created successfully" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating task");
                return new ApiResponse<TaskItem> { Success = false, Message = "Error creating task" };
            }
        }

        public ApiResponse<TaskItem> UpdateTask(int id, TaskItem task)
        {
            try
            {
                var existingTask = _repository.GetTaskById(id);
                if (existingTask == null)
                {
                    return new ApiResponse<TaskItem> { Success = false, Message = "Task not found" };
                }
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.DueDate = task.DueDate;
                existingTask.Priority = task.Priority;
                existingTask.Status = task.Status;

                _repository.UpdateTask(existingTask);
                return new ApiResponse<TaskItem> { Success = true, Data = existingTask, Message = "Task updated successfully" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating task with ID {id}");
                return new ApiResponse<TaskItem> { Success = false, Message = "Error updating task" };
            }
        }
        public ApiResponse<bool> DeleteTask(int id)
        {
            try
            {
                var task = _repository.GetTaskById(id);
                if (task == null)
                {
                    return new ApiResponse<bool> { Success = false, Message = "Task not found" };
                }
                _repository.DeleteTask(id);
                return new ApiResponse<bool> { Success = true, Data = true, Message = "Task deleted successfully" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting task with ID {id}");
                return new ApiResponse<bool> { Success = false, Message = "Error deleting task" };
            }
        }

        public ApiResponse<TaskItem> MarkTaskAsComplete(int id)
        {
            try
            {
                var task = _repository.GetTaskById(id);
                if (task == null)
                {
                    return new ApiResponse<TaskItem> { Success = false, Message = "Task not found" };
                }
                task.Status = "completed";
                _repository.UpdateTask(task);
                return new ApiResponse<TaskItem> { Success = true, Data = task, Message = "Task marked as complete" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error marking task with ID {id} as complete");
                return new ApiResponse<TaskItem> { Success = false, Message = "Error marking task as complete" };
            }
        }
    }
}


