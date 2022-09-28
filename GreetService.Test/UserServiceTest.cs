using GreetService.Contract;
using GreetService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GreetService.Test
{
    [TestClass]
    public class UserServiceTest
    {
        private Mock<IUserService> mockIUserService;
        private UserController userController;


        [TestMethod]
        public void UserControllerTests_Sucess()
        {
            mockIUserService = new Mock<IUserService>();
            userController = new UserController(mockIUserService.Object);
            mockIUserService.Setup(x => x.GetUser(1)).Returns(new Domain.User { Id = 1, FirstName = "Fabian", LastName = "Tham", Alias = new List<string>(){ "Nitin" } });
            ContentResult result = (ContentResult)userController.Index(1);
            Assert.AreEqual("Hello, Nitin", result.Content);
        }

        [TestMethod]
        public void UserControllerTests_Fail()
        {
            mockIUserService = new Mock<IUserService>();
            userController = new UserController(mockIUserService.Object);
            mockIUserService.Setup(x => x.GetUser(1)).Returns(new Domain.User { Id = 1, FirstName = "Fabian", LastName = "Tham", Alias = new List<string>() { "Nitin" } });
            ContentResult result = (ContentResult)userController.Index(2);
            Assert.AreEqual("Hello, World!", result.Content);
        }
    }
}