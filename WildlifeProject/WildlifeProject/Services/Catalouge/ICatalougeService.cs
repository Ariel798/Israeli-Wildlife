using WildlifeProject.Model;

namespace WildlifeProject.Services.Catalouge
{
    public interface ICatalougeService
    {
        List<Animal> GetAnimals();
        List<Animal> GetFilterAnimals(int catagorySelect);

    }
}
