using Microsoft.AspNetCore.Mvc;
using MvcCoreEF.Repositories;
using MvcCoreEF.Models;
using Microsoft.Extensions.Hosting;

namespace MvcCoreEF.Controllers
{
    public class HospitalesController : Controller
    {
        RepositoryHospital repo;

        public HospitalesController(RepositoryHospital repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Hospital> hospitales = 
                await this.repo.GetHospitalesAsync();
            return View(hospitales);
        }

        public async Task<IActionResult> Details(int idHospital)
        {
            Hospital hosp =
                await this.repo.FindHospitalAsync(idHospital);
            return View(hosp);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Hospital hosp)
        {
            await this.repo.InsertHospitalAsync(hosp.IdHospital
                , hosp.Nombre, hosp.Direccion, hosp.Telefono, hosp.Camas);
            //REDIRECT CON PARAMETROS
            return RedirectToAction("Details", new { idHospital = hosp.IdHospital });
        }

        public async Task<IActionResult> Delete(int idHospital)
        {
            await this.repo.DeleteHospitalAsync(idHospital);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Update(int idHospital)
        {
            Hospital hosp =
                await this.repo.FindHospitalAsync(idHospital);
            return View(hosp);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Hospital hosp)
        {
            await this.repo.UpdateHospitalAsync(hosp.IdHospital
                , hosp.Nombre, hosp.Direccion, hosp.Telefono, hosp.Camas);
            return RedirectToAction("Index");
        }
    }
}
