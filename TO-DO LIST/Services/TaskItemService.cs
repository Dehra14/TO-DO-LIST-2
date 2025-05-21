using TO_DO_LIST.Models;

namespace TO_DO_LIST.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _repository;
        private readonly ILogger<TaskItemService> _logger ;

       public TaskItemService(ITaskItemRepository repository, ILogger<TaskItemService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public ApiResponse<IEnumerable<TaskItem>> GetAllTasks(string status, int? priority, DateTime? dueDate)
        {
            try
            {
                var tasks = _repository.GetAllTasks(status, priority, dueDate);
                return new ApiResponse<IEnumerable<TaskItem>>(tasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving tasks");
                return new ApiResponse<IEnumerable<TaskItem>>(null, "Error retrieving tasks");
            }
        }
    }
}
