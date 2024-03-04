using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Helpers;

namespace MvcCoreUtilidades.Controllers
{
    public class MailExampleController : Controller
    {
        private readonly HelperSendMails helperSendMails;

        public MailExampleController(HelperSendMails helperSendMails)
        {
            this.helperSendMails = helperSendMails;
        }

        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(string para, string asunto, string mensaje)
        {
            helperSendMails.EnviarCorreo(para, asunto, mensaje);
            ViewData["MENSAJE"] = "Email enviado correctamente";
            return View();
        }
    }
}
