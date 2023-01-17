using District.Infrastructure.IRepository;
using District.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace District.Controllers
{
    public class DistrictController : Controller
    {
        private readonly IDistrict _services;

        public DistrictController(IDistrict services)
        {
            _services = services;
        }

        // GET: DistrictController
        public ActionResult Index()
        {
            DistrictInfoModel model = new DistrictInfoModel();
            model.DistrictsList = _services.GetDistrictData();
            return View(model);
        }

        // GET: DistrictController/Details/5
        public ActionResult Details(int id)
        {
            DistrictInfo model = new DistrictInfo();
            model = _services.GetDistrictById(id);
            return View(model);
        }

        // GET: DistrictController/Create
        [HttpGet]
        public ActionResult AddEditDistrict(int id)
        {
            DistrictInfo model = new DistrictInfo();
            model = _services.GetDistrictById(id);
            if(model == null)
            {
                return View();
            }
            else
            {
                return View();

            }
        }

        // POST: DistrictController/Create
        [HttpPost]
        public ActionResult Create(DistrictInfo infomodel)
        {
            DistrictInfo model = new DistrictInfo();

            try
            {
                model = _services.AddDistrict(infomodel);

                if (model.TotalRowCount > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: DistrictController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DistrictController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DistrictController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: DistrictController/Delete/5
        [HttpPost]
        public ActionResult Delete(DistrictInfo infomodel)
        {
            DistrictInfo model = new DistrictInfo();

            try
            {
                model = _services.DeleteDistrict(infomodel);

                if (model.TotalRowCount > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
