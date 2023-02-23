using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildlifeProject.Controllers;
using WildlifeProject.Model;
using WildlifeProject.Services.AdminUserServices;
using WildlifeProjectTests.FakeRepositories;
using WildlifeProjectTests.FakeServices;

namespace WildlifeProjectTests.ControllerTests
{
    [TestClass]
    public class TestAdmin
    {
        [TestMethod]
        public void TestSignIn()
        {
            // Arrange
            FakeContext fakeRepository = new FakeContext();
            var adminService = new FakeAdminService(fakeRepository);
            var adminFakeController = new AdminController(adminService);
            var adminUser = new AdminUser { UserName = "", Password = "" };

            // Act
            var result = adminFakeController.SignIn(adminUser) as ViewResult;

            // Assert
            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void TestDelete()
        {
            // Arrange
            FakeContext fakeRepository = new FakeContext();
            var adminService = new FakeAdminService(fakeRepository);
            var adminFakeController = new AdminController(adminService);
            var fakeAnimal = new Animal { AnimalId = 1, Description = "Test", Name = "Test" };

            // Act
            var result = adminFakeController.Delete(fakeAnimal.AnimalId, null) as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }
    }
}
