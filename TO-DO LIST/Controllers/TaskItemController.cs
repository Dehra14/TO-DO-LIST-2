using Microsoft.AspNetCore.Mvc;
using TO_DO_LIST.Models;
using TO_DO_LIST.Services;

namespace TO_DO_LIST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : Controller
    {
        private readonly ITaskItemService _taskItemService;
        private readonly ILogger<TaskItemController> _logger;

        public TaskItemController(ITaskItemService taskItemService, ILogger<TaskItemController> logger)
        {
            _taskItemService = taskItemService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<ApiResponse<IEnumerable<TaskItem>>> GetAllTasks(
            string status, int? priority, DateTime? dueDate)
        {
            var response = _taskItemService.GetAllTasks(status, priority, dueDate);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<ApiResponse<TaskItem>> GetTaskById(int id)
        {
            var response = _taskItemService.GetTaskById(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<ApiResponse<TaskItem>> PostTask([FromBody] TaskItem task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<TaskItem> { Success = false, Message = "Invalid data", Data = null });
            }
            var response = _taskItemService.CreateTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = response.Data?.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<ApiResponse<TaskItem>> PutTask(int id, TaskItem task)
        {
            if (id != task.Id)
            {
                return BadRequest(new ApiResponse<TaskItem> { Success = false, Message = "ID mismatch" });
            }


            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<TaskItem> { Success = false, Message = "Invalid data" });
            }
            var response = _taskItemService.UpdateTask(id, task);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public ActionResult<ApiResponse<bool>> DeleteTask(int id)
        {
            var response = _taskItemService.DeleteTask(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPatch("{id}/complete")]
        public ActionResult<ApiResponse<TaskItem>> MarkTaskAsComplete(int id)
        {
            var response = _taskItemService.MarkTaskAsComplete(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
