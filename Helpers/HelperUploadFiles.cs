using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace MvcCoreUtilidades.Helpers
{
    public class HelperUploadFiles
    {
        private readonly IWebHostEnvironment hostEnvironment;

        public HelperUploadFiles(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

        public string SubirArchivo(IFormFile fichero, string carpeta)
        {
            string folderPath = Path.Combine(hostEnvironment.WebRootPath, carpeta);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, fichero.FileName);

            using (Stream stream = new FileStream(filePath, FileMode.Create))
            {
                fichero.CopyTo(stream);
            }

            return filePath;
        }
    }
}
