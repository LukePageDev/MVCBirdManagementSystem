using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvcBirds.Models;
using mvcBirds.Services;

namespace mvcBirds.Controllers
{
    public class BirdController : Controller
    {
        private readonly BlobService _blobService;
        private readonly TableStorageServices _tableStorageService;

        public BirdController(BlobService blobService, TableStorageServices tableStorageService)
        {
            _blobService = blobService;
            _tableStorageService = tableStorageService;
        }
        public async Task<IActionResult> Index()
        {
            var birds = await _tableStorageService.GetAllBirdsAsync();
            return View(birds);
        }
        [HttpGet]
        public IActionResult AddBird()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBird(Bird bird, IFormFile file)
        {
            if (file != null)
            {
                using var stream = file.OpenReadStream();
                var imageUrl = await _blobService.UploadAsync(stream, file.FileName);
                bird.ImageUrl = imageUrl;
            }
            if (ModelState.IsValid)
            {
                bird.PartitionKey = "BirdPartition"; // Set a valid PartitionKey
                bird.RowKey = Guid.NewGuid().ToString(); // Generate a unique RowKey 
                await _tableStorageService.AddBirdAsync(bird);
                return RedirectToAction("Index");
            }
            return View(bird);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBird(string partitionKey, string rowKey, Bird bird)
        {
            if (bird != null && !string.IsNullOrEmpty(bird.ImageUrl))
            {
                // Delete the associated blob image
                await _blobService.DeleteBlobAsync(bird.ImageUrl);
            }
            await _tableStorageService.DeleteBirdAsync(partitionKey, rowKey);
            return RedirectToAction("Index"); 
        }
    }
}
