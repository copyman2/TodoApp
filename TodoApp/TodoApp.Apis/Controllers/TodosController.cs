using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Apis.Controllers
{
    [Route("api/[Controller]")]
    public class TodosController : ControllerBase
    {
        private ITodoRepository _repository;

        public TodosController()
        {
            _repository = new TodoRepositoryJson("C:\\temp\\todos.json");
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            //return Content("안녕하세요");
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public IActionResult Add([FromBody]Todo dto)
        {
            _repository.Add(dto);
            return Ok(dto);
        }
    }
}
