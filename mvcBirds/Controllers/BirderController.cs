using Microsoft.AspNetCore.Mvc;
using mvcBirds.Models;
using mvcBirds.Services;

namespace mvcBirds.Controllers
{
    public class BirderController : Controller
    {

        private readonly TableStorageServices _tableStorageService;

        public BirderController(TableStorageServices tableStorageServices)
        {
            _tableStorageService = tableStorageServices;
        }
        public async Task<IActionResult> Index()
        {
            var birders = await _tableStorageService.GetAllBirdersAsync();
            return View(birders);
        }
        [HttpPost]
        public async Task<IActionResult> AddBirder(Birder birder)
        {
            birder.PartitionKey = "BirderPartition"; // Set a valid PartitionKey
            birder.RowKey = Guid.NewGuid().ToString(); // Generate a unique RowKey

            await _tableStorageService.AddBirderAsync(birder);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddBirder()
        {
            return View();
        }
    }
}
