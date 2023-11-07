using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private static List<Todo> todos = new List<Todo>();
        private static int todoId = 1;

        public IActionResult Index()
        {
            return View(todos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            todo.Id = todoId++;
            todos.Add(todo);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Todo todo = todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        [HttpPost]
        public IActionResult Edit(Todo todo)
        {
            Todo existingTodo = todos.FirstOrDefault(t => t.Id == todo.Id);
            if (existingTodo != null)
            {
                existingTodo.Name = todo.Name;
                existingTodo.Description = todo.Description;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Todo todo = todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                todos.Remove(todo);
            }
            return RedirectToAction("Index");
        }
    }
}
