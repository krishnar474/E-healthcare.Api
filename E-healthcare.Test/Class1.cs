using System;
using Ehealthcare.Api.Controllers;
using Ehealthcare.Api;
using Ehealthcare.Entities;
using Ehealthcare.Data;
using NUnit.Framework;
using Moq;
using EHealthcare.Entities;
using ProjectManagement.Data;

namespace Ehealthcare.Test
{
    [TestFixture]
    public class UserControllerTest
    {
        private Mock<User> mockUser;
        private Mock<IBaseRepository<User>> UserRepositoryMock = new Mock<IBaseRepository<User>>();

        private UserController userControllerTest;
        private Mock<IBaseRepository<User>> mockIBaseRepo = new Mock<IBaseRepository<User>>();
        private Mock<AuthService> mockauthService;
        private Mock<AuthUserModel> mockauthUserModel;

        
        [Test]
        public void TestLoginAsync()
        {
            //UserRepositoryMock = new Mock<IBaseRepository<User>>();
            //mockUser = new Mock<User>();
            //mockUser.Setup(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())
            //UserRepositoryMock.Setup(service => service.Add(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<User>());


            //userControllerTest = new UserController(mockIBaseRepo.Object); 
            //var login = new Ehealthcare.Entities.Dto.LoginDto();
            //login.Email = "krishna@gmail.com";
            //login.Password = "test";
            //login.Type = "admin";
            //mockauthService = new Mock<AuthService>(UserRepository);
            //var result = userControllerTest.LoginUser(login);

            //Assert.AreEqual(result.Status, 200);
        }

        [Test]
        public void RegisterUserTest()
        {
            //UserRepositoryMock = new Mock<IBaseRepository<User>>();
            //UserRepositoryMock.Setup(x => x.Add(It.IsAny<User>())).ReturnsAsync(new User() { Email="admin@admin.com",Password="Password1", FirstName="Krishna", LastName="Raju", IsAdmin=true });
            userControllerTest = new UserController(UserRepositoryMock.Object);
            var result = userControllerTest.Register(new User() { Email = "admin@admin.com", Password = "Password1", FirstName = "Krishna", LastName = "Raju", IsAdmin = true });
            Assert.AreEqual(result, true);
        }
        [Test]
        public void LogInUserTest()
        {
            userControllerTest = new UserController(UserRepositoryMock.Object);
            var authUserModel = new AuthUserModel
            {
                ID = 2,
                FirstName = "Admin",
                LastName = "",
                AccessToken = "test",
                IsAdmin = true
            };
            var result = userControllerTest.LoginUser(new Entities.Dto.LoginDto() { Email = "admin@test.com", Password = "Password1", Type = "admin" });

            Assert.IsNotEmpty(result.ToString());
        }
    }
}
