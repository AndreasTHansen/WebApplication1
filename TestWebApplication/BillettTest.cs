using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.DAL;
using WebApplication1.Models;
using Xunit;

namespace TestWebApplication
{
    public class BillettTest
    {
        private readonly Mock<IBillettRepository> mockRep = new Mock<IBillettRepository>();
        private readonly Mock<ILogger<BillettController>> mockLog = new Mock<ILogger<BillettController>>();

        private readonly Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
        private readonly MockHttpSession mockSession = new MockHttpSession();
        [Fact]
        public async Task LagreBillettLoggetInnOK()
        {
            
            
            // Arrange

            //Må lage for MockHttpSession, men må copy paste det han har lagret i sin versjon inn i klassen.
            mockRep.Setup(b => b.Lagre(It.IsAny<Billett>())).ReturnsAsync(true);
            var BillettController = 

            //innlogging her
            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            billettController.ControllerContext.HttpContext = mockHttpContext.Object;

            var billettController = new BillettController(mockRep.Object, mockLog.Object);
            billettController.ControllerContext.HttpContext = mockHttpContext.Object;
            //Act
            var resultat = await billettController.Lagre(It.IsAny<Billett>()) as OkObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Equal("Billett lagret", resultat.Value);
        }

        public async Task LagreBillettLoggetInnIkkeOK()
        {
            //Må lage for MockHttpSession, men må copy paste det han har lagret i sin versjon inn i klassen.
            mockRep.Setup(b => b.Lagre(It.IsAny<Billett>())).ReturnsAsync(true);

            //innlogging her

            var billettController = new BillettController(mockRep.Object, mockLog.Object);
            billettController.ControllerContext.HttpContext = mockHttpContext.Object;
            //Act
            var resultat = await billettController.Lagre(It.IsAny<Billett>()) as BadRequestObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Equal("Billetten ble ikke lagret", resultat.Value);
        }
        public async Task LagreBillettLoggetInnFeilModel()
        {

        }
        public async Task LagreBillettIkkeLoggetInn()
        {

        }
    }
}
