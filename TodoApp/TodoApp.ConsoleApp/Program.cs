using System;
using System.Collections.Generic;
using TodoApp.Models;

namespace TodoApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ITodoRepository _repository = new TodoRepositoryInMemory();
            List<Todo> todos = new List<Todo>();
            todos = _repository.GetAll();
            foreach (var t in todos)
            {
                Console.WriteLine($"{t.Id} - {t.Title}({t.IsDone}) ");
            }
            Console.WriteLine();

            Todo todo = new Todo { Title = "Database Study", IsDone = true };
            _repository.Add(todo);

            todos = _repository.GetAll();
            foreach (var t in todos)
            {
                Console.WriteLine($"{t.Id} - {t.Title}({t.IsDone}) ");
            }
        }
    }
}
