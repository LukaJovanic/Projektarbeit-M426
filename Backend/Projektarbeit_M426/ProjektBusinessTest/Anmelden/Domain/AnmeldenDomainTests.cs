using System.Threading.Tasks;
using AutoProjektBusiness.Anmelden.Domain;
using AutoProjektBusiness.Anmelden.Repository;
using AutoProjektBusiness.Shared;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace AutoProjektBusinessTest.Anmelden.Domain
{
    [TestClass]
    public class AnmeldenDomainTests
    {
        private IAnmeldenRepository _repository;
        private AnmeldenDomain _domain;

        [TestInitialize]
        public void Setup()
        {
            _repository = A.Fake<IAnmeldenRepository>();
            _domain = new AnmeldenDomain(_repository);
        }


        // TEST 1: User existiert Domain gibt diesen User zurück
        [TestMethod]
        public async Task GetUserAsync_UserExistiert_Sollte_User_Zurueckgeben()
        {
            // Arrange
            var expected = new AnmeldenUser(1, "luka", "HASH123");

            A.CallTo(() => _repository.GetHashAsync("luka"))
                .Returns(Task.FromResult(expected));

            // Act
            var result = await _domain.GetUserAsync("luka");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("luka", result.Username);
            Assert.AreEqual("HASH123", result.PasswordHash);
        }


        // TEST 2: User existiert nicht Domain gibt null zurück
        [TestMethod]
        public async Task GetUserAsync_UserExistiertNicht_Sollte_Null_Zurueckgeben()
        {
            // Arrange
            A.CallTo(() => _repository.GetHashAsync("unbekannt"))
                .Returns(Task.FromResult<AnmeldenUser?>(null));

            // Act
            var result = await _domain.GetUserAsync("unbekannt");

            // Assert
            Assert.IsNull(result);
        }
    }
}
