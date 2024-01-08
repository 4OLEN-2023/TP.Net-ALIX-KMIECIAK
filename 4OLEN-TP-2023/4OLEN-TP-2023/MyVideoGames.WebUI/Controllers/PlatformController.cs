using Microsoft.AspNetCore.Mvc;
using MyVideoGames.Console.DataProvider;
using MyVideoGames.Console.DataProvider.Interface;
using MyVideoGames.Model;
using MyVideoGames.WebUI.Models;

namespace MyVideoGames.WebUI.Controllers
{
    public class PlatformController : Controller
    {
        private readonly IPlatformDataProvider platformDataProvider;

        public PlatformController(IPlatformDataProvider _platformDataProvider)
        {
            platformDataProvider = _platformDataProvider;
        }

        public IActionResult Index()
        {
            List<Platform> data = platformDataProvider.GetPlatforms().ToList();

            PlatformListViewModel model = new ()
            {
                PageTitle = "Platforms List"
            };

            if (data != null)
            {
                model.Platforms = data;
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult AddOrEdit(int? id = null)
        {
            Platform platformToAddOrEdit = new();

            if (id.HasValue)
            {
                platformToAddOrEdit = platformDataProvider.GetPlatformById(id.Value);
            }

            AddOrEditPlatformViewModel model = new()
            {
                PlatformToAddOrEdit = platformToAddOrEdit
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddOrEdit(AddOrEditPlatformViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.PlatformToAddOrEdit.Id != 0)
            {
                platformDataProvider.Update(model.PlatformToAddOrEdit);
            }
            else
            {
                platformDataProvider.Add(model.PlatformToAddOrEdit);
            }

            return this.RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            platformDataProvider.Delete(id);

            return this.RedirectToAction("Index");
        }
    }
}