using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildlifeProject.Controllers;
using WildlifeProject.Tests.FakeServices;
using WildlifeProjectTests.FakeRepositories;
using WildlifeProjectTests.FakeServices;

namespace WildlifeProjectTests.ControllerTests
{
    [TestClass]
    public class TestCatalogue
    {
        [TestMethod]
        public void TestMethodIndex()
        {
            // Arrange
            FakeContext fakeRepository = new FakeContext();
            var fakeCatalogueService = new FakeCatalogueService(fakeRepository);
            var catalogueController = new CatalogueController(fakeCatalogueService);
            // Act
            var result = catalogueController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
    }
}
