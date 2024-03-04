using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Helpers;
using System.Diagnostics;


namespace MvcCoreUtilidades.Controllers
{
    public class UploadFilesController : Controller
    {
        private readonly HelperUploadFiles helperUploadFiles;

        public UploadFilesController(HelperUploadFiles helperUploadFiles)
        {
            this.helperUploadFiles = helperUploadFiles;
        }

        public IActionResult SubirFichero()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubirFichero(IFormFile fichero)
        {
            string carpeta = "uploads"; 

            string path = helperUploadFiles.SubirArchivo(fichero, carpeta);

            ViewData["MENSAJE"] = "Fichero subido a " + path;
            ViewData["URL"] = "URL"; 
            ViewData["ImagePath"] = $"/{carpeta}/{fichero.FileName}";
            return View();
        }
    }
}