using Microsoft.Extensions.Options;

namespace DemoProject.Areas.Admin.Models.FileModels
{
    public class FileUploadModel
    {
        public IFormFile File { get; set; }
        public List<FileInfo> Files { get; set; }

        public void UploadFile(IFormFile file, string uploadFolder)
        {
            if (file is not null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var contentType = file.ContentType;


                if (contentType == "text/plain" || contentType == "application/json")
                {
                    using (FileStream stream = new FileStream(Path.Combine(uploadFolder, fileName), FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

            }

        }


        public void GetAllFiles(string wwwPath, string uploadFolder)
        {
            string path = Path.Combine(wwwPath, uploadFolder);

            if (!Directory.Exists(path))
            {
               var x = Directory.CreateDirectory(path);
            }
          
            var files = Directory
               .GetFiles(uploadFolder, "*.*")
               .Where(file => file.ToLower().EndsWith("txt") || file.ToLower().EndsWith("json"))
               .ToList();

            Files = new List<FileInfo>();

            foreach (string item in files)
            {
                FileInfo fi = null;

                try
                {
                    fi = new System.IO.FileInfo(item);
                    Files.Add(fi);
                }
                catch (Exception ex)
                {
                    throw new FileNotFoundException(ex.Message);
                }
            }
        }
    }
}
