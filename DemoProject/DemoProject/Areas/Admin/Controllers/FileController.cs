using DemoProject.Areas.Admin.Models.FileModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DemoProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FileController : Controller
    {
        private readonly ILogger<FileController> _logger;
        private readonly IOptions<FileUploadSettings> _fileUploadSettings;
        private readonly IHostEnvironment _environment;

        public FileController(ILogger<FileController> logger,
            IOptions<FileUploadSettings> fileUploadSettings,
            IHostEnvironment Environment)
        {
            _logger = logger;
            _fileUploadSettings = fileUploadSettings;
            _environment = Environment;
        }
        

        [HttpGet]
        public IActionResult UploadFile()
        {
            var uploadFolder = _fileUploadSettings.Value.UploadFolder;
            string wwwPath = _environment.ContentRootPath;
            var model = new FileUploadModel();
            model.GetAllFiles(wwwPath, uploadFolder);
            return View(model);
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            var model = new FileUploadModel();

            try
            {
                var uploadFolder = _fileUploadSettings.Value.UploadFolder;
                string wwwPath = _environment.ContentRootPath;
                model.UploadFile(file, uploadFolder);
                model.GetAllFiles(wwwPath, uploadFolder);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "failed to upload file");
            }

            return View(model);
        }

        public IActionResult DownloadFile(string fileName, string extentionType)
        {
            try
            {
                var uploadFolder = _fileUploadSettings.Value.UploadFolder;
                var download = new FileDownloadModel();
                var file = download.Download(fileName, extentionType, uploadFolder);
                return File(file.bytes, file.extentionType, file.filename);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "failed to download file");
                return RedirectToAction(nameof(UploadFile));
            }

        }

        public IActionResult Delete(string fileName)
        {
            try
            {
                var uploadFolder = _fileUploadSettings.Value.UploadFolder;
                var model = new FileDownloadModel();
                model.DeleteFile(fileName, uploadFolder);
                return RedirectToAction(nameof(UploadFile));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "failed to delete file");
                return RedirectToAction(nameof(UploadFile));
            }
        }

    }
}
