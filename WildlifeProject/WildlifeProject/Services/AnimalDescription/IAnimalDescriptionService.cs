using WildlifeProject.Model;

namespace WildlifeProject.Services.AnimalDescription
{
    public interface IAnimalDescriptionService
    {
        List<Animal> GetAnimal(int animalId);
    }
}
