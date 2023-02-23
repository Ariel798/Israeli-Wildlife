using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildlifeProject.Model;
using WildlifeProject.Services.AdminUserServices;
using WildlifeProjectTests.FakeRepositories;

namespace WildlifeProjectTests.FakeServices
{
    public class FakeAdminService : IAdminUserService
    {
        readonly FakeContext _fakeContext;
        public FakeAdminService(FakeContext fakeContext)
        {
            _fakeContext = fakeContext;
        }
        public bool ConfirmAdministrator(AdminUser user)
        {
            foreach (var adminUser in _fakeContext.AdminUsers)
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
            foreach (var animal in _fakeContext.Animals)
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
            foreach (var item in _fakeContext.Animals!)
            {
                if (item.AnimalId == animal.AnimalId)
                    return false;
            }
            try
            {
                _fakeContext.Animals.Add(animal);
                _fakeContext.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }
        List<Animal> IAdminUserService.GetAnimal(int animalId)
        {
            var data = _fakeContext.Animals?.AsQueryable();
            data = data?.Where(a => a.AnimalId == animalId);
            return data?.ToList()!;
        }

        public bool EditAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAnimal(int animalId)
        {
            throw new NotImplementedException();
        }
    }
}
