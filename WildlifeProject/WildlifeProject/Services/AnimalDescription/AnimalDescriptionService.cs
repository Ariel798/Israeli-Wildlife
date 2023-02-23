using Microsoft.EntityFrameworkCore;
using WildlifeProject.Model;
using WildlifeProject.Repository;

namespace WildlifeProject.Services.AnimalDescription
{
    public class AnimalDescriptionService : IAnimalDescriptionService
    {
        readonly AdminContext _adminContext;
        public AnimalDescriptionService(AdminContext adminContext)
        {
            _adminContext = adminContext;
        }
        List<Animal> IAnimalDescriptionService.GetAnimal(int animalId)
        {
            var data = _adminContext.Animals?.Include(c => c.Comments).AsQueryable();
            data = data?.Where(a => a.AnimalId == animalId);
            return data?.ToList()!;
        }
    }
}
