using WildlifeProject.Model;
using WildlifeProject.Repository;

namespace WildlifeProject.Services.Catalouge
{
    public class CatalougeService : ICatalougeService
    {
        readonly AdminContext _adminContext;
        public CatalougeService(AdminContext adminContext)
        {
            _adminContext = adminContext;
        }

        public List<Animal> GetAnimals()
        {
            var list = new List<Animal>();
            foreach (var animal in _adminContext.Animals!)
            {
                if (animal.Name != null)
                {
                    list.Add(animal);
                }
            }
            return list;
        }
        public List<Animal> GetFilterAnimals(int catagorySelect)
        {
            var items = _adminContext.Animals?.Where(c => c.CategoryId == catagorySelect).ToList();
            var list = new List<Animal>();
            if (items != null)
                return items;
            return list!;
        }
    }
}
