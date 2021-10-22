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

namespace WebAppTest
{
    public class WebAppTest
    {
        private const string _loggetInn = "loggetInn";
        private const string _ikkeLoggetInn = "";

        private readonly Mock<IBillettRepository> mockRep = new Mock<IBillettRepository>();
        private readonly Mock<ILogger<BillettController>> mockLog = new Mock<ILogger<BillettController>>();

        private readonly Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
        private readonly MockHttpSession mockSession = new MockHttpSession();

        [Fact]
        public async Task LagreLoggetInnOK()
        {

            mockRep.Setup(k => k.Lagre(It.IsAny<Billett>())).ReturnsAsync(true);

            var billettController = new BillettController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            billettController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await billettController.Lagre(It.IsAny<Billett>()) as OkObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Equal("Kunde lagret", resultat.Value);
        }
    }
}
