using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lerin.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            return View();
        }

        // GET: UserController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
