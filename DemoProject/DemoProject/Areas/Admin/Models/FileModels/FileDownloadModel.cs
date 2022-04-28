namespace DemoProject.Areas.Admin.Models.FileModels
{
    public class FileDownloadModel
    {
        public List<FileInfo> Files { get; set; }

        public void GetAllFiles()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var folderPath = config["FileUploadSettings:UploadFolder"];
            var files = Directory
               .GetFiles(folderPath, "*.*")
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
                    continue;
                }
            }
        }

        public (byte[] bytes, string extentionType, string filename) Download(string fileName, string extentionType, string uploadFolder)
        {
            string path = Path.Combine(uploadFolder, fileName);

            byte[] bytes = System.IO.File.ReadAllBytes(path);
            if (extentionType == ".json")
            {
                extentionType = "application / json";
            }
            else if(extentionType == ".txt")
            {
                extentionType = "text/plain";
            }

            return (bytes, "application/json", fileName);
        }

        internal void DeleteFile(string fileName, string uploadFolder)
        {
            string path = Path.Combine(uploadFolder, fileName);
            System.IO.File.Delete(path);
        }
    }
}
