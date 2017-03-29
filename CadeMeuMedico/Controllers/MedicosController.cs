using System.Web.Mvc;
using System.Linq;
using System.Data.Entity;
using CadeMeuMedico.Models;
using System;

namespace CadeMeuMedico.Controllers{
    public class MedicosController : Controller{
        private EntidadesCadeMeuMedicoBD db =
            new EntidadesCadeMeuMedicoBD();

        public ActionResult Index(){
            var medicos = db.Medicos.Include(X => X.Cidades)
                .Include(x=> x.Especialidades).ToList();

            return View(medicos);
        }

        public ActionResult Adicionar(){
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades,
                "IDEspecialidade", "Nome");

            return View();
        }


        [HttpPost]
        public ActionResult Adicionar(Medico medico){
            if (ModelState.IsValid){
                db.Medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCidade = new SelectList(db.Cidades
                ,"IDCidade","Nome",medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades
                ,"IDEspecialidade","Nome",medico.IDEspecialidade);

            return View(medico);
        }

        public ActionResult Editar(long id){
            Medico medico = db.Medicos.Find(id);

            ViewBag.IDCidade = new SelectList(db.Cidades
                , "IDCidade", "Nome", medico.IDCidade);

            ViewBag.IDEspecialidade = new SelectList(db.Especialidades,
                "IDEspecialidade", "Nome", medico.IDEspecialidade);

            return View(medico);
        }

        [HttpPost]
        public ActionResult Editar(Medico medico){
            if (ModelState.IsValid){
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCidade = new SelectList(db.Cidades,
                "IDCidade", "Nome", medico.IDCidade);

            ViewBag.IDEspecialidade = new SelectList(db.Especialidades,
                "IDEspecialidade", "Nome", medico.IDEspecialidade);

            return View(medico);

        }

        [HttpPost]
        public string Excluir(long id){
            try{
                Medico medico = db.Medicos.Find(id);
                db.Medicos.Remove(medico);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch{
                return Boolean.FalseString;
            }

        }
    }
}