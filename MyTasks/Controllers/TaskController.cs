using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Core.Models;
using MyTasks.Core.ViewModels;
using MyTasks.Persistence.Extensions;
using MyTasks.Persistence.Repositorys;
using System.Security.Claims;

namespace MyTasks.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private TaskRepository _taskRepository = new TaskRepository();


        public IActionResult Tasks()
        {
            var userId = User.GetUserId();

            var vm = new TasksViewModel
            {
                FilterTasks = new FilterTasks(),
                Tasks = _taskRepository.Get(userId),
                Categories = _taskRepository.GetCategories()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Tasks(TasksViewModel viewModel)
        {
            var userId = User.GetUserId();

            var tasks = _taskRepository.Get(userId,
                viewModel.FilterTasks.IsExecuted,
                viewModel.FilterTasks.CategoryId,
                viewModel.FilterTasks.Title);

            return PartialView("_TasksTable", tasks);
        }

        public IActionResult Task(int id = 0)
        {
            var userId = User.GetUserId();

            var task = id == 0 ?
                new Core.Models.Domains.Task { Id = 0, UserId = userId, Term = DateTime.Today } :
                _taskRepository.Get(id, userId);

            var vm = PreparetaskViewModel(task);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Task(Core.Models.Domains.Task task)
        {
            var userId = User.GetUserId();
            task.UserId = userId;

            if (!ModelState.IsValid)
            {
                var vm = PreparetaskViewModel(task);

                return View("Task", vm);
            }

            if (task.Id == 0)
                _taskRepository.Add(task);
            else
                _taskRepository.Update(task);

            return RedirectToAction("Tasks");
        }

        public TaskViewModel PreparetaskViewModel(Core.Models.Domains.Task task)
        {
            return new TaskViewModel
            {
                Task = task,
                Heading = task.Id == 0 ?
                "Dodawanie nowego zadania" : "Edytowanie zadania",
                Categories = _taskRepository.GetCategories()
            };
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var userId = User.GetUserId();

            try
            {
                _taskRepository.Finish(id, userId);
            }
            catch (Exception e)
            {
               return Json(new {Success = false, message = e.Message});
            }

            return Json(new { Success = true });
        }

        [HttpPost]
        public IActionResult Finish(int id)
        {
            var userId = User.GetUserId();

            try
            {
                _taskRepository.Finish(id, userId);
            }
            catch (Exception e)
            {
                return Json(new { Success = false, message = e.Message });
            }

            return Json(new { Success = true });
        }
    }
}
