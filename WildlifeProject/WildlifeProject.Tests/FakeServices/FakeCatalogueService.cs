using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildlifeProject.Model;
using WildlifeProject.Services.Catalouge;
using WildlifeProjectTests.FakeRepositories;

namespace WildlifeProject.Tests.FakeServices
{
    public class FakeCatalogueService : ICatalougeService

    {
        readonly FakeContext _fakeContext;
        public FakeCatalogueService(FakeContext fakeContext)
        {
            _fakeContext = fakeContext;
        }

        public List<Animal> GetAnimals()
        {
            return new List<Animal>();
        }

        public List<Animal> GetFilterAnimals(int catagorySelect)
        {
            var items = _fakeContext.Animals?.Where(c => c.CategoryId == catagorySelect).ToList();
            var list = new List<Animal>();
            if (items != null)
                return items;
            return list!;
        }
    }
}
