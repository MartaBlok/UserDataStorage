using NSubstitute;
using PersonInformation.DataLogger.Interfaces;
using PersonInformation.DataLogger.Models;
using PersonInformation.Web.Controllers;
using Xunit;

namespace PersonInformation.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index()
        {
            // Arrange
            var _userLogger = Substitute.For<IUserDataLogger>();
            var controller = new HomeController(_userLogger);

            //// Act
            var result = controller.Index(new Web.Models.PersonData
            {
                Address = "TestAddress",
                Name = "TestName",
                Surname  = "TestSurname"
            });

            //// Assert
            Assert.NotNull(result);
            _userLogger.Received().Log(Arg.Any<UserData>());
        }
    }
}
