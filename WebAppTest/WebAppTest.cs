using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.Modules;
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
            Assert.Equal("Billett lagret", resultat.Value);
        }

        [Fact]
        public async Task LagreLoggetInnOKFeil()
        {
            mockRep.Setup(k => k.Lagre(It.IsAny<Billett>())).ReturnsAsync(false);

            var billettController = new BillettController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            billettController.ControllerContext.HttpContext = mockHttpContext.Object;

            //Act
            var resultat = await billettController.Lagre(It.IsAny<Billett>()) as OkObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Null(resultat.Value);
        }

        [Fact]
        public async Task HentAlleLoggetInnOK()
        {
            //Arrange
            var billett1 = new Billett
            {
                id = 1,
                antallBarn = 0,
                antallVoksne = 1,
                totalPris = 3000,
                kundeId = 1,
                fornavn = "Test",
                etternavn = "Tester",
                epost = "test.tester@gmail.com",
                mobilnummer = "12345678",
                kortnummer = "1234123412341234",
                utlopsdato = "10/21",
                cvc = 123,
                reiseId = 1,
                reiseFra = "Oslo",
                reiseTil = "Kiel",
                datoAnkomst = "10/01/2021",
                datoAvreise = "09/01/2021",
                tidspunktFra = "19:00",
                tidspunktTil = "14:00",
                reisePris = 3000
            };
            var billett2 = new Billett
            {
                id = 2,
                antallBarn = 1,
                antallVoksne = 0,
                totalPris = 1000,
                kundeId = 2,
                fornavn = "Tester",
                etternavn = "Testerson",
                epost = "tester.testerson@gmail.com",
                mobilnummer = "87654321",
                kortnummer = "4321432143214321",
                utlopsdato = "05/22",
                cvc = 321,
                reiseId = 2,
                reiseFra = "Oslo",
                reiseTil = "København",
                datoAnkomst = "13/12/2021",
                datoAvreise = "12/12/2021",
                tidspunktFra = "12:00",
                tidspunktTil = "09:00",
                reisePris = 1000
            };

            var billettListe = new List<Billett>();
            billettListe.Add(billett1);
            billettListe.Add(billett2);

            mockRep.Setup(k => k.HentAlle()).ReturnsAsync(billettListe);

            var billettController = new BillettController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            billettController.ControllerContext.HttpContext = mockHttpContext.Object;

            //Act
            var resultat = await billettController.HentAlle() as OkObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Equal<List<Billett>>((List<Billett>)resultat.Value, billettListe);
        }

        [Fact]
        public async Task HentAlleLoggetInnOKFeilDB()
        {
            //Arrange
            var billettListe = new List<Billett>();

            mockRep.Setup(k => k.HentAlle()).ReturnsAsync(() => null);

            var billettController = new BillettController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            billettController.ControllerContext.HttpContext = mockHttpContext.Object;

            //Act
            var resultat = await billettController.HentAlle() as OkObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Null(resultat.Value);
        }

        [Fact]
        public async Task HentAlleIkkeLoggetInn()
        {
            //Arrange
            mockRep.Setup(k => k.HentAlle()).ReturnsAsync(() => null);

            var billettController = new BillettController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _ikkeLoggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            billettController.ControllerContext.HttpContext = mockHttpContext.Object;

            //Act
            var resultat = await billettController.HentAlle() as UnauthorizedObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Unauthorized, resultat.StatusCode);
            Assert.Equal("Ikke logget inn", resultat.Value);
        }

        [Fact]
        public async Task SlettLoggetInnOK()
        {
            mockRep.Setup(k => k.Slett(It.IsAny<int>())).ReturnsAsync(true);

            var billettController = new BillettController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            billettController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await billettController.Slett(It.IsAny<int>()) as OkObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Equal("Billett slettet", resultat.Value);
        }

        [Fact]
        public async Task HentEnReiseLoggetInnOK()
        {
            //Arrange
            var reise = new Reise
            {
                id = 1,
                reiseFra = "Oslo",
                reiseTil = "Kiel",
                tidspunktFra = "09:00",
                tidspunktTil = "15:00",
                datoAnkomst = "01/01/2022",
                datoAvreise = "31/12/2021",
                reisePris = 1000
            };

            mockRep.Setup(k => k.HentEnReise(It.IsAny<int>())).ReturnsAsync(reise);

            var billettController = new BillettController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            billettController.ControllerContext.HttpContext = mockHttpContext.Object;

            //Act
            var resultat = await billettController.HentEnReise(It.IsAny<int>()) as OkObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Equal<Reise>((Reise)resultat.Value, reise);
        }

        [Fact]
        public async Task HentAlleReiser()
        {
            //Arrange
            var reise1 = new Reise
            {
                id = 1,
                reiseFra = "Oslo",
                reiseTil = "Kiel",
                tidspunktFra = "09:00",
                tidspunktTil = "15:00",
                datoAnkomst = "01/01/2022",
                datoAvreise = "31/12/2021",
                reisePris = 1000
            };

            var reise2 = new Reise
            {
                id = 2,
                reiseFra = "Oslo",
                reiseTil = "København",
                tidspunktFra = "09:00",
                tidspunktTil = "18:00",
                datoAnkomst = "01/01/2022",
                datoAvreise = "31/12/2021",
                reisePris = 3000
            };

            var reiseListe = new List<Reise>();
            reiseListe.Add(reise1);
            reiseListe.Add(reise2);

            mockRep.Setup(k => k.HentAlleReiser()).ReturnsAsync(reiseListe);

            var billettController = new BillettController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            billettController.ControllerContext.HttpContext = mockHttpContext.Object;

            //Act
            var resultat = await billettController.HentAlleReiser() as OkObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Equal<List<Reise>>((List<Reise>)resultat.Value, reiseListe);
        }

        [Fact]
        public async Task LoggInnLoggetInnOK()
        {
            mockRep.Setup(k => k.LoggInn(It.IsAny<Bruker>())).ReturnsAsync(true);

            var billettController = new BillettController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            billettController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await billettController.LoggInn(It.IsAny<Bruker>()) as OkObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Equal(true, resultat.Value);
        }

        [Fact]
        public async Task LoggInnIkkeLoggetInnOK()
        {
            mockRep.Setup(k => k.LoggInn(It.IsAny<Bruker>())).ReturnsAsync(true);

            var billettController = new BillettController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _ikkeLoggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            billettController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await billettController.LoggInn(It.IsAny<Bruker>()) as UnauthorizedObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.Unauthorized, resultat.StatusCode);
            Assert.Equal("Ikke logget inn", resultat.Value);
        }
    }
}
