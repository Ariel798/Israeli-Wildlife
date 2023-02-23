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
    internal class TestAdmin
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
