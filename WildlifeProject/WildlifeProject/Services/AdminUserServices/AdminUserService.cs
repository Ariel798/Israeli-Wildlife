 using Microsoft.EntityFrameworkCore;
using WildlifeProject.Model;
using WildlifeProject.Repository;

namespace WildlifeProject.Services.AdminUserServices
{
    public class AdminUserService : IAdminUserService
    {
        readonly AdminContext _adminContext;
        public AdminUserService(AdminContext adminContext)
        {
            _adminContext = adminContext;
        }
        public bool ConfirmAdministrator(AdminUser user)
        {
            foreach (var adminUser in _adminContext.AdminUsers!)
            {
                if (adminUser.UserName == user.UserName && adminUser.Password == user.Password)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Animal> GetAnimals()
        {
            var list = new List<Animal>();
            foreach (var animal in _adminContext.Animals!.Include(c => c.Comments))
            {
                if (animal.Name != null)
                {
                    list.Add(animal);
                }
            }
            return list;
        }
        public bool CreateAnimal(Animal animal)
        { 
            foreach(var item in _adminContext.Animals!)
            {
                if (item.AnimalId == animal.AnimalId)
                    return false;
            }
            _adminContext.Database.OpenConnection();
            try
            {
            _adminContext.Animals?.Add(animal);
            _adminContext.SaveChanges();
            }
            finally
            {
            _adminContext.Database.CloseConnection();
            }

            return true;
        }
        public bool DeleteAnimal(int animalId)
        {
            _adminContext.Database.OpenConnection();
            try
            {
                var animal = _adminContext.Animals?.Find(animalId);
                _adminContext.Animals?.Remove(animal!);
                _adminContext.SaveChanges();
            }
            finally
            {
                _adminContext.Database.CloseConnection();
            }

            return true;
        }
        public bool EditAnimal(Animal animal)
        {
            _adminContext.Database.OpenConnection();
            try
            {
                _adminContext.Animals?.Update(animal!);
                _adminContext.SaveChanges();
            }
            finally
            {
                _adminContext.Database.CloseConnection();
            }

            return true;
        }
        List<Animal> IAdminUserService.GetAnimal(int animalId)
        {
            var data = _adminContext.Animals?.Include(c => c.Comments).AsQueryable();
            data = data?.Where(a => a.AnimalId == animalId);
            return data?.ToList()!;
        }
    }
}
