using CadeMeuMedico.Models;
using System.Web.Mvc;
using System.Linq;

namespace CadeMeuMedico.Controllers{
    public class HomesController : BaseController{
        // GET: Homes
        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();
        public ActionResult Login(){
            ViewBag.Title = "Seja bem vindo(a)";
            return View();
        }

        public ActionResult Index(){
            ViewBag.Especialidades = new SelectList(db.Especialidades, "IDEspecialidade", "Nome");
            ViewBag.Cidades = new SelectList(db.Cidades, "IDCidade", "Nome");

            return View();
        }

        public ActionResult Pesquisar(Pesquisa pesquisa){
            var esp = pesquisa.IdEspecialidade;
            var medicos = from m in db.Medicos
                          where m.IDCidade == pesquisa.IdCidade && m.IDEspecialidade == pesquisa.IdEspecialidade
                          select new ResultadoPesquisa { Nome = m.Nome, Crm = m.CRM };

            return Json(medicos, JsonRequestBehavior.AllowGet);

        }
    }
}