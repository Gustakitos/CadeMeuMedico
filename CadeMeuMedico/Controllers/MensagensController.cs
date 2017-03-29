using System.Web.Mvc;

namespace CadeMeuMedico.Controllers{
    public class MensagensController : Controller{
        // GET: Mensagens
        public ActionResult Index(){
            return View();
        }

        public ActionResult BomDia(){
            return Content("Bom Dia");
        }

        public ActionResult BoaTarde(){
            return Content("Boa Tarde");
        }
    }
}