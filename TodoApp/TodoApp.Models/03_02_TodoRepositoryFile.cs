using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TodoApp.Models
{
    public class TodoRepositoryFile : ITodoRepository
    {
        private readonly string _filePath = "";
        private static List<Todo> _todos = new List<Todo>();

        //public TodoRepositoryFile()
        //{
        //    _todos = new List<Todo>
        //    {
        //        new Todo {Id=1, Title="ASP.NET Core Study", IsDone = false},
        //        new Todo {Id=2, Title="Blazor Study", IsDone = false},
        //        new Todo {Id=3, Title="C# Study", IsDone = true}
        //    };
        //}

        public TodoRepositoryFile(string filePath = @"C:\temp\todos.txt")
        {
            this._filePath = filePath;

            string[] todos = File.ReadAllLines(filePath, Encoding.Default);
            foreach (var t in todos)
            {
                var items = t.Split(',');
                _todos.Add(new Todo { Id = Convert.ToInt32(items[0]), Title = items[1], IsDone = Convert.ToBoolean(items[2])});
            }
        }
        // 인-메모리 데이터베이스 사용 영역
        public void Add(Todo model)
        {
            model.Id = _todos.Max(t => t.Id) + 1;
            _todos.Add(model);

            string data = "";
            foreach (var t in _todos)
            {
                data += $"{t.Id},{t.Title},{t.IsDone}{Environment.NewLine}";
            }
            
            using (StreamWriter sw = new StreamWriter(_filePath))
            {
                sw.Write(data);
                sw.Close();
                //sw.Dispose();
            }
        }

        public List<Todo> GetAll()
        {
            return _todos.ToList();
        }
    }


}
