using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PlantC.CitoyensEntreprises.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TachesController : ControllerBase
    {
        // GET: TachesController
        public ActionResult Index()
        {
            return null;
        }

        // GET: TachesController/Details/5
        public ActionResult Details(int id)
        {
            return null;
        }

        // GET: TachesController/Create
        public ActionResult Create()
        {
            return null;
        }

        // POST: TachesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return null;
            }
        }

        // GET: TachesController/Edit/5
        public ActionResult Edit(int id)
        {
            return null;
        }

        // POST: TachesController/Edit/5
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
                return null;
            }
        }

        // GET: TachesController/Delete/5
        public ActionResult Delete(int id)
        {
            return null;
        }

        // POST: TachesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return null;
            }
        }
    }
}
