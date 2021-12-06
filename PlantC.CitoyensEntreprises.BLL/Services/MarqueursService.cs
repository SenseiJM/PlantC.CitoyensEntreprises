using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprise.DAL.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.BLL.Services
{
    public class MarqueursService
    {
        private readonly TagRepository _tagRepository;

        public MarqueursService(TagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public IEnumerable<Marqueurs> GetMarqueurs(List<string> tags, int? codepostal = null)
        {
            return _tagRepository.GetMarqueursByTag(tags, codepostal);
        }
    }
}
