using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using taskSchedulerWeb;

namespace taskSchedulerWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]



    public class TaskController : ControllerBase
    {
        private static TaskScheduler scheduler = new TaskScheduler();

        [HttpPost("add")]
        public IActionResult AddTask([FromBody] TaskRequest request)
        {
            scheduler.AddTask(request.Task);
            return Ok(new { message = $"Task added: {request.Task}" }); 
        }

        [HttpPost("process")]
        public IActionResult ProcessTask()
        {
            if (scheduler.HasPendingTasks())
            {
                string processed = scheduler.ProcessTask(); 
                return Ok(new { message = $"Processing: {processed}" }); 
            }else 
                 return Ok(new { message = "No tasks to process" }); 
        }
        [HttpGet("list")]
        public IActionResult GetTasks()
        {
            var tasks = scheduler.GetTasks(); 
            return Ok(tasks); 
        }

    }

    public class TaskRequest
    { 
    public string Task { get; set; } 
    }
}
