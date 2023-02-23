using Microsoft.EntityFrameworkCore;
using WildlifeProject.Model;
using WildlifeProject.Repository;

namespace WildlifeProject.Services.Home
{
    public class ServiceHome : IServiceHome
    {
        readonly AdminContext _adminContext;
        public ServiceHome(AdminContext adminContext)
        {
            _adminContext = adminContext;
        }

        public List<Animal> GetNoticedAnimals()
        {
            var list = new List<Animal>();
            var dataOfNoticed = _adminContext.Animals?.Include(c => c.Comments).AsQueryable().OrderByDescending(t => t.Comments!.Count).Take(2);
            list = dataOfNoticed?.ToList(); ;
            return list!;
        }
    }
}
