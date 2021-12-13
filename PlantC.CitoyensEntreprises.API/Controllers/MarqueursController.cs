using Microsoft.AspNetCore.Mvc;
using PlantC.CitoyensEntreprises.API.DTO.Marqueurs;
using PlantC.CitoyensEntreprises.BLL.Services;
using PlantC.CitoyensEntreprises.API.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.API.Controllers
{
    public class MarqueursController : Controller
    {
        private readonly MarqueursService _marqueursService;

        public MarqueursController(MarqueursService marqueursService)
        {
            _marqueursService = marqueursService;
        }

        //[HttpGet]
        //public IActionResult GetMarqueursByTag(List<string> tags, int? codepostal = null)
        //{
        //    IEnumerable<MarqueursDTO> dto = _marqueursService.GetMarqueurs(tags, codepostal).Select(m =>m.ToMarqueursDTO());
        //    return Ok(dto);
        //}

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_marqueursService.GetMarqueurs().Select(m => m.ToMarqueursDTO()));
        }
    }
}
