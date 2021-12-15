using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Mappers;
using PlantC.CitoyensEntreprises.BLL.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlantC.CitoyensEntreprises.BLL.Services {
    public class MarqueursService
    {
        private readonly TagRepository _tagRepository;

        public MarqueursService(TagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public IEnumerable<MarqueurModel> GetMarqueurs()
        {
            IEnumerable<MarqueurModel> list = _tagRepository.GetMarqueurs().Select(m => m.ToModel());
            foreach (MarqueurModel marqueurs in list) {
               marqueurs.ListTags = _tagRepository.GetTagByProjet(marqueurs.IdProjet);
            }
            return list;
        }
    }
}
