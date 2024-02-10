using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Task_Controller : ControllerBase
    {
        private readonly ITaskRepository _repository;

        public Task_Controller(ITaskRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Get All Tasks")]
        public async Task<ActionResult<IEnumerable<Task_>>> GetTasks()
        {
          var list = _repository.GetAll();
          if (list == null)
          {
              return BadRequest("No Tasks Found");
          }
            return await list;
        }

        [HttpGet("{id}/Get Tasks by ID")]
        public async Task<ActionResult<Task_>> GetTask_(int id)
        {
          var task = await _repository.GetByID(id);
          if (task == null)
          {
              return BadRequest("No Task Found");
          }         
          return task;
        }

        [HttpPut("{id}/Upgrate Task")]
        public async Task<IActionResult> PutTask_(int id, Task_ task_)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _repository.TaskExists(id))
            {
                return BadRequest("No Task Found");
            }
            await _repository.Update(task_, id);

            return CreatedAtAction(nameof(GetTask_), new {id = task_.Id}, task_);
        }

        [HttpPost("Add Task")]
        public async Task<ActionResult<Task_>> PostTask_(Task_ task_)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _repository.Add(task_);  

            return CreatedAtAction(nameof(GetTask_),new {id = task_.Id}, task_);
        }

        [HttpDelete("{id}/Delete Task")]
        public async Task<IActionResult> DeleteTask_(int id)
        {
            if (!await _repository.TaskExists(id))
            {
                return BadRequest("No Task Found");
            }
            await _repository.Delete(id);

            return NoContent();
        }
    }
}
