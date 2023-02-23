using Microsoft.AspNetCore.Mvc;
using WildlifeProject.Controllers;
using WildlifeProjectTests.FakeRepositories;
using WildlifeProjectTests.FakeServices;

namespace WildlifeProjectTests.ControllerTests
{
    [TestClass]
    internal class TestCatalogue
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            FakeContext fakeRepository = new FakeContext();
            var adminService = new FakeAdminService(fakeRepository);
            var adminFakeController = new AdminController(adminService);
            // Act
            var result = adminFakeController.SignIn(null) as ViewResult;

            // Assert
            Assert.AreEqual(404, result!.StatusCode);

        }
    }
}
