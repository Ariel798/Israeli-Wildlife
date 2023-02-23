using WildlifeProject.Model;

namespace WildlifeProject.Services.AdminUserServices
{
    public interface IAdminUserService
    {
        bool ConfirmAdministrator(AdminUser user);
        bool CreateAnimal(Animal animal);
        bool EditAnimal(Animal animal);
        bool DeleteAnimal(int animalId);
        List<Animal> GetAnimals();
        List<Animal> GetAnimal(int animalId);
    }
}
